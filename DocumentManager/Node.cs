namespace DocumentManager
{
  public class Node
  {
    public string CanonicalXML { get; set; }
    public string FileType { get; set; }
    public string FilePath { get; set; }
    public Node Previous { get; set; }
    public Node Next { get; set; }
  }
}
