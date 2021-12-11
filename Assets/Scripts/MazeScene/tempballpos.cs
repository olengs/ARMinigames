using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempballpos : MonoBehaviour
{
    public Vector3 position { get; private set; }

    public GameObject Maze;


    private void Update()
    {
        position = transform.position;
    }
}
