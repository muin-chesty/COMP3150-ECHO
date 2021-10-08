using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class EmailSender : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("comp385035@gmail.com");
        mail.To.Add("doors2020@outlook.com");
        mail.Subject = "EMAIL FOR COMP3150";
        mail.Body = "THIS EMAIL IS TO TEST OUT COMP EMIAL";

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.EnableSsl = true;
        smtpServer.Credentials = new NetworkCredential("comp385035@gmail.com", "Syd3850#Group35") as ICredentialsByHost;

        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        smtpServer.Send(mail);
        Debug.Log("success");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
