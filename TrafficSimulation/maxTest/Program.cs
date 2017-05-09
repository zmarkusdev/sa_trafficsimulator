using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (NamedPipeClientStream namedPipeClient = new NamedPipeClientStream("DataAccess-pipe"))
            {
                string message = "";
                namedPipeClient.Connect();
                do
                {
                    Console.Write("Enter a message to be sent to the server: ");
                    message = Console.ReadLine();
                    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
                    try
                    {
                        namedPipeClient.Write(messageBytes, 0, messageBytes.Length);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine("Die Pipe ist verstopft!");
                    }
                } while (String.Compare(message, "ende") != 0);
            }
            Console.WriteLine("Fertig");
            Console.ReadKey();

        }
    }
}
