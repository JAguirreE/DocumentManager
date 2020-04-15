using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DocumentManager
{
  public class DocGenerator
  {
    #region Propiedades

    private readonly Random Rnd = new Random();
    private readonly string CommonPath = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).FullName + "\\common";

    private string[] Names = new string[] 
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

    private string[] Lastnames = new string[]
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

    private string[] DocTypes = new string[]
    {
      "CC",
      "PASAPORTE",
      "CE",
      "TI"
    };

    private string[] DocNumbers = new string[]
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

    private string[] Observations = new string[]
    {
      "N/A",
      "Pendiente de documento",
      "Urgente",
      "Generación E",
      "Consultar en sistema"
    };

    private string[] Subjects = new string[]
    {
      "Algebra lineal",
      "Programacion I",
      "Bases de datos",
      "Redes",
      "Ingenieria de software"
    };

    private string[] Careers = new string[]
    {
      "Ingenieria en sistemas",
      "Administracion",
      "Contabilidad",
      "Medicina",
      "Ingenieria electronica"
    };

    private string[] Dates = new string[]
    {
      "2020/01/15",
      "2020/04/27",
      "2020/02/18",
      "2020/03/30",
      "2020/01/11"
    };

    private string[] PaymentMethods = new string[]
    {
      "Paypal",
      "Efecty",
      "Ventanilla",
      "Transferencia",
      "PSE"
    };

    private string[] Reasons = new string[]
    {
      "Cambio de carrera",
      "Personal",
      "Insolvencia"
    };

    #endregion

    public DocGenerator() { }

    /// <summary>
    /// Llama todos los métodos para generar los diferentes tipos de archivo CSV
    /// </summary>
    public void GenerateDocs()
    {
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
      string TipoArchivo = "SOLI";

      for(int i = 0; i < 10; i++)
      {
        StringBuilder builder = new StringBuilder();

        string headers = "Nombres, Apellidos, Tipo documento, Numero documento, Observaciones, Tipo archivo";
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

        string filePath = string.Concat(CommonPath, "/Solicitud de inscripción " + i.ToString());
        File.WriteAllText(filePath, builder.ToString());
      }
    }

    /// <summary>
    /// Genera archivos CSV random de solicitud de matrícula financiera
    /// </summary>
    private void GenerateCSVMAFI()
    {
      string TipoArchivo = "MAFI";

      for (int i = 0; i < 10; i++)
      {
        StringBuilder builder = new StringBuilder();

        string headers = "Nombres, Apellidos, Tipo documento, Numero documento, Observaciones, Fecha pago, Medio pago, Tipo archivo";
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

        string filePath = string.Concat(CommonPath, "/Solicitud de matricula financiera " + i.ToString());
        File.WriteAllText(filePath, builder.ToString());
      }
    }

    /// <summary>
    /// Genera archivos CSV random de solicitud de matrícula académica
    /// </summary>
    private void GenerateCSVMAAC()
    {
      string TipoArchivo = "MAAC";

      for (int i = 0; i < 10; i++)
      {
        StringBuilder builder = new StringBuilder();

        string headers = "Nombres, Apellidos, Tipo documento, Numero documento, Observaciones, Materia 1, Materia 2, Materia 3, Tipo archivo";
        string newLine = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
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

        string filePath = string.Concat(CommonPath, "/Solicitud de matricula academica " + i.ToString());
        File.WriteAllText(filePath, builder.ToString());
      }
    }

    /// <summary>
    /// Genera archivos CSV random de solicitud de graduación
    /// </summary>
    private void GenerateCSVSOLGRA()
    {
      string TipoArchivo = "SOLGRA";

      for (int i = 0; i < 10; i++)
      {
        StringBuilder builder = new StringBuilder();

        string headers = "Nombres, Apellidos, Tipo documento, Numero documento, Observaciones, Fecha ultimo semestre, Promedio final, Tipo archivo";
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

        string filePath = string.Concat(CommonPath, "/Solicitud de graduacion " + i.ToString());
        File.WriteAllText(filePath, builder.ToString());
      }
    }

    /// <summary>
    /// Genera archivos CSV random de solicitud de creación de estudiante
    /// </summary>
    private void GenerateCSVCREES()
    {
      string TipoArchivo = "CREES";

      for (int i = 0; i < 10; i++)
      {
        StringBuilder builder = new StringBuilder();

        string headers = "Nombres, Apellidos, Tipo documento, Numero documento, Observaciones, Carrera, Tipo archivo";
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

        string filePath = string.Concat(CommonPath, "/Solicitud de creacion estudiante " + i.ToString());
        File.WriteAllText(filePath, builder.ToString());
      }
    }

    /// <summary>
    /// Genera archivos CSV random de solicitud de cancelación de matrícula
    /// </summary>
    private void GenerateCSVCANMA()
    {
      string TipoArchivo = "CANMA";

      for (int i = 0; i < 10; i++)
      {
        StringBuilder builder = new StringBuilder();

        string headers = "Nombres, Apellidos, Tipo documento, Numero documento, Observaciones, Carrera, Motivo, Tipo archivo";
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

        string filePath = string.Concat(CommonPath, "/Solicitud de cancelacion matricula " + i.ToString());
        File.WriteAllText(filePath, builder.ToString());
      }
    }

  }
}
