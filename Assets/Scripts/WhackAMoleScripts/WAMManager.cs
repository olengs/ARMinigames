using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class WAMManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColorOnHold(Button b)
    {
        ColorBlock color = b.colors;
        color.normalColor = Color.cyan;
        b.colors = color;
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        LoaderUtility.Deinitialize();
    }
}
