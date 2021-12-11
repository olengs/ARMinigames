using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeController : MonoBehaviour
{
    Animator animator;
    float count = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isHit", false);
    }

    public void getHit()
    {
        animator.SetBool("isHit", true);
    }

    private void Update()
    {
        count += Time.deltaTime;
        if(count > WAMGame.despawn_time)
        {
            Destroy(this.gameObject);
        }

        Vector3 dir = Camera.main.transform.position - transform.position;
        dir.y = 0;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
    }
}
