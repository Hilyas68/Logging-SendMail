using LoggingMail.Web.Messaging;
using LoggingMail.Web.Models;
using NLog;
using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Mvc;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace LoggingMail.Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Index()
        {
            Nlog();

            return View();
        }


        [HttpPost]
        public ActionResult Index(SendMailViewModel svm)
        {
            if (ModelState.IsValid)
            {
                string key = ConfigurationManager.AppSettings["Sendgrid.Key"];
                SendGridEmailService messageSvc = new SendGridEmailService(key);

                string htmlBody = $@"<ul>
                                <li>Name: {svm.Name}</li>    
                                <li>Email: {svm.Email}</li>
                                <li>Phone Number: {svm.Phone}</li>
                                <li>Message Deatails: {svm.Message}</li>
                            </ul>";

                EmailMessage msg = new EmailMessage()
                {
                    Body = htmlBody,
                    Subject = "Cyberspace Test",
                    From = svm.Name,
                    Recipient = "htope68@gmail.com"
                };

                string envPath = HttpRuntime.AppDomainAppPath;
                string fileName = $"{envPath}\\Log4net\\log-file.txt";
                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);

                messageSvc.SendMail(msg, true, fileName, imageData);
            }

            return View();
        }

        private static void Nlog()
        {
            try
            {
                int[] integers = { 1, 2, 3 };
                int fourth = integers[3];

            }
            catch (IndexOutOfRangeException ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();

                logger.Error(ex, "Index number not available");

            }
        }

        public ActionResult Log4net()
        {
            Logging4Net();

            return View();
        }

        private static void Logging4Net()
        {
            try
            {
                int[] integers = { 1, 2, 3 };
                int fourth = integers[3];

            }
            catch (IndexOutOfRangeException ex)
            {
                log.Fatal("This was a terrible error");

                log.Error("Index number not available", ex);

            }
        }
    }
}