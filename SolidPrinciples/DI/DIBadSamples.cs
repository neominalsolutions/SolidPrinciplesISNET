using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.DI
{
  public class DIBadSamples
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


    public class TextLogger
    {
      public void Log(Log model)
      {
        Console.WriteLine($"{model.Level} {model.Message}");
      }
    }


    public class DatabaseLogger
    {
      public void LogDB(Log model)
      {
        Console.WriteLine($"{model.Level} {model.Message}");
      }
    }


    public class LogManager // sınıf 
    {
      //BAd Sample
      //private TextLogger logger;

      //public PDFGenerator()
      //{
      //    logger = new TextLogger();

      //}

      public LogManager()
      {
        // di aykırı bir yöntem
        // instance burası yönetemez. 
        // tight coupling sıkı sıkıya bağımlılık
        _txtlogger = new TextLogger();
        _dbLogger = new DatabaseLogger();
      }



      public LogManager(TextLogger textLogger) // constructor inject
      {
        // tight coupling sıkı sıkıya bağımlılık TextLogger sınıfana bağlı
        _txtlogger = textLogger;
      }

      public LogManager(DatabaseLogger dbLogger)
      {
        _dbLogger = dbLogger;
      }

      private TextLogger _txtlogger; // bağımlılık
      private DatabaseLogger _dbLogger;

      /// <summary>
      /// Property Injection yaptık ençok kullanılan DI tekniği
      /// </summary>
      public TextLogger Logger { get { return _txtlogger; } set { _txtlogger = value; } } // property injection





      public void LogText(TextLogger logger) // method injection
      {
        logger.Log(new Log());
        _dbLogger.LogDB(new Log());
      }

      public void LogDatabase(DatabaseLogger logger)
      {

        logger.LogDB(new Log());
      }



      public void Log()
      {
        // _txtlogger.Log(new Log());
        _dbLogger.LogDB(new Log());
      }

    }

  }
}
