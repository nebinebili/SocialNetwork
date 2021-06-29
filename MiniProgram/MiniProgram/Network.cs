using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseNamespace;
using System.Net;
using System.Net.Mail;
using DatabaseNamespace;
using ControlNamespace;


namespace NetworkNamespace
{
    class Network
    {

        public void Mail(string useremail,string userpassword,string adminemail,string text)
        {
            SmtpClient cv = new SmtpClient("smtp.gmail.com", 587);
            cv.EnableSsl = true;
            cv.Credentials = new NetworkCredential(useremail, userpassword);
            
            try
            {
                cv.Send(useremail, adminemail, "INFO", text);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        
    }
}
