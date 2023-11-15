using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerControl : MonoBehaviour
{
    public NodeControl currentNode;
    public CircularDoublyLinkedList otherCurrentNode;
    private Vector2 refVelocity;
    public float timeToMove;
    public float energy = 50.0f;
    public float exhaustedTime = 3.5f;
    private float currentExhaustedTime =0.0f;

    void Update()
    {
        if (currentExhaustedTime > 0)
        {
            currentExhaustedTime -= Time.deltaTime;
            if (currentExhaustedTime <= 0)
            {
                energy = 50.0f;
            }
        }
        else
        {
            transform.position = Vector2.SmoothDamp(transform.position, otherCurrentNode.transform.position, ref refVelocity, timeToMove);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Node")
        {
            print("impacto");
            currentNode = collision.gameObject.GetComponent<NodeControl>().GetNextNode();
            print("se ira al: " + currentNode);
            /*
            NodeControl nextNode = collision.gameObject.GetComponent<NodeControl>();
            print("medio: " + currentNode);
            print("nextNode: " + nextNode);
            float energyCost = nextNode.peso;
            if (energy >= energyCost)
            {
                energy -= energyCost;
                currentNode = nextNode;
            }
            else
            {
                currentExhaustedTime = exhaustedTime;
            }
            print("despues: "+currentNode);
            */
        }
    }
}
