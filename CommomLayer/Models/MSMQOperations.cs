using System;
using System.Collections.Generic;
using System.Text;
//using Experimental.System.Messaging;
using System.Net.Mail;
using Experimental.System.Messaging;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace commomlayer.models
{
    public class msmqoperations
    {
        MessageQueue msmq = new MessageQueue();  
        public void Sender(string token)
        {
            msmq.Path = @".\private$\Tokens";
            try
            {
                //for get or create queue
                if (!MessageQueue.Exists(msmq.Path))
                {
                    MessageQueue.Create(msmq.Path);
                }

      
                msmq.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                msmq.ReceiveCompleted += Msmq_ReceiveCompleted;
                msmq.Send(token);
                msmq.BeginReceive();
                msmq.Close();
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }


        private void Msmq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            var msg = msmq.EndReceive(e.AsyncResult);
            string token = msg.Body.ToString();
        
            string mailReceiver = GetEmailFromToken(token).ToString();
            MailMessage message = new MailMessage("rajanganep28@gmail.com", mailReceiver);
            string bodymessage = "for reset click here <a href='https://localhost:44357/'> click me</a>" +
                "copy the token Provided here : " + token;
            message.Subject = " Email For reset the password";
            message.Body = bodymessage;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);//smtp server name and port number
                                                                      
            System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential("rajanganep28@gmail.com", "Secret@123");//vallid email and password
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            msmq.BeginReceive();
        }
        public static string GetEmailFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var decoded = handler.ReadJwtToken((token));
            var result = decoded.Claims.FirstOrDefault().Value;
            return result;
        }
    }
}
