using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TCC_Hotel_For_Pets.DB.Plugin_EMAIL
{
    class Email
    {
        public void Enviar(string para, string mensagem)
        {


            https://myaccount.google.com/lesssecureapps?pli=1
            string remetente = "hotelforpet.2018@gmail.com";
            string senha = "lovepets2018";
            

            string assunto = "Nova Mensagem | Cadastro";
            mensagem = CriarMensagemComHtml(mensagem);

            // Configura a mensagem
            MailMessage email = new MailMessage();

            // Configura Remetente, Destinatário
            email.From = new MailAddress(remetente);
            email.To.Add(para);

            // Configura Assunto, Corpo e se o Corpo está em Html
            email.Subject = assunto;
            email.Body = mensagem;
            email.IsBodyHtml = true;



            // Configura os parâmetros do objeto SMTP
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;


            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(remetente, senha);

            // Envia a mensagem
            smtp.Send(email);


        }

        public string CriarMensagemComHtml(string mensagem)
        {
            // Lê o html do arquivo email.html
            string html = File.ReadAllText("DB/Diferenciais/PluginEMAIL/HTMLEMAIL.html");

            // Substitui as quebras de linhas pela tag <br>
            mensagem = mensagem.Replace("\n", "<br>");

            // Coloca a mensagem no template em html
            mensagem = html.Replace("{MENSAGEM}", mensagem);

            return mensagem;
        }
    }
}
