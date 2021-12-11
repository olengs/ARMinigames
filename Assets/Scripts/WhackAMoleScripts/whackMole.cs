using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class whackMole : MonoBehaviour
{
    public Camera arcamera;

    public WAMGame game;

    public GameObject blood;

    private void Start()
    {
        blood.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!game.gameActive)
            return;

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = arcamera.ScreenPointToRay(touch.position);
                RaycastHit[] hitobject;
                hitobject = Physics.RaycastAll(ray, 1000f);
                foreach(var obj in hitobject)
                {
                    if(obj.transform.tag == "mole")
                    {
                        Debug.Log("slime if success");
                        if (!obj.transform.gameObject.GetComponent<slimeController>())
                        {
                            Debug.Log("controller is not here");
                        }
                        obj.transform.gameObject.GetComponent<slimeController>().getHit();
                        game.score += 10;
                    }
                    if(obj.transform.tag == "turtle")
                    {
                        Debug.Log("turtle if success");
                        if (!obj.transform.gameObject.GetComponent<slimeController>())
                        {
                            Debug.Log("controller is not here");
                        }
                        obj.transform.gameObject.GetComponent<slimeController>().getHit();
                        game.score -= 10;
                        blood.SetActive(true);
                    }
                }
            }
        }
    }
}
