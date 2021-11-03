using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggle : MonoBehaviour
{
    public GameObject[] tog;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Change()
    {
        for (int i = 0; i < tog.Length; i++)
        {
            tog[i].GetComponent<Toggle>().isOn = false;
        }
        tog[(int)(rect.num * 4)].GetComponent<Toggle>().isOn = true;
    }

    public void TOG0()
    {
        if (rect.timmer > 0&&!rect.change)
        {
            rect.change = true;
            rect.num = 0;
        }
    }
    public void TOG1()
    {
        if (rect.timmer > 0 && !rect.change)
        {
            rect.change = true;
            rect.num = 0.25f;
        }
    }
    public void TOG2()
    {
        if (rect.timmer > 0 && !rect.change)
        {
            rect.change = true;
            rect.num = 0.5f;
        }
    }
    public void TOG3()
    {
        if (rect.timmer > 0 && !rect.change)
        {
            rect.change = true;
            rect.num = 0.75f;
        }
    }
    public void TOG4()
    {
        if (rect.timmer > 0 && !rect.change)
        {   
            rect.change = true;
            rect.num = 1f;
        }
    }
    public void UP()
    {

            rect.num =(rect.num == 1) ? 0 : rect.num += 0.25f;
            rect.change = true;
    }
    public void DOWN()
    {
        rect.num = (rect.num == 0) ? 1 : rect.num -= 0.25f;
        rect.change = true;
    }
}
