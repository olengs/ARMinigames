using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]
public class WAMGame : MonoBehaviour
{
    public int score { get; set; }
    private float gametime { get; set; }

    [Header("gameUI")]
    public Text scoretext;
    public Text timetext;
    [Header("EndUI")]
    public Text finalscoretext;

    public ARPlaneManager arPlaneManager;

    public Text findingPlaneText;
    public Text planeFound;
    public float planeFoundTime;

    public bool gameActive { get; set; }

    public static float despawn_time = 2f;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        planeFoundTime = 0;
        gametime = 20.0f;
        gameActive = false;
        finalscoretext.transform.parent.gameObject.SetActive(false);
        scoretext.transform.parent.gameObject.SetActive(true);
        planeFound.gameObject.SetActive(false);
        findingPlaneText.gameObject.SetActive(true);

        arPlaneManager = GetComponent<ARPlaneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameActive)
        {
            if(arPlaneManager.trackables.count > 0)
            {
                gameActive = true;
                planeFound.gameObject.SetActive(true);
                findingPlaneText.gameObject.SetActive(false);
                planeFoundTime = 0f;
            }
            return;
        }

        gametime -= Time.deltaTime;
        planeFoundTime += Time.deltaTime;

        if(planeFoundTime > 1.5f)
        {
            planeFound.gameObject.SetActive(false);
        }

        if (gametime < 0)
        {
            gameActive = false;
            GameObject[] gos = GameObject.FindGameObjectsWithTag("mole");
            foreach(var go in gos)
            {
                DestroyImmediate(go);
            }
            finalscoretext.transform.parent.gameObject.SetActive(true);
            scoretext.transform.parent.gameObject.SetActive(false);
            finalscoretext.text = "Your Final Score is " + score;
        }

        scoretext.text = "Score: " + score;
        timetext.text = "Time left: " + gametime;
    }
}
