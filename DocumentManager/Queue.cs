using System;

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
      return Tail == null;
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
        Tail.Previous = newNode;
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

      if(actualNode != null)
      {
        while (actualNode.Next != null)
        {
          actualNode = actualNode.Next;
        }

        if(actualNode.Previous != null)
        {
          actualNode.Previous.Next = null;
        }
      }

      return actualNode;
    }

    public void Count()
    {
      Node actualNode = Tail;
      int counter = 0;
      while (actualNode.Next != null)
      {
        counter++;
      }
      Console.WriteLine(counter);
    }
  }
}
