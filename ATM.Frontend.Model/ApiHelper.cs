using ATM.ApiObjects;
using ATM.ApiObjects.Requests;
using ATM.ApiObjects.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using ATM.ApiObjects.Security;
using Newtonsoft.Json;
using ATM.Frontend.Model.Models;

namespace ATM.Frontend.Model
{
    public class ApiHelper
    {
        public TResp Send<TReq, TResp>(TReq request, String action) 
            where TReq : BaseRequest 
            where TResp : BaseResponse, new()
        {
            var client = new HttpClient { BaseAddress = new Uri(ConfigurationManager.AppSettings.Get("ServerAddress")) };
            var response = default(TResp);
            try
            {
                var apiRequest = CryptoHelper.Encrypt(Encoding.UTF8.GetString(Convert.FromBase64String(ConfigurationManager.AppSettings.Get("RSAPublicKey"))), ConfigurationManager.AppSettings.Get("AesVectorSalt"), JsonConvert.SerializeObject(request));
                apiRequest.AtmGuid = new Guid(ConfigurationManager.AppSettings.Get("ATMGuid"));

                var resultContent = client.PostAsync(action, apiRequest, new JsonMediaTypeFormatter()).Result;

                var str = resultContent.Content.ReadAsStringAsync().Result;
                var apiResponse = resultContent.Content.ReadAsAsync<ApiObject>().Result;

                response = JsonConvert.DeserializeObject<TResp>(
                    CryptoHelper.Decrypt(Encoding.UTF8.GetString(Convert.FromBase64String(ConfigurationManager.AppSettings.Get("RSAPrivateKey"))), ConfigurationManager.AppSettings.Get("AesVectorSalt"),
                    apiResponse)
                );
            }
            catch(Exception ex)
            {
                return new TResp { ErrorCode = (Int32)ErrorCodes.FailedConnection, ErrorMessage = LocalizationModel.GetError((Int32)ErrorCodes.FailedConnection) };
            }
            finally
            {
                client.Dispose();
            }

            if(response != null && response.ErrorCode != 0)
            {
                response.ErrorMessage = LocalizationModel.GetError(response.ErrorCode);
            }

            return response;
        }
    }
}
