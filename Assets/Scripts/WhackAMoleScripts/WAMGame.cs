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

    public bool gameActive { get; set; }

    public static float despawn_time = 2f;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        gametime = 20.0f;
        gameActive = false;
        finalscoretext.transform.parent.gameObject.SetActive(false);
        scoretext.transform.parent.gameObject.SetActive(true);
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
            }
            return;
        }

        gametime -= Time.deltaTime;

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
