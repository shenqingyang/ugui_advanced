using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pieces : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject center;
    public Transform old_parent;
    public Transform temp;

    public void OnBeginDrag(PointerEventData eventData)
    {
        old_parent = transform.parent;
        temp.position = transform.position;
        temp.rotation = transform.rotation;
        transform.SetParent(transform.parent.parent.parent);
        transform.position = eventData.position;
        Vector2 direction = center.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
        GetComponent<CanvasGroup>().blocksRaycasts = false;

    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        Vector2 direction = center.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.tag == "piece") //��⵽Ŀ�����ΪImage
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position; //�������λ�ñ��Ŀ������׵�λ��
            transform.rotation = eventData.pointerCurrentRaycast.gameObject.transform.rotation;
            eventData.pointerCurrentRaycast.gameObject.transform.SetParent(old_parent);
            eventData.pointerCurrentRaycast.gameObject.transform.position = temp.position; //��Ŀ������λ�ñ�ɳ�ʼ���׵�λ��
            eventData.pointerCurrentRaycast.gameObject.transform.rotation = temp.rotation;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        else if (eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.tag == "circle") //��⵽Ŀ�����ΪItem
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position; //���˶����λ����ΪĿ������λ��
            transform.rotation = eventData.pointerCurrentRaycast.gameObject.transform.rotation;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }else if (eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.tag == "back")
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.Find("Content"));
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        else {
            transform.position = temp.position;
            transform.rotation = temp.rotation;
        }
        transform.SetParent(old_parent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;

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
