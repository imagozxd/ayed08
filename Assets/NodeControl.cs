using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    public List<NodeControl> listAllAdjacentes;
    public float peso = 5.0f;

    public NodeControl GetNextNode()
    {
        int index = Random.Range(0, listAllAdjacentes.Count);
        return listAllAdjacentes[index];
    }

}
