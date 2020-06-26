using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DocumentManager.Constants;

namespace DocumentManager
{
  public class Logger
  {
    public void AddProcess(Node node, string logName)
    {
      FileInfo xmlFile = new FileInfo(node.FilePath);

      StringBuilder builder = new StringBuilder();
      string line = string.Format("Tipo de documento: {0}, Fecha de procesamiento: {1}, Peso del archivo: {2} \n", node.FileType, DateTime.Now, xmlFile.Length);
      builder.Append(line);

      FileInfo logFile = new FileInfo(string.Concat(Directories.OUTLOGPATH, logName));

      if (logFile != null)
      {
        using StreamWriter sw = logFile.AppendText();
        sw.Write(builder.ToString());
        sw.Close();
      }
      else
      {
        string filePath = string.Concat(Directories.OUTLOGPATH, logName);
        File.WriteAllText(filePath, builder.ToString());
      }
    }

    public void AddProcessLog(Node node)
    {
      string logName = "";
      switch (node.FileType)
      {
        // Alta propridad
        case FileTypes.SOLI:
        case FileTypes.MAFI:
        case FileTypes.MAAC:
          logName = "\\highPriorityLog.txt";
          break;

        // Media prioridad
        case FileTypes.SOLGRA:
        case FileTypes.CREES:
          logName = "\\midPriorityLog.txt";
          break;

        // Baja prioridad
        case FileTypes.CANMA:
          logName = "\\lowPriorityLog.txt";
          break;

        default:
          break;
      }

      AddProcess(node, logName);
    }
  }
}
