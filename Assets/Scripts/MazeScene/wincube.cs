using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wincube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name + " " + other.gameObject.tag);
        if(other.gameObject.tag == "ball")
        { 
            mazeevent.instance.winevent?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
