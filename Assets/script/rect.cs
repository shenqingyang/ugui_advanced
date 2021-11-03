using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rect : MonoBehaviour
{
    public ScrollRect jjj;
    public float wait_time;
    public static float timmer;
    public static float num;
    public GameObject toggles;
    public static bool change;
    public float next;
    // Start is called before the first frame update
    void Start()
    {
        toggles.GetComponent<toggle>().Change();
        num = 0;
        next =0.25f;
        timmer = wait_time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!change) {
            if (timmer > 0)
            {
                timmer -= Time.deltaTime;
            }
            else
            {
                jjj.horizontalNormalizedPosition = Mathf.Lerp(jjj.horizontalNormalizedPosition, next, Time.deltaTime * 5);
                if (Mathf.Abs(jjj.horizontalNormalizedPosition - next) < 0.0005)
                {
                    num = (num == 1) ? 0 : num += 0.25f;
                    next = (num == 1) ? 0 : next = num+0.25f;
                    toggles.GetComponent<toggle>().Change();
                    timmer = wait_time;
                }
            }
        }
        else
        {
            jjj.horizontalNormalizedPosition = Mathf.Lerp(jjj.horizontalNormalizedPosition, num, Time.deltaTime * 10);
            if (Mathf.Abs(jjj.horizontalNormalizedPosition - num) < 0.0005)
            {
                next = (num == 1) ? 0 : next = num + 0.25f;
                timmer = wait_time;
                toggles.GetComponent<toggle>().Change();
                change = false;
            }

        }
    }
}
