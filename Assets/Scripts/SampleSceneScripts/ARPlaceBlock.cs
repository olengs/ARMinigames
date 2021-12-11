using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class ARPlaceBlock : MonoBehaviour
{
    public GameObject placedPrefab;

    private ARRaycastManager ARRaycastManager;

    private ARPlaneManager ARPlaneManager;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        ARRaycastManager = GetComponent<ARRaycastManager>();
        ARPlaneManager = GetComponent<ARPlaneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                var touchpos = touch.position;

                if(ARRaycastManager.Raycast(touchpos, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                {
                    var hitpos = hits[0].pose;
                    Instantiate(placedPrefab, hitpos.position, hitpos.rotation);
                }
            }
        }
    }
}
