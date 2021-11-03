using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class picture_control : MonoBehaviour, IScrollHandler, IDragHandler, IBeginDragHandler
{
    public float pre_x;
    public float pre_y;
    public float speed;
    public void OnScroll(PointerEventData eventData)
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
            transform.localScale += Vector3.one * Time.deltaTime * speed;
        else if (Input.GetAxis("Mouse ScrollWheel") < 0&& transform.localScale.x > 0.5)
            transform.localScale -= Vector3.one * Time.deltaTime * speed;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dir = new Vector2(transform.position.x + eventData.position.x - pre_x, transform.position.y + eventData.position.y - pre_y);
        transform.position = dir;
        pre_x = eventData.position.x;
        pre_y = eventData.position.y;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        pre_x = eventData.position.x;
        pre_y = eventData.position.y;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
