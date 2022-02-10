using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public interface IBridgeComponents
    {
        void Send(string messageType);
    }

    public abstract class SendData
    {
        public IBridgeComponents _iBridgeComponents;

        public abstract void Send();
    }

    public class SendEmail: SendData
    {
        public override void Send()
        {
            _iBridgeComponents.Send("Email");
        }
    }

    public class SendSMS : SendData
    {
        public override void Send()
        {
            _iBridgeComponents.Send("SMS");
        }
    }

    public class WebService : IBridgeComponents
    {
        public void Send(string messageType)
        {
            Console.WriteLine($"Sending {messageType} using WebService.");
        }
    }

    public class APIDeTerceros : IBridgeComponents
    {
        public void Send(string messageType)
        {
            Console.WriteLine($"Sending {messageType} using API de terceros.");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            SendData _sendData = new SendEmail();
            _sendData._iBridgeComponents = new WebService();
            _sendData.Send();

            _sendData._iBridgeComponents = new APIDeTerceros();
            _sendData.Send();

            _sendData = new SendSMS();
            _sendData._iBridgeComponents = new WebService();
            _sendData.Send();

            _sendData._iBridgeComponents = new APIDeTerceros();
            _sendData.Send();

            Console.ReadKey();

        }
    }
}
