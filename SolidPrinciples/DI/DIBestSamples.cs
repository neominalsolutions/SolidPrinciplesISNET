using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.DI
{
    public class DIBestSamples
    {
        // senaryomuz pdf oluşturduktan sonra yapılan işleme ait loglama yapmak

        public static class LogLevel
        {
            public const string Info = "InformationLevel";
            public const string Error = "CriticalLevel";
            public const string Warn = "WarningLevel";

        }



        public class Log
        {
            public string Level { get; set; }
            public string Message { get; set; }
        }

        public interface ILogger
        {
            void Log(Log model);
        }
  
        public class TextLogger: ILogger
        {
            public void Log(Log model)
            {
                Console.WriteLine($"{model.Level} {model.Message}");
            }
        }

        public class DBLogger : ILogger
        {
            public void Log(Log model)
            {
                //DB Connection
                throw new NotImplementedException();
            }
        }


        public class LogManager
        {
           

            public LogManager()
            {

            }

            private ILogger _logger; // arayüz. DIP (Dependency Inversion 2 sınıf arasına bir arayüz bağlayarak haberleştirdik bu durumda bu arayüzden türeyen sınıfları birbirleri konuşturabiliriz.)

            /// <summary>
            /// Property Injection yaptık ençok kullanılan DI tekniği
            /// </summary>
            public ILogger Logger { get { return _logger;  } set { _logger = value;  } }


            /// <summary>
            /// Constructor Injection Yaptık. En çok kullanılan DI yöntemi
            /// </summary>
            /// <param name="logger"></param>
            public LogManager(ILogger logger) // constructor based di
            {
            // ILogger logger loose coupling gevşek bağlılık 
            _logger = logger;
            }


           public void Log()
          {
            _logger.Log(new DIBestSamples.Log());
          }

        }

    }
}
