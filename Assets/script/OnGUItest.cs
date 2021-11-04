using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGUItest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(10f,10f,50f,50f),"sb");
        if(GUI.Button(new Rect(50f, 50f, 100f, 100f), "DDW"))
        {
            Debug.Log("!");
        }
    }
}
