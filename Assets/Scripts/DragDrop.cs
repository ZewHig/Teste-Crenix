using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragDrop : MonoBehaviour,IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public bool change = false;
    [SerializeField]
    Canvas canvas;

    RectTransform rectTransform;
    CanvasGroup canvasGroup;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = FindObjectOfType<Canvas>();
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin");
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Ondrag");
        change = true;
        rectTransform.anchoredPosition += eventData.delta/ canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        change = false;
        Debug.Log("End");
        canvasGroup.blocksRaycasts = true;
    }

    
}
