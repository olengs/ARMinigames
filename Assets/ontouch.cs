using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ontouch : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool left;
    public spawnDisplayObject rotate;
    public bool isdown = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        isdown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isdown = false;
    }

    private void Update()
    {
        if (isdown)
        {
            if (left)
                rotate.rotateleft();
            else
                rotate.rotateright();
        }
    }
}
