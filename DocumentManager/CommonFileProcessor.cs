using System;
using System.IO;
using System.Linq;
using System.Timers;
using DocumentManager.Constants;

namespace DocumentManager
{
  public class CommonFileProcessor
  {
    #region Propiedades
    private Timer Timer;
    private readonly CSVtoXMLConverter Converter;
    private readonly string CommonPath;
    #endregion

    public CommonFileProcessor()
    {
      CommonPath = Directories.COMMONPATH;
      Converter = new CSVtoXMLConverter();
    }

    /// <summary>
    /// Inicia el proceso
    /// </summary>
    public void Start()
    {
      Timer = new Timer
      {
        Interval = 1000,
        AutoReset = true,
        Enabled = true,
      };

      Timer.Elapsed += GetFile;
    }

    private void GetFile(object source, ElapsedEventArgs e)
    {
      GetOlderFile();
    }

    /// <summary>
    /// Obtiene el archivo más antiguo
    /// y lo manda a convertir a XML
    /// </summary>
    private void GetOlderFile()
    {
      DirectoryInfo info = new DirectoryInfo(CommonPath);
      FileInfo file = info.GetFiles().OrderBy(p => p.CreationTime).FirstOrDefault();
      if(file != null)
      {
        Converter.ConvertToXML(file);
        file.Delete();

      // Comentario carlos Correa//
      // comentarios//
      }
    }
  }
}
