using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

public class CircularDoublyLinkedList : MonoBehaviour
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
    
    [SerializeField]
    private GameObject[] nodos;
    private Node Head;
    private int capacity = 0;



    //CircularDoublyLinkedList<int> circularLinkedList = new CircularDoublyLinkedList<int>();
    //CircularDoublyLinkedList circularLinkedList = new CircularDoublyLinkedList();



    void Start()
    {
        CircularDoublyLinkedList circularLinkedList = new CircularDoublyLinkedList();
        // Ejemplos de cómo insertar nodos al principio y al final
        circularLinkedList.InsertNodeAtStart(3);
        circularLinkedList.InsertNodeAtStart(8);
        circularLinkedList.InsertNodeAtStart(7);
        circularLinkedList.InsertNodeAtEnd(4);

        // Imprimir los nodos en la consola
        circularLinkedList.PrintAllNode();

        //GetNextNode();
    }

    // Puedes usar Update para realizar operaciones continuas si es necesario
    void Update()
    {
        // Por ejemplo, podrías agregar aquí la lógica de actualización de tus nodos
    }
    public void InsertNodeAtStart(int value)
    {
        if (Head == null)
        {
            Node newNode = new Node(value);
            newNode.Next = newNode;
            newNode.Previous = newNode;
            Head = newNode;
            capacity++;
        }
        else
        {
            Node newNode = new Node(value);
            newNode.Next = Head;
            newNode.Previous = Head.Previous;
            Head.Previous.Next = newNode;
            Head.Previous = newNode;
            Head = newNode;
            capacity++;
        }
    }
    public void InsertNodeAtEnd(int value)
    {
        if (Head == null)
        {
            InsertNodeAtStart(value);
        }
        else
        {
            Node newNode = new Node(value);
            newNode.Next = Head;
            newNode.Previous = Head.Previous;
            Head.Previous.Next = newNode;
            Head.Previous = newNode;
            capacity++;
        }
    }
    public void PrintAllNode()
    {
        Node tmp = Head;
        Debug.Log(tmp.Value + " ");
        tmp = tmp.Next;
        while (tmp != Head)
        {
            Debug.Log(tmp.Value + " ");
            tmp = tmp.Next;
        }
        Debug.Log("");
    }

    public Node GetNextNode()
    {
        int index = Random.Range(0, capacity);
        Node currentNode = Head;

        for (int i = 0; i < index; i++)
        {
            currentNode = currentNode.Next;
        }
        Debug.Log("dentro de GetNextNode");
        return currentNode;
    }
}

