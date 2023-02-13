﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WinFormOturumAcmaIslemleri.Models;

namespace WinFormOturumAcmaIslemleri.Models
{
    public class MailGonderici
    {
        WinFormOturumAcmaIslemleriEntitiesConnectionDb db = new WinFormOturumAcmaIslemleriEntitiesConnectionDb();
        public void Microsoft(string GondericiMail, string GondericiPass, string AliciMail)
        {
            PersonelGirisTablosu p=db.PersonelGirisTablosu.FirstOrDefault(x=>x.MailAdress==GondericiMail);
            Random rnd=new Random();
            p.Password = rnd.Next(1000, 10000).ToString();
            db.SaveChanges();
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.outlook.com";
            sc.EnableSsl = true;
            sc.Credentials = new NetworkCredential(GondericiMail, GondericiPass);

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(GondericiMail, "Oturum Açma Örnek Projesi");
            mail.To.Add(AliciMail);
            mail.Subject = "Şifre Sıfırlama Talebinde Bulundunuz";
            mail.IsBodyHtml = true;
            mail.Body = $@"{DateTime.Now.ToString()} Tarihinde şifre sıfırlama talebinde bulundundunuz. Yeni şifreniz{p.Password}";

            //sc.Timeout = 100;
            sc.Send(mail);
        }
    }
}
