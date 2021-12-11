using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bloodcontroller : MonoBehaviour
{
    float count = 0f;
    Image self;

    private void OnEnable()
    {
        count = 0f;
        self = GetComponent<Image>();
        self.color = new Color(self.color.r, self.color.g, self.color.b, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        self.color = new Color(self.color.r, self.color.g, self.color.b, Mathf.Clamp(1 - count * 0.5f, 0f, 1f));
        if(count >= 1f)
        {
            this.gameObject.SetActive(false);
        }
    }
}
