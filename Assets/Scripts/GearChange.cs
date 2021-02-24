using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class GearChange : MonoBehaviour
{
  

    [SerializeField]
    Canvas canvas;

    [SerializeField]
    GameObject gearWorldPrefab;
    [SerializeField]
    GameObject gearHudPrefab;

    Vector3 worldPosition;

void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GearWorld") && collision.GetComponent<DragDropWorld>().change)
        {           
            StartCoroutine(CreateGearUI(collision));           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        worldPosition = new Vector3(worldPosition.x, worldPosition.y, 0);
        if (collision.CompareTag("GearUI") && collision.GetComponent<DragDrop>().change)
        {
         
                StartCoroutine(CreateGearWorld(collision));         
         }
        
       
    }

    IEnumerator CreateGearWorld(Collider2D collision)
    {
        yield return new WaitForSeconds(0.05f);
        if (collision.GetComponent<DragDrop>().change)
        {
            worldPosition = new Vector3(worldPosition.x, worldPosition.y, 0);
            GameObject gearWorld = Instantiate(gearWorldPrefab, worldPosition, Quaternion.identity);
            gearWorld.GetComponent<GearInfo>().color = collision.GetComponent<GearInfo>().color;
            gearWorld.GetComponent<SpriteRenderer>().color = collision.GetComponent<GearInfo>().color;        
            gearWorld.GetComponent<DragDropWorld>().OnMouseDown();
            Destroy(collision.gameObject);

        }
    }

    IEnumerator CreateGearUI(Collider2D collision)
    {
        yield return new WaitForSeconds(0.05f);
        if (collision.GetComponent<DragDropWorld>().change)
        {
            worldPosition = new Vector3(worldPosition.x, worldPosition.y, 0);
            GameObject gearHud = Instantiate(gearHudPrefab, worldPosition, Quaternion.identity);

            gearHud.GetComponent<GearInfo>().color = collision.GetComponent<GearInfo>().color;
            gearHud.GetComponent<Image>().color = collision.GetComponent<GearInfo>().color;
            gearHud.transform.SetParent(canvas.transform);
            gearHud.GetComponent<RectTransform>().localScale = new Vector3(0.5586998f, 0.5586998f, 0.5586998f);
            Destroy(collision.gameObject);


        }
        
    }

    
}
