using System;
using System.Net.Mail;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SendGrid;
using SendGrid.Helpers.Mail;
using Flashato.Services.Interfaces;

namespace Flashato.Services
{
    public class MessageServices : IMessageServices
    {

        public void SendDeck(string recipient)
        {
            string apiKey = "enter api here";
            SendGridAPIClient sg = new SendGridAPIClient(apiKey);

            Email from = new Email("admin@flashato.com");
            string subject = "Hello from Flashato";
            Email to = new Email(recipient);
            Content content = new Content("text/plain","Hello there");
            Mail mail = new Mail(from, subject, to, content);

            dynamic response = sg.client.mail.send.post(requestBody: mail.Get());
        }
    }
}