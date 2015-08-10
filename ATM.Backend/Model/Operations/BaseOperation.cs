using ATM.ApiObjects;
using ATM.ApiObjects.Requests;
using ATM.ApiObjects.Responses;
using ATM.ApiObjects.Security;
using ATM.Backend.DalSpecifications;
using ATM.Backend.DalSpecifications.Entities;
using ATM.Backend.Model.Exceptions;
using Newtonsoft.Json;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATM.Backend.Operations
{
    public abstract class BaseOperation<TReq, TResp>
        where TReq : BaseRequest
        where TResp : BaseResponse, new()
    {
        protected TReq RequestObject { get; set; }
        protected TResp ResponseObject { get; set; }

        protected IDbHelper DbHelper { get; set; }
        protected ILogHelper LogHelper { get; set; }

        protected AtmInstance Atm { get; set; }

        protected ApiObject Request { get; set; }
        public ApiObject Response { get; set; }

        public BaseOperation(ApiObject request)
        {
            DbHelper = NinjectWrapper.NinjectKernel.Get<IDbHelper>();
            LogHelper = NinjectWrapper.NinjectKernel.Get<ILogHelper>();

            Request = request;

            ResponseObject = new TResp();
        }

        protected virtual void Prepare()
        {
            try
            {
                Atm = DbHelper.Where<AtmInstance>((x) => x.AtmGuid == Request.AtmGuid && !x.IsDeleted).FirstOrDefault();

                if (Atm == null)
                {
                    throw new BaseException(ErrorCodes.AtmNotExists);
                }
            }
            catch (BaseException ex)
            {
                throw ex;
            }

            if (Atm.IsBlocked)
            {
                throw new BaseException(ErrorCodes.AtmIsBlocked);
            }

            try
            {
                var decryptedString = CryptoHelper.Decrypt(Atm.RSAPrivateKey, ConfigManager.GetValue(ConfigManager.AesVectorSalt), Request);
                if (String.IsNullOrEmpty(decryptedString))
                {
                    throw new BaseException(ErrorCodes.InvalidData);
                }

                RequestObject = JsonConvert.DeserializeObject<TReq>(decryptedString);
            }
            catch (BaseException ex)
            {
                Atm.NumberOfSuspiciousActivities++;

                if (Atm.NumberOfSuspiciousActivities < Int32.Parse(ConfigManager.GetValue(ConfigManager.MaxInvalidRequestsNumber)) 
                    && Atm.FirstSuspiciousActivityTime.AddMinutes(Int32.Parse(ConfigManager.GetValue(ConfigManager.MaxInvalidRequestsPeriodMinutes))) > DateTime.Now)
                {
                    Atm.IsBlocked = true;
                }
                else if (Atm.FirstSuspiciousActivityTime.AddMinutes(Int32.Parse(ConfigManager.GetValue(ConfigManager.MaxInvalidRequestsPeriodMinutes))) < DateTime.Now)
                {
                    Atm.FirstSuspiciousActivityTime = DateTime.Now;
                    Atm.NumberOfSuspiciousActivities = 1;
                }

                DbHelper.Update(Atm);

                throw ex;
            }

            if (Atm.IpAddress != RequestObject.IpAddress)
            {
                Atm.IsBlocked = true;
                DbHelper.Update(Atm);
                throw new BaseException(ErrorCodes.AtmIsBlocked);
            }
        }

        protected virtual void Proceed() { }
        protected virtual void Finish() { }

        public void Execute()
        {
            try
            {
                Prepare();
                Proceed();
                Finish();
            }
            catch (BaseException ex)
            {
                LogHelper.LogItem(new LogItem { Tag = "exception", Trace = ex.StackTrace, Description = ex.Message, ErrorCode = (Int32)(ex.ErrorCode) });

                ResponseObject.ErrorCode = (Int32)ex.ErrorCode;
                ResponseObject.DebugMessage = ex.Message;
            }
            catch (Exception ex)
            {
                LogHelper.LogItem(new LogItem { Tag = "exception", Trace = ex.StackTrace, Description = ex.Message, ErrorCode = (Int32)ErrorCodes.Default });

                ResponseObject.ErrorCode = (Int32)ErrorCodes.Default;
                ResponseObject.DebugMessage = ex.Message;
            }
            finally
            {
                DbHelper.Dispose();
                LogHelper.Dispose();
            }

            if (Atm != null)
            {
                Response = CryptoHelper.Encrypt(Atm.RSAPublicKey, ConfigManager.GetValue(ConfigManager.AesVectorSalt), JsonConvert.SerializeObject(ResponseObject));
            }
        }
    }
}