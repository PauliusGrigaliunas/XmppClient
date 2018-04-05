using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmppClient
{
    class Program
    {

        public static Socket LogIn(string user, string pass)
        {
            String ip = "127.0.0.1";
            IPAddress ipAddress = IPAddress.Parse(ip);
            IPEndPoint Openfire = new IPEndPoint(ipAddress, 5222);
            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            socket.Connect(Openfire);


            try
            {
                socket.Send(Encoding.UTF8.GetBytes(@"something"));

                //socket.Connect(VUMail);
                //if (GetResponse(socket).StartsWith("-ERR"))
                //  return null;
                socket.Send(Encoding.UTF8.GetBytes("User " + user + "\r\n"));
                //string s = GetResponse(socket);
                //if (s.StartsWith("-ERR"))
                //{
                //    socket.Send(Encoding.UTF8.GetBytes("QUIT\r\n"));
                //    GetResponse(socket);
                //    return null;
                //}

                socket.Send(Encoding.UTF8.GetBytes("Pass " + pass + "\r\n"));
                //s = GetResponse(socket);
                //if (s.StartsWith("-ERR"))
                //{
                //    socket.Send(Encoding.UTF8.GetBytes("QUIT\r\n"));
                //    GetResponse(socket);
                //    return null;
                //}

                Console.WriteLine(GetResponse(socket)); //Console.WriteLine("b");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }

            return socket;

        }

        private static string GetResponse(Socket socket)
        {

            byte[] bytes = new byte[512];
            int buffSize;
            buffSize = socket.Receive(bytes);//Console.WriteLine("a");
            return Encoding.UTF8.GetString(bytes, 0, buffSize);
        }

        static void Main(string[] args)
        {
            LogIn("Paulius", "Paulius");
        }
    }
}
