using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class Action_img : Action
    {
        public Action_img(Mail mail) : base(mail)
        {
            Mail = mail;
        }

        public override void Job()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("JTTT", fromMail));
            message.To.Add(new MailboxAddress("YourName", Mail.Address));
            message.Subject = "Key found event!";

            var body = new TextPart("plain")
            {
                Text = @"Hey YourName,

                    We found your key!

                    Have nice day!

                    -- JTTT"
            };

            var multipart = new Multipart("mixed");
            multipart.Add(body);

            string path = @"img.jpg";

            var attachment = new MimePart("image", "jpg")
            {
                Content = new MimeContent(System.IO.File.OpenRead(path), ContentEncoding.Default),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = System.IO.Path.GetFileName(path)
            };

            multipart.Add(attachment);

            message.Body = multipart;

            using (var mailClient = new SmtpClient())
            {
                mailClient.ServerCertificateValidationCallback = (s, c, h, e) => true;

                mailClient.Connect("scz.pl", 587, SecureSocketOptions.Auto);

                ////Note: only needed if the SMTP server requires authentication
                mailClient.Authenticate(fromMail, "Amadeusz");

                mailClient.Send(message);
                mailClient.Disconnect(true);
            }
        }

        public override string ToString()
        {
            return "Send Image";
        }
    }
}
