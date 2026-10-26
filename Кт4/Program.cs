using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<INotifier> notifiers = new List<INotifier>();

            EmailINotifier email = new EmailINotifier();
            SmsNotifier smsNotifier = new SmsNotifier();
            TelegramNotifier telegramNotifier = new TelegramNotifier();
            notifiers.Add(email);
            notifiers.Add(smsNotifier);
            notifiers.Add(telegramNotifier);

            foreach (var notifier in notifiers)
            {
                notifier.Send("Интерфейсы - это круто!");
            }
        }
    }
    public interface INotifier
    {
        void Send(string message);
    }

    public class EmailINotifier : INotifier
    { 
        public void Send(string message) 
        {
            Console.WriteLine($"Вам отправлено сообщение по Email: {message}");
        }
    }

    public class SmsNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Вам отправлено sms-сообщение: {message}");
        }
    }

    public class TelegramNotifier : INotifier
    {
        public void Send( string message)
        {
            Console.WriteLine($"Вам отправлено Telegram-сообщение: {message}");
        }
    }

}
