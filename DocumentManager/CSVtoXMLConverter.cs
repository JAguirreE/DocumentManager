using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DocumentManager.Constants;

namespace DocumentManager
{
  public class CSVtoXMLConverter
  {
    #region Propiedades
    private readonly string[] standardLabel;
    #endregion

    #region Constructor
    public CSVtoXMLConverter()
    {
      standardLabel = new string[]
      {
        "NOMBRES",
        "APELLIDOS",
        "TIPO_DOCUMENTO",
        "NUMERO_DOCUMENTO",
        "OBSERVACIONES",
        "TIPO_ARCHIVO",
      };
    }
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
        ToXML(headers, data, filePath, fileType);
    }

    /// <summary>
    /// Guarda la estructura XML
    /// </summary>
    /// <param name="headers">Títulos de las columnas</param>
    /// <param name="data">Campos del archivo</param>
    /// <param name="filePath">Ruta y nombre del nuevo destino</param>
    /// <param name="fileType">Tipo del archivo</param>
    public void ToXML(string[] headers, string[] data, string filePath, string fileType)
    {
      StringBuilder builder = new StringBuilder();

      builder.Append(XMLLabels.XMLDECLARATION);
      builder.Append(XMLLabels.XMLROOT);

      for (int i = 0; i < headers.Length; i++)
      {
        builder.Append($"<{headers[i]}>{data[i]}</{headers[i]}>\n");
      }

      builder.Append(XMLLabels.XMLROOTEND);

      File.WriteAllText(filePath, builder.ToString());
      ToCanonicalXML(builder.ToString(), fileType);
    }

    /// <summary>
    /// Convierte el archivo XML a la estrucura canónica
    /// y lo envía a las colas
    /// </summary>
    /// <param name="xmlFile">Archivo xml</param>
    /// <param name="fileType">Tipo del archivo</param>
    private void ToCanonicalXML(string xmlFile, string fileType)
    {
      // Separar el archivo por filas
      string[] rows = xmlFile.Split("\n");

      string[] specificData = Array.Empty<string>();

      // Declarar los regex que se usarán para descomponer las cabeceras y sus datos
      Regex regexLabels = new Regex("[<>]");
      Regex regexValues = new Regex("[><]");
      Regex regexNormalizer = new Regex("[A-Z]+_");

      StringBuilder builder = new StringBuilder();
      builder.Append(XMLLabels.XMLDECLARATION);
      builder.Append(XMLLabels.XMLROOT);

      foreach (string row in rows)
      {
        // Match de las etiquetas
        Match matchLabel = Regex.Match(row, @"<.+?>");
        // Match de los valores
        Match matchValue = Regex.Match(row, @">.+?<");

        if (matchLabel.Success && !matchLabel.Value.Contains("root") && !matchLabel.Value.Contains("xml version"))
        {
          // Normalizar las etiquetas
          string labelName = regexLabels.Replace(matchLabel.Value, "");
          labelName = regexNormalizer.Replace(labelName, "").ToUpper();
          string labelValue = regexValues.Replace(matchValue.Value, "");

          if (MultiContains(labelName, standardLabel)) {
            builder.Append($"<{labelName}>{labelValue}</{labelName}>\n");
          } 
          else
          {
            specificData.Append($"<{labelName}>{labelValue}</{labelName}>\n");
          }
        }

        // Separar las etiquetas de datos específicos
        if (specificData.Any())
        {
          builder.Append(XMLLabels.XMLDATOS);
          foreach(string data in specificData)
          {
            builder.Append(data);
          }
          builder.Append(XMLLabels.XMLDATOSFIN);
        }
      }

      builder.Append(XMLLabels.XMLROOTEND);
      string canonicalXML = builder.ToString();

      // Enviar al manejador de colas
      QueueManager.Instance.Enqueue(canonicalXML, fileType);
    }

    /// <summary>
    /// Evalua que un string contenga cualquiera coincidencia del array de palabras
    /// </summary>
    /// <param name="label">string a evaluar</param>
    /// <param name="words">Array de palabras que debe contener</param>
    /// <returns>Verdadero si contiene alguna de las palabras</returns>
    private bool MultiContains(string label, string[] words)
    {
      foreach (string word in words)
      {
        if (label.Contains(word))
          return true;
      }

      return false;
    }
  }
}
