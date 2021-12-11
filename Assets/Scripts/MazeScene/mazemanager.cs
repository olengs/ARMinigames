using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mazemanager : MonoBehaviour
{
    GameObject ball;
    public GameObject ballprefab;
    float timetaken = 0.0f;
    public Text timetakentext;

    public GameObject winUI;
    public Text winUItext;

    string mazename;
    bool countingtime = false;

    public string[] mazenames;

    private void OnDestroy()
    {
        mazeevent.instance.winevent -= win;
        Debug.Log("win desubscribed");
    }

    private void Start()
    {
        mazeevent.instance.winevent += win;
        Debug.Log("win subscribed");
        countingtime = true;
        mazename = PlayerPrefs.GetString("mazename");
        winUI.SetActive(false);
    }

    public void win()
    {
        Debug.Log("Win!!!!");
        winUI.SetActive(true);
        countingtime = false;
        winUItext.text = "Time Taken: " + string.Format("{0:00}:{1:00}:{2:00}", Mathf.Floor(timetaken / 60), timetaken % 60, (timetaken - Mathf.Floor(timetaken)) * 60);

    }

    // Update is called once per frame
    void Update()
    {
        if(countingtime)
            timetaken += Time.deltaTime;
        timetakentext.text = "Time Taken: " + string.Format("{0:00}:{1:00}:{2:00}", Mathf.Floor(timetaken / 60), timetaken % 60, (timetaken - Mathf.Floor(timetaken)) * 60);
    }

    public void MoveBallToStart()
    {
        GameObject origin = GameObject.Find("maze1");
        ball = Instantiate(ballprefab, origin.transform);
        var tempball = origin.GetComponentInChildren<tempballpos>();
        ball.transform.position = tempball.transform.position;
    }

    public void Destroyball()
    {
        Destroy(ball);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("levelselect", LoadSceneMode.Single);
    }
}
