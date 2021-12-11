using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;

public class MainMenuManager : MonoBehaviour
{

    public void ToWhackMoleScene()
    {
        SceneManager.LoadScene("MoleInstructions");
    }

    public void toLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void to3DViewer()
    {
        var xrManagerSettings = XRGeneralSettings.Instance.Manager;
        xrManagerSettings.DeinitializeLoader();
        SceneManager.LoadScene("AnchorScene", LoadSceneMode.Single); //Load another AR scene
        xrManagerSettings.InitializeLoaderSync();
    }
}
