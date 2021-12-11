using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

using JC_COMMON_FUNCS;

[RequireComponent(typeof(ARRaycastManager))]
public class SpawnMole : MonoBehaviour
{
    public GameObject mole;
    public GameObject turtle;

    private ARRaycastManager ARRaycastManager;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private static float cooldown = 0.7f;

    private static float time;

    public WAMGame game;

    // Start is called before the first frame update
    void Start()
    {
        ARRaycastManager = GetComponent<ARRaycastManager>();
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!game.gameActive)
            return;

        time += Time.deltaTime;

        float x, y;


        if (time > cooldown)
        {
            bool spawn = false;
            for (int i = 0; i < 10; ++i)
            {
                x = Random.Range(-Screen.width * 0.5f, Screen.width * 0.5f);
                y = Random.Range(-Screen.height * 0.5f, Screen.height * 0.5f);
                if (ARRaycastManager.Raycast(new Vector2(x, y), hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                {
                    spawn = true;
                    var hitpos = hits[0].pose;
                    Instantiate(JCCommonFuncs.randomBool(0.7f) ? mole : turtle, hitpos.position, Quaternion.identity);
                    time = 0.0f;
                    break;
                }
            }
            if (!spawn)
            {
                time = cooldown;
            }
        }


    }
}
