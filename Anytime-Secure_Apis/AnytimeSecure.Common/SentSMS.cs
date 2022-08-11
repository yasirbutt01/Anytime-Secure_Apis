using System;
using System.Collections.Generic;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace AnytimeSecure.Common
{
    public class SentSMS
    {
        public string SendSmsToUser(string textMessage, string to, string twilioAccountSID, string TwilioAuthToken, string TwilioFromNumber)
        {
            try
            {
                TwilioClient.Init(twilioAccountSID, TwilioAuthToken);

                var message = MessageResource.Create(
                    body: textMessage,
                    from: new Twilio.Types.PhoneNumber(TwilioFromNumber),
                    to: new Twilio.Types.PhoneNumber(to)
                );

                return message.ToString();
            }
            catch (Exception e)
            {
                return "";
            }

        }
    }
}
