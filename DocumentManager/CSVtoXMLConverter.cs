using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Text;
using DocumentManager.Constants;

namespace DocumentManager
{
  public class CSVtoXMLConverter
  {
    #region Propiedades
    private const string XMLDECLARATION = "<?xml version=\"1.0\" ?>";
    private const string XMLROOT = "<root>";
    private const string XMLROOTEND = "</root>";
    #endregion

    /// <summary>
    /// Lee el archivo, lo descompone y lo manda a convertir a XML
    /// </summary>
    /// <param name="file">Archivo csv</param>
    public void ConvertToXML(FileInfo file)
    {
      string fileText = File.ReadAllText(file.FullName);
      string fileName = file.Name.Replace(".csv", ".xml");

      string[] fileComponent = fileText.Split('\n');
      string[] headers = fileComponent[0].Split(',');
      string[] data = fileComponent[1].Split(',');

      string fileType = data[^1];
      string filePath = "";

      switch (fileType)
      {
        case FileTypes.SOLI:
          filePath = string.Concat(Directories.SOLIPATH, "\\", fileName);
          break;

        case FileTypes.MAFI:
          filePath = string.Concat(Directories.SOLMAFIPATH, "\\", fileName);
          break;

        case FileTypes.MAAC:
          filePath = string.Concat(Directories.SOLMAACPATH, "\\", fileName);
          break;

        case FileTypes.SOLGRA:
          filePath = string.Concat(Directories.SOLGRAPATH, "\\", fileName);
          break;

        case FileTypes.CREES:
          filePath = string.Concat(Directories.SOLCREESPATH, "\\", fileName);
          break;

        case FileTypes.CANMA:
          filePath = string.Concat(Directories.SOLCANMAPATH, "\\", fileName);
          break;

        default:
          break;
      }

      if(!string.IsNullOrEmpty(fileName))
        ToXML(headers, data, filePath);
    }

    /// <summary>
    /// Guarda la estructura XML
    /// </summary>
    /// <param name="headers">Títulos de las columnas</param>
    /// <param name="data">Campos del archivo</param>
    /// <param name="filePath">Ruta y nombre del nuevo destino</param>
    public void ToXML(string[] headers, string[] data, string filePath)
    {
      StringBuilder builder = new StringBuilder();

      builder.Append(XMLDECLARATION);
      builder.Append(XMLROOT);

      for (int i = 0; i < headers.Length; i++)
      {
        builder.Append($"<{headers[i]}>{data[i]}</{headers[i]}>");
      }

      builder.Append(XMLROOTEND);

      File.WriteAllText(filePath, builder.ToString());
    }
  }
}
