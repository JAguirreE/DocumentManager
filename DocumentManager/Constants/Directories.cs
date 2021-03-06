﻿using System;
using System.Collections;
using System.IO;

namespace DocumentManager.Constants
{
  public static class Directories
  {
    public static string FILESPATH = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).FullName + "\\files";
    public static string COMMONPATH = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).FullName + "\\common";
    public static string OUTLOGPATH = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).FullName + "\\OUT_LOG";

    public static string SOLCANMAPATH = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).FullName + "\\XML_SOLCANMA";
    public static string SOLCREESPATH = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).FullName + "\\XML_SOLCREES";
    public static string SOLGRAPATH = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).FullName + "\\XML_SOLGRA";
    public static string SOLIPATH = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).FullName + "\\XML_SOLI";
    public static string SOLMAACPATH = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).FullName + "\\XML_SOLMAAC";
    public static string SOLMAFIPATH = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).FullName + "\\XML_SOLMAFI";

    public static string OUTSOLCANMAPATH = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).FullName + "\\OUT_SOLCANMA";
    public static string OUTSOLCREESPATH = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).FullName + "\\OUT_SOLCREES";
    public static string OUTSOLGRAPATH = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).FullName + "\\OUT_SOLGRA";
    public static string OUTSOLIPATH = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).FullName + "\\OUT_SOLI";
    public static string OUTSOLMAACPATH = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).FullName + "\\OUT_SOLMAAC";
    public static string OUTSOLMAFIPATH = Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName).FullName + "\\OUT_SOLMAFI";
  }
}
