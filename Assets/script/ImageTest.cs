using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTest : MonoBehaviour
{
    private RawImage ri;
    private float w, h;
    // Start is called before the first frame update
    void Start()
    {
        w = 50;
        h = w;
        ri = this.GetComponent<RawImage>();
        ri.uvRect = new Rect(0, 0, w, h);
    }

    // Update is called once per frame
    void Update()
    {
        if (ri.uvRect.width != 1)
        {
            w -= 1;
            h -= 1;
            ri.uvRect = new Rect(0, 0, w, h);
        }
    }
}
