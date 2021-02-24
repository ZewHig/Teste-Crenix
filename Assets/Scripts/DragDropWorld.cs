using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropWorld : MonoBehaviour
{
    private float startPosX;
    private float startPosY;

    public bool isDragging;
    public bool change = false;
    public void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - transform.localPosition.x;
            startPosY = mousePos.y - transform.localPosition.y;

            isDragging = true;

        }


    }

    public void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
           isDragging = false;
            change = false;
        }
    }
    void Update()
    {
        if (isDragging)
        {
            change = true;
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, 0);
        }
    }
}
