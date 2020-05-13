using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentManager
{
  public sealed class QueueManager
  {
    public static QueueManager Instance { get; } = new QueueManager();

    private QueueManager()
    {
    }

    public void Enqueue(string canonicalXml, string fileType)
    {

    }
  }
}
