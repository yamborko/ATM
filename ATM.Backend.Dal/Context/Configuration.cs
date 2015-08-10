namespace ATM.Backend.Dal.Context
{
    using DalSpecifications.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

#if DEBUG
            AutomaticMigrationDataLossAllowed = true;
#endif
        }

        protected override void Seed(DatabaseContext context)
        {
            if (context.AtmInstances.Count() == 0)
            {
                context.AtmInstances.Add(new AtmInstance
                {
                    CashAmount = 50000,
                    AtmGuid = new Guid("1F658227-3131-411A-A05F-DCC4CDC71594"),
                    FirstSuspiciousActivityTime = DateTime.Now,
#if DEBUG
                    IpAddress = "127.0.0.1",
#else
                IpAddress = "127.0.0.1",
#endif
                    RSAPublicKey = "<RSAKeyValue><Modulus>0mYnm2StQbUECFKlfSs1rt3eJmyu2vnhVRKjjOfZCxEWwQzO8pqWH7rLfZ56Fhnc+ICWFj8nqS5EfWviNqE6o7+9/SJEJfxGKbaJAKRjbfez6/7oojeJSW6/EVWN6fvOnI8Ek4Bm9mIVrwl6pIJB4su0YNPq85K05GY1qe6y1hs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>",
                    RSAPrivateKey = "<RSAKeyValue><Modulus>0mYnm2StQbUECFKlfSs1rt3eJmyu2vnhVRKjjOfZCxEWwQzO8pqWH7rLfZ56Fhnc+ICWFj8nqS5EfWviNqE6o7+9/SJEJfxGKbaJAKRjbfez6/7oojeJSW6/EVWN6fvOnI8Ek4Bm9mIVrwl6pIJB4su0YNPq85K05GY1qe6y1hs=</Modulus><Exponent>AQAB</Exponent><P>1bZUWsS+mjK7RewPqEP5GsfYlp4CrNnW7qunkScI56P6zQsoLUS1Lw0l3sYkupbTU3q1W3wGOMbvwddeaRBDkQ==</P><Q>/Af+pk1hz3OQ+Ytu04fdzO0NIgWlZjUuWn6qv/r1TH1zCPJ5uvv7oBsyBb+O2LFw67jdThtITyU3AYeUWm/Q6w==</Q><DP>SsonFSjbJy1v2lV1WUaIa7Xad0NO3lzR2e6akrKdbCs3vwATjFwKKDAqu56OBfp4dDNyOlTZ/I6qIyUStiPp8Q==</DP><DQ>wjRW4UbXi8d9ew0aRR14qCQx7nlzTiLEqS7Z3D1BL8OrFMXjT1ZEOsc58Hv/UrLIVJuKzFjxiyseC6uxgU6QKQ==</DQ><InverseQ>GIgHsKeN4TWQN9um1s8CDC7nj2/3IwvdOWMA8bx5VdjdqcnEh9UQ9pgqRkaObNnLxAKtyeJNvrT5ggsJrgwqYg==</InverseQ><D>D2OpdS3hl/Mr+FZGaufEmKXIOfp5HH5qg1TgFM5gi1t7CDChP0Po9yksLGQLFtLAqh+9p2+3I7v4ObRKasFTdV5GW3G4iiMCm0OHF4SG+GWsu0JbvHAumto+c9PyKnmdRG2dzgE/y2PHBTjB/pCvcW/Ir0vC30kkP1RJ03Wb1AE=</D></RSAKeyValue>"
                });

                context.CardNumbers.AddRange(new List<CardNumber> {
                new CardNumber {
                    Accounts = new List<Account> { new Account { BalanceAmount = 10000, Number = "1" } },
                    Number = "1111222233334444",
                    Pin = "1234"
                },
                new CardNumber {
                    Accounts = new List<Account> { new Account { BalanceAmount = 50000, Number = "2" } },
                    Number = "5555666677778888",
                    Pin = "5678"
                },
                new CardNumber {
                    Accounts = new List<Account> { new Account { BalanceAmount = 1000, Number = "3" } },
                    Number = "4444333322221111",
                    Pin = "4321"
                },
                new CardNumber {
                    Accounts = new List<Account> { new Account { BalanceAmount = 10000, Number = "4" } },
                    Number = "8888777766665555",
                    Pin = "8765",
                    IsBlocked = true,
                }
            });

                context.SaveChanges();
            }
        }
    }
}
