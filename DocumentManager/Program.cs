using System;
using System.Text.RegularExpressions;
using System.Threading;
using DocumentManager.Constants;

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

      // Iniciamos el precesamiento de la cola de alta prioridad
      Thread highPriorityTh = new Thread(QueueManager.Instance.ProcessHighPriority)
      {
        Priority = ThreadPriority.Highest
      };
      highPriorityTh.Start();

      // Iniciamos el precesamiento de la cola de media prioridad
      Thread midPriorityTh = new Thread(QueueManager.Instance.ProcessMidPriority)
      {
        Priority = ThreadPriority.Normal
      };
      midPriorityTh.Start();

      // Iniciamos el precesamiento de la cola de baja prioridad
      Thread lowPriorityTh = new Thread(QueueManager.Instance.ProcessLowPriority)
      {
        Priority = ThreadPriority.Lowest
      };
      lowPriorityTh.Start();

      Console.Read();
    }
  }
}
