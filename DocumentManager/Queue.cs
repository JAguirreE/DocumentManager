namespace DocumentManager
{
  public class Queue
  {
    private Node Tail;

    /// <summary>
    /// Verifica si la lista está vacía
    /// </summary>
    /// <returns>Verdadero o false según el caso</returns>
    public bool IsEmptyList()
    {
      if (Tail == null)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// Adiciona un elemento
    /// </summary>
    /// <param name="element">Elemento a adicionar</param>
    public void Enqueue(string element, string fileType, string filePath) 
    {
      Node newNode = new Node
      {
        CanonicalXML = element,
        FileType = fileType,
        FilePath = filePath
      };

      if (IsEmptyList())
      {
        Tail = newNode;
      }
      else
      {
        newNode.Next = Tail;
        Tail = newNode;
      }
    }

    /// <summary>
    /// Saca el primer elemento de la cola y lo retorna
    /// </summary>
    /// <returns>Primer elemento de la cola</returns>
    public Node GetFirstInQueue()
    {
      Node actualNode = Tail;

      while(actualNode.Next != null)
      {
        actualNode = actualNode.Next;
      }

      actualNode.Previous.Next = null;
      return actualNode;
    }
  }
}
