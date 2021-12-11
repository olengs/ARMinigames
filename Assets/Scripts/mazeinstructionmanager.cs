using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mazeinstructionmanager : MonoBehaviour
{
    public void Tolevelselect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
