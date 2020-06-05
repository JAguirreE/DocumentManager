using System.IO;
using DocumentManager.Constants;

namespace DocumentManager
{
  public sealed class QueueManager
  {
    #region Propiedades
    private readonly Queue highPriorityQ;
    private readonly Queue midPriorityQ;
    private readonly Queue lowPriorityQ;

    private readonly Logger logger;
    #endregion

    #region Constructor
    private QueueManager()
    {
      highPriorityQ = new Queue();
      midPriorityQ = new Queue();
      lowPriorityQ = new Queue();

      logger = new Logger(); 
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
    }
    public void ProcessHighPriority()
    {
      while(true)
      {
        Node node = highPriorityQ.GetFirstInQueue();
        if (node != null)
        {
          Process(node);
        }
      }
    }
    public void ProcessMidPriority()
    {
      while (true)
      {
        Node node = midPriorityQ.GetFirstInQueue();
        if (node != null)
        {
          Process(node);
        }
      }
    }
    public void ProcessLowPriority()
    {
      while (true)
      {
        Node node = lowPriorityQ.GetFirstInQueue();
        if (node != null)
        {
          Process(node);
        }
      }
    }
    private void Process(Node node)
    {
      switch (node.FileType)
      {
        case FileTypes.SOLI:
          node.FilePath = node.FilePath.Replace("XML_SOLI", "OUT_SOLI");
          break;

        case FileTypes.MAFI:
          node.FilePath = node.FilePath.Replace("XML_SOLMAFI", "OUT_SOLMAFI");
          break;

        case FileTypes.MAAC:
          node.FilePath = node.FilePath.Replace("XML_SOLMAAC", "OUT_SOLMAAC");
          break;

        case FileTypes.SOLGRA:
          node.FilePath = node.FilePath.Replace("XML_SOLGRA", "OUT_SOLGRA");
          break;

        case FileTypes.CREES:
          node.FilePath = node.FilePath.Replace("XML_SOLCREES", "OUT_SOLCREES");
          break;

        case FileTypes.CANMA:
          node.FilePath = node.FilePath.Replace("XML_SOLCANMA", "OUT_SOLCANMA");
          break;

        default:
          return;
      }

      File.WriteAllText(node.FilePath, node.CanonicalXML);
      logger.AddProcessLog(node);
    }

  }
}
