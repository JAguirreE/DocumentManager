using System;
using System.Threading;
using System.Timers;

namespace DocumentManager
{
  class Program
  {
    static void Main(string[] args)
    {

      // Generamos archivos random de cada tipo de solicitud
      DocGenerator docGenerator = new DocGenerator();
      docGenerator.GenerateDocs();
      

      // Dosificamos en el tiempo los archivos mandandolos a la carpeta común
      // para simular una entrada ftp
      FilesDoser doser = new FilesDoser();
      doser.Start();

      // Iniciamos el proceso que seleccionará uno a uno y
      // en orden de antiguedad, los archivos en la carpeta común
      CommonFileProcessor filePicker = new CommonFileProcessor();
      filePicker.Start();

      Console.Read();

    }
  }
}
