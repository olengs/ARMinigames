using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moleScript : MonoBehaviour
{
    public float lifetime;
    public static float maxlifetime = 1.5f;

    void Start()
    {
        lifetime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        if(lifetime > maxlifetime)
        {
            DestroyImmediate(this.gameObject);
        }
    }
}
