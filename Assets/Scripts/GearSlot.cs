using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearSlot : MonoBehaviour
{

    public bool isOccupied = false;

    enum Rotation
    {
        Right,
        Left
    };
    [SerializeField]
    Rotation direction;


    private void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("GearWorld") && collision.GetComponent<DragDropWorld>().isDragging == false && isOccupied == false)
        {
           
            collision.transform.position = transform.position;
            isOccupied = true;
            collision.GetComponent<RotateGear>().direction = (RotateGear.Rotation)direction;
            collision.GetComponent<RotateGear>().isIn = true;
        }

        if (collision.CompareTag("GearWorld") && collision.GetComponent<DragDropWorld>().isDragging && collision.GetComponent<RotateGear>().isIn == true)
        {
           
            collision.GetComponent<RotateGear>().isIn = false;
            isOccupied = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("GearWorld") )
        {

            
            if (collision.GetComponent<RotateGear>().isIn == true && isOccupied == true)
            {
                isOccupied = false;
                collision.GetComponent<RotateGear>().isIn = false;
            }

        }

        
    }


    



}
