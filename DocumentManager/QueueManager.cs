using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DocumentManager.Constants;

namespace DocumentManager
{
  public sealed class QueueManager
  {
    public Queue highPriorityQ;
    public Queue midPriorityQ;
    public Queue lowPriorityQ;

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
          EnqueueToHigh();
          break;

        // Media prioridad
        case FileTypes.SOLGRA:
        case FileTypes.CREES:
          EnqueueToMid();
          break;

        // Baja prioridad
        case FileTypes.CANMA:
          EnqueueToLow();
          break;

        default:
          break;
      }

      File.WriteAllText(filePath, canonicalXml);

    }

    private void EnqueueToHigh()
    {

    }

    private void EnqueueToMid()
    {

    }

    private void EnqueueToLow()
    {

    }

    private void Proccess(string canonicalXml, string fileType, string filePath)
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
    }

    private void WriteLog()
    {

    }

  }
}
