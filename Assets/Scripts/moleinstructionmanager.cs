using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;

public class moleinstructionmanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tomolescreen()
    {
        var xrManagerSettings = XRGeneralSettings.Instance.Manager;
        xrManagerSettings.DeinitializeLoader();
        SceneManager.LoadScene("WhackAMole", LoadSceneMode.Single); //Load another AR scene
        xrManagerSettings.InitializeLoaderSync();
    }

    public void toback()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
