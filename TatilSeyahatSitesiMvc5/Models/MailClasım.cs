using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace TatilSeyahatSitesiMvc5.Models
{
    public class MailClasım
    {
        public static void MailSender(string body)
        {
            var fromAddress = new MailAddress("frknglww@gmail.com");
            var toAddress = new MailAddress("frknglww@gmail.com");
            const string subject = "Tatil Delisi | Sitenizden Gelen İletişim Formu";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "qpzeysnewlskuvvc")
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                {
                    smtp.Send(message);
                }
            }
        }
    }
}