using System;

namespace DocumentManager
{
  class Program
  {
    
    static void Main(string[] args)
    {
      DocGenerator docGenerator = new DocGenerator();

      docGenerator.GenerateDocs();
    }
  }
}
