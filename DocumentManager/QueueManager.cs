using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DocumentManager.Constants;

namespace DocumentManager
{
  public sealed class QueueManager
  {
    private readonly Queue highPriorityQ;
    private readonly Queue midPriorityQ;
    private readonly Queue lowPriorityQ;

    #region Constructor
    private QueueManager()
    {
      highPriorityQ = new Queue();
      midPriorityQ = new Queue();
      lowPriorityQ = new Queue();
    }

    public static QueueManager Instance { get; } = new QueueManager();
    #endregion

    public void Enqueue(string canonicalXml, string fileType, string filePath)
    {
      switch (fileType)
      {
        // Alta propridad
        case FileTypes.SOLI:
        case FileTypes.MAFI:
        case FileTypes.MAAC:
          highPriorityQ.Enqueue(canonicalXml, fileType, filePath);
          break;

        // Media prioridad
        case FileTypes.SOLGRA:
        case FileTypes.CREES:
          midPriorityQ.Enqueue(canonicalXml, fileType, filePath);
          break;

        // Baja prioridad
        case FileTypes.CANMA:
          lowPriorityQ.Enqueue(canonicalXml, fileType, filePath);
          break;

        default:
          break;
      }

      //File.WriteAllText(filePath, canonicalXml);

    }

    public void ProcessHighPriority()
    {
      Node node = highPriorityQ.GetFirstInQueue();
      Process(node.CanonicalXML, node.FileType, node.FilePath);
    }
    public void ProcessMidPriority()
    {

    }
    public void ProcessLowPriority()
    {

    }
    private void Process(string canonicalXml, string fileType, string filePath)
    {

      switch (fileType)
      {
        case FileTypes.SOLI:
          filePath.Replace("XML_SOLI", "OUT_SOLI");
          break;

        case FileTypes.MAFI:
          filePath.Replace("XML_SOLMAFI", "OUT_SOLMAFI");
          break;

        case FileTypes.MAAC:
          filePath.Replace("XML_SOLMAAC", "OUT_SOLMAAC");
          break;

        case FileTypes.SOLGRA:
          filePath.Replace("XML_SOLGRA", "OUT_SOLGRA");
          break;

        case FileTypes.CREES:
          filePath.Replace("XML_SOLCREES", "OUT_SOLCREES");
          break;

        case FileTypes.CANMA:
          filePath.Replace("XML_SOLCANMA", "OUT_SOLCANMA");
          break;

        default:
          break;
      }

      File.WriteAllText(filePath, canonicalXml);
      WriteLog();
    }

    private void WriteLog()
    {

    }

  }
}
