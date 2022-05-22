using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel.Controllers
{
    public class Contacto : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Index(string INombre,string Iemail,string Itext)
        {
            var fromAddress = "luahotel44@gmail.com";
            var toAddress = "uchihamels@gmail.com";
            var fromPassword = "hola1234*";
            string subject = INombre;
            string body = "From: " + Iemail + "n";
            body += "Email: " + Iemail + "n";
            body += "Subject: " + INombre + "n";
            body += "Question: n" + Itext + "n";
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential(fromAddress, fromPassword);
                smtp.Timeout = 20000;
            
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
            return View();
        }
        /*
protected void SendMail()
{
    var fromAddress = "uchihamels@gmail.com";
    var toAddress = "luahotel44@gmail.com";

    string subject = IName.
    string body = "From: " + YourName.Text + "n";
    body += "Email: " + YourEmail.Text + "n";
    body += "Subject: " + YourSubject.Text + "n";
    body += "Question: n" + Comments.Text + "n";
    // smtp settings
    var smtp = new System.Net.Mail.SmtpClient();
    {
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.EnableSsl = true;
        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
        smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
        smtp.Timeout = 20000;
    }
    // Passing values to smtp object
    smtp.Send(fromAddress, toAddress, subject, body);
}

        protected void btn_SendMail(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("no entra");

        }
    }*/
    }
}
