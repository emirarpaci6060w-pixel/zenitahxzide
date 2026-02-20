using System;
using System.Net;
using System.Text;

class Program
{
    static void Main()
    {
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:5000/");
        listener.Start();

        Console.WriteLine("Server çalışıyor: http://localhost:5000/");

        while (true)
        {
            HttpListenerContext context = listener.GetContext();
            string ip = context.Request.RemoteEndPoint?.Address.ToString();

            Console.WriteLine("Siteye giren IP: " + ip);

            string responseString = "Merhaba 👋 IP adresin kaydedildi.";
            byte[] buffer = Encoding.UTF8.GetBytes(responseString);

            context.Response.ContentLength64 = buffer.Length;
            context.Response.OutputStream.Write(buffer, 0, buffer.Length);
            context.Response.OutputStream.Close();
        }
    }
}