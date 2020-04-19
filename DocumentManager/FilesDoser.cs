using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Timers;

namespace DocumentManager
{
  public class FilesDoser
  {
    private Timer Timer;
    private readonly string FilesPath;
    readonly string[] Files;
    int Counter;

    public FilesDoser()
    {
      FilesPath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).FullName + "\\files";
      Files = Directory.GetFiles(FilesPath);
      Counter = 0;
    }

    public void Start()
    {
      Timer = new Timer
      {
        Interval = 500,
        AutoReset = true,
        Enabled = true,
      };

      Timer.Elapsed += DosifyFiles;
      Console.Read();
    }

    private void DosifyFiles(object source, ElapsedEventArgs e)
    {
      MoveFile();
    }

    private void MoveFile()
    {
      Console.WriteLine("Transfering files via FTP");
      if(Counter < Files.Length)
      {
        string newDir = Files[Counter].Replace("files", "common");
        Directory.Move(Files[Counter], newDir);
        Counter++;
      }
      else
      {
        Timer.Stop();
      }
    }

    


  }
}
