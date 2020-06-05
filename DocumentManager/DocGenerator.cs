using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using DocumentManager.Constants;

namespace DocumentManager
{
  public class DocGenerator
  {
    #region Propiedades
    private readonly Random Rnd;
    private readonly string FilesPath;
    private readonly string CommonPath;
    
    private string[] Names;
    private string[] Lastnames;
    private string[] DocTypes;
    private string[] DocNumbers;
    private string[] Observations;
    private string[] Subjects;
    private string[] Careers;
    private string[] Dates;
    private string[] PaymentMethods;
    private string[] Reasons;
    #endregion

    #region Constructor
    public DocGenerator() 
    {
      Rnd = new Random();
      FilesPath = Directories.FILESPATH;
      CommonPath = Directories.COMMONPATH;

      Names = new string[]
      {
        "Andres",
        "Alejandra",
        "Carlos",
        "Camilo",
        "Daniela",
        "Duvan",
        "Esteban",
        "Estela",
        "Fabiola",
        "Francisco"
      };

      Lastnames = new string[]
      {
        "Arias",
        "Aguirre",
        "Calderon",
        "Cardenas",
        "Diaz",
        "Diomedes",
        "Estrada",
        "Estupiñan",
        "Franco",
        "Falcon"
      };

      DocTypes = new string[]
      {
        "CC",
        "PASAPORTE",
        "CE",
        "TI"
      };

      DocNumbers = new string[]
      {
        "1225485",
        "3215732",
        "8073795",
        "2392227",
        "7250142",
        "4315731",
        "6181647",
        "8761204",
        "1175785",
        "5003409"
      };

      Observations = new string[]
      {
        "N/A",
        "Pendiente de documento",
        "Urgente",
        "Generación E",
        "Consultar en sistema"
      };

      Subjects = new string[]
      {
        "Algebra lineal",
        "Programacion I",
        "Bases de datos",
        "Redes",
        "Ingenieria de software"
      };

      Careers = new string[]
      {
        "Ingenieria en sistemas",
        "Administracion",
        "Contabilidad",
        "Medicina",
        "Ingenieria electronica"
      };

      Dates = new string[]
      {
        "2020/01/15",
        "2020/04/27",
        "2020/02/18",
        "2020/03/30",
        "2020/01/11"
      };

      PaymentMethods = new string[]
      {
        "Paypal",
        "Efecty",
        "Ventanilla",
        "Transferencia",
        "PSE"
      };

      Reasons = new string[]
      {
        "Cambio de carrera",
        "Personal",
        "Insolvencia"
      };
    }
    #endregion

    /// <summary>
    /// Elimina todos los archivos en los directorios antes de empezar
    /// </summary>
    private void CleanDirs()
    {
      string[] dirs = new string[]
      {
        Directories.COMMONPATH,
        Directories.FILESPATH,
        Directories.SOLCANMAPATH,
        Directories.SOLCREESPATH,
        Directories.SOLGRAPATH,
        Directories.SOLIPATH,
        Directories.SOLMAACPATH,
        Directories.SOLMAFIPATH,
        Directories.OUTSOLCANMAPATH,
        Directories.OUTSOLCREESPATH,
        Directories.OUTSOLGRAPATH,
        Directories.OUTSOLIPATH,
        Directories.OUTSOLMAACPATH,
        Directories.OUTSOLMAFIPATH,
        Directories.OUTLOGPATH,
      };

      foreach(string dir in dirs)
      {
        DirectoryInfo info = new DirectoryInfo(dir);

        foreach (FileInfo file in info.GetFiles())
        {
          file.Delete();
        }
      }
    }

    /// <summary>
    /// Llama todos los métodos para generar los diferentes tipos de archivo CSV
    /// </summary>
    public void GenerateDocs()
    {
      CleanDirs();

      GenerateCSVSOLI();
      GenerateCSVMAFI();
      GenerateCSVMAAC();
      GenerateCSVSOLGRA();
      GenerateCSVCREES();
      GenerateCSVCANMA();
    }

    /// <summary>
    /// Genera archivos CSV random de solicitud de inscripción
    /// </summary>
    private void GenerateCSVSOLI()
    {
      string TipoArchivo = FileTypes.SOLI;

      for(int i = 0; i < 10; i++)
      {
        StringBuilder builder = new StringBuilder();

        string headers = "SOLI_Nombres,SOLI_Apellidos,SOLI_Tipo_documento,SOLI_Numero_documento,SOLI_Observaciones,SOLI_Tipo_archivo";
        string newLine = string.Format("{0},{1},{2},{3},{4},{5}",
        Names[Rnd.Next(Names.Length - 1)],
        Lastnames[Rnd.Next(Lastnames.Length - 1)],
        DocTypes[Rnd.Next(DocTypes.Length - 1)],
        DocNumbers[Rnd.Next(DocNumbers.Length - 1)],
        Observations[Rnd.Next(Observations.Length - 1)],
        TipoArchivo);

        builder.Append(headers);
        builder.Append("\n");
        builder.Append(newLine);

        string filePath = string.Concat(FilesPath, "/Solicitud de inscripción " + i.ToString() + ".csv");
        File.WriteAllText(filePath, builder.ToString());
      }
    }

    /// <summary>
    /// Genera archivos CSV random de solicitud de matrícula financiera
    /// </summary>
    private void GenerateCSVMAFI()
    {
      string TipoArchivo = FileTypes.MAFI;

      for (int i = 0; i < 10; i++)
      {
        StringBuilder builder = new StringBuilder();

        string headers = "MAFI_Nombres,MAFI_Apellidos,MAFI_Tipo_documento,MAFI_Numero_documento,MAFI_Observaciones,MAFI_Fecha_pago,MAFI_Medio_pago,MAFI_Tipo_archivo";
        string newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
        Names[Rnd.Next(Names.Length - 1)],
        Lastnames[Rnd.Next(Lastnames.Length - 1)],
        DocTypes[Rnd.Next(DocTypes.Length - 1)],
        DocNumbers[Rnd.Next(DocNumbers.Length - 1)],
        Observations[Rnd.Next(Observations.Length - 1)],
        Dates[Rnd.Next(Dates.Length - 1)],
        PaymentMethods[Rnd.Next(PaymentMethods.Length - 1)],
        TipoArchivo);

        builder.Append(headers);
        builder.Append("\n");
        builder.Append(newLine);

        string filePath = string.Concat(FilesPath, "/Solicitud de matricula financiera " + i.ToString() + ".csv");
        File.WriteAllText(filePath, builder.ToString());
      }
    }

    /// <summary>
    /// Genera archivos CSV random de solicitud de matrícula académica
    /// </summary>
    private void GenerateCSVMAAC()
    {
      string TipoArchivo = FileTypes.MAAC;

      for (int i = 0; i < 10; i++)
      {
        StringBuilder builder = new StringBuilder();

        string headers = "MAAC_Nombres,MAAC_Apellidos,MAAC_Tipo_documento,MAAC_Numero_documento,MAAC_Observaciones,MAAC_Materia 1,MAAC_Materia 2,MAAC_Materia 3,MAAC_Tipo_archivo";
        string newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
        Names[Rnd.Next(Names.Length - 1)],
        Lastnames[Rnd.Next(Lastnames.Length - 1)],
        DocTypes[Rnd.Next(DocTypes.Length - 1)],
        DocNumbers[Rnd.Next(DocNumbers.Length - 1)],
        Observations[Rnd.Next(Observations.Length - 1)],
        Subjects[Rnd.Next(Subjects.Length - 1)],
        Subjects[Rnd.Next(Subjects.Length - 1)],
        Subjects[Rnd.Next(Subjects.Length - 1)],
        TipoArchivo);

        builder.Append(headers);
        builder.Append("\n");
        builder.Append(newLine);

        string filePath = string.Concat(FilesPath, "/Solicitud de matricula academica " + i.ToString() + ".csv");
        File.WriteAllText(filePath, builder.ToString());
      }
    }

    /// <summary>
    /// Genera archivos CSV random de solicitud de graduación
    /// </summary>
    private void GenerateCSVSOLGRA()
    {
      string TipoArchivo = FileTypes.SOLGRA;

      for (int i = 0; i < 10; i++)
      {
        StringBuilder builder = new StringBuilder();

        string headers = "SOLGRA_Nombres,SOLGRA_Apellidos,SOLGRA_Tipo_documento,SOLGRA_Numero_documento,SOLGRA_Observaciones,SOLGRA_Fecha_ultimo_semestre,SOLGRA_Promedio_final,SOLGRA_Tipo_archivo";
        string newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
        Names[Rnd.Next(Names.Length - 1)],
        Lastnames[Rnd.Next(Lastnames.Length - 1)],
        DocTypes[Rnd.Next(DocTypes.Length - 1)],
        DocNumbers[Rnd.Next(DocNumbers.Length - 1)],
        Observations[Rnd.Next(Observations.Length - 1)],
        Dates[Rnd.Next(Dates.Length - 1)],
        Rnd.Next(1, 5),
        TipoArchivo);

        builder.Append(headers);
        builder.Append("\n");
        builder.Append(newLine);

        string filePath = string.Concat(FilesPath, "/Solicitud de graduacion " + i.ToString() + ".csv");
        File.WriteAllText(filePath, builder.ToString());
      }
    }

    /// <summary>
    /// Genera archivos CSV random de solicitud de creación de estudiante
    /// </summary>
    private void GenerateCSVCREES()
    {
      string TipoArchivo = FileTypes.CREES;

      for (int i = 0; i < 10; i++)
      {
        StringBuilder builder = new StringBuilder();

        string headers = "CREES_Nombres,CREES_Apellidos,CREES_Tipo_documento,CREES_Numero_documento,CREES_Observaciones,CREES_Carrera,CREES_Tipo_archivo";
        string newLine = string.Format("{0},{1},{2},{3},{4},{5},{6}",
        Names[Rnd.Next(Names.Length - 1)],
        Lastnames[Rnd.Next(Lastnames.Length - 1)],
        DocTypes[Rnd.Next(DocTypes.Length - 1)],
        DocNumbers[Rnd.Next(DocNumbers.Length - 1)],
        Observations[Rnd.Next(Observations.Length - 1)],
        Careers[Rnd.Next(Careers.Length - 1)],
        TipoArchivo);

        builder.Append(headers);
        builder.Append("\n");
        builder.Append(newLine);

        string filePath = string.Concat(FilesPath, "/Solicitud de creacion estudiante " + i.ToString() + ".csv");
        File.WriteAllText(filePath, builder.ToString());
      }
    }

    /// <summary>
    /// Genera archivos CSV random de solicitud de cancelación de matrícula
    /// </summary>
    private void GenerateCSVCANMA()
    {
      string TipoArchivo = FileTypes.CANMA;

      for (int i = 0; i < 10; i++)
      {
        StringBuilder builder = new StringBuilder();

        string headers = "CANMA_Nombres,CANMA_Apellidos,CANMA_Tipo_documento,CANMA_Numero_documento,CANMA_Observaciones,CANMA_Carrera,CANMA_Motivo,CANMA_Tipo_archivo";
        string newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
        Names[Rnd.Next(Names.Length - 1)],
        Lastnames[Rnd.Next(Lastnames.Length - 1)],
        DocTypes[Rnd.Next(DocTypes.Length - 1)],
        DocNumbers[Rnd.Next(DocNumbers.Length - 1)],
        Observations[Rnd.Next(Observations.Length - 1)],
        Careers[Rnd.Next(Careers.Length - 1)],
        Reasons[Rnd.Next(Reasons.Length - 1)],
        TipoArchivo);

        builder.Append(headers);
        builder.Append("\n");
        builder.Append(newLine);

        string filePath = string.Concat(FilesPath, "/Solicitud de cancelacion matricula " + i.ToString() + ".csv");
        File.WriteAllText(filePath, builder.ToString());
      }
    }
  }
}
