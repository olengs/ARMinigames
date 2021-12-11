using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARAnchorManager))]
public class spawnDisplayObject : MonoBehaviour
{
    ARAnchorManager aranchormanager;
    ARRaycastManager arraycastmanager;
    Camera arcamera;
    public ARPlane arplane;
    public GameObject[] objects;
    int currindex = 0;

    static float displacement = 10f;

    public Text objectname;
    public Text spawnablehelp;

    public GameObject currselected = null;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    // Start is called before the first frame update
    void Start()
    {
        aranchormanager = GetComponent<ARAnchorManager>();
        arraycastmanager = GetComponent<ARRaycastManager>();
        arcamera = Camera.main;
        spawnablehelp.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        objectname.text = objects[currindex].name;
    }

    public void SpawnObj()
    {
        Vector3 dir = arcamera.transform.forward;
        Vector3 rot = -dir;
        rot.y = 0;

        if (arraycastmanager.Raycast(new Vector2(Screen.width * 0.5f, Screen.height * 0.5f), hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            var hitpos = hits[0].pose;
            GameObject go = Instantiate(objects[currindex], hitpos.position, Quaternion.identity);
            currselected = go;
            spawnablehelp.gameObject.SetActive(false);
        }
        else
        {
            spawnablehelp.gameObject.SetActive(true);
        }
    }

    public void leftarrow()
    {
        if(currindex > 0)
        {
            --currindex;
        }
        
    }

    public void rightarrow()
    {
        if (currindex < objects.Length - 1)
        {
            ++currindex;
        }
    }

    public void rotateleft()
    {
        if(currselected)
            currselected.transform.Rotate(0, -1f, 0);
    }

    public void rotateright()
    {
        if (currselected)
            currselected.transform.Rotate(0, 1f, 0);
    }


}
