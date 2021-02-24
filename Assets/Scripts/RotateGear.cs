using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGear : MonoBehaviour
{
    float rotationSpeed = 10f;

    public bool isIn = false;

    public enum Rotation
    {
        Right,
        Left
    };
    
    public Rotation direction;

    


    void FixedUpdate()
    {
        if (RotateStates.activeGears)
        {
            switch (direction)
            {
                case Rotation.Left:

                    transform.Rotate(0, 0, 1 * rotationSpeed * Time.deltaTime);
                    
                    break;

                case Rotation.Right:
                    
                    transform.Rotate(0, 0, -1 * rotationSpeed * Time.deltaTime);
                    break;
            }
        }
    }

   

    


}
