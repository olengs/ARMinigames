using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelselectmanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToMazeGame(int level)
    {
        PlayerPrefs.SetString("mazename", "maze" + level.ToString());
        SceneManager.LoadScene("MazeGame", LoadSceneMode.Single);
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void toinstructions()
    {
        SceneManager.LoadScene("MazeInstructions");
    }
}
