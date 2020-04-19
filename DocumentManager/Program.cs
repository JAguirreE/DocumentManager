using System;
using System.Timers;

namespace DocumentManager
{
  class Program
  {
    static void Main(string[] args)
    {
      DocGenerator docGenerator = new DocGenerator();
      docGenerator.GenerateDocs();

      FilesDoser doser = new FilesDoser();
      doser.Start();
    }
  }
}
