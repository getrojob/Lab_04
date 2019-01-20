using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace Lab_04.App
{
    public static class WebApp
    {

        private static string comentarioArquivo {
            get {
                return HttpContext.Current.Server.MapPath("~/comentarios.txt");
            }
        }

        public static void ComentarioIncluir(string nome, string comentario)
        {
            using (var writer = new StreamWriter(comentarioArquivo, true, Encoding.UTF8))
            {
                writer.WriteLine("{0:dd/MM/yyyy} - {1:HH:mm:ss}", DateTime.Now, DateTime.Now);
                writer.WriteLine("{0}: {1}\r\n", nome, comentario);
            }
        }
        public static string ComentarioObter()
        {
            string texto = string.Empty;
            if (!File.Exists(comentarioArquivo))
            {
                return texto;
            }
            using (var reader = new StreamReader(comentarioArquivo))
            {
                texto = reader.ReadToEnd();
            }
            return texto;
            
        }
    }
}