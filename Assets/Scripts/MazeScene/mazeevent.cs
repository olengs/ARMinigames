using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mazeevent : MonoBehaviour
{
    public delegate void Win();
    public Win winevent;

    public static mazeevent instance;

    private void Awake()
    {
        instance = this;
    }
}
