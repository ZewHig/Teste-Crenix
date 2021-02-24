using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResetGears : MonoBehaviour
{
    [SerializeField]
    Canvas canvas;

    [SerializeField]
    Color color1, color2, color3, color4, color5;

    GameObject[] listOfGears, listOfGears2;
    [SerializeField]
    GameObject gearUI, gearTemplet1, gearTemplet2, gearTemplet3, gearTemplet4, gearTemplet5;

    public void ResetGear()
    {
        listOfGears = GameObject.FindGameObjectsWithTag("GearWorld");
        listOfGears2 = GameObject.FindGameObjectsWithTag("GearUI");

        foreach (var item in listOfGears)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in listOfGears2)
        {
            
                Destroy(item.gameObject);

            
        }


        SpawnGear(gearTemplet1.GetComponent<RectTransform>(), color1);
        SpawnGear(gearTemplet2.GetComponent<RectTransform>(), color2);
        SpawnGear(gearTemplet3.GetComponent<RectTransform>(), color3);
        SpawnGear(gearTemplet4.GetComponent<RectTransform>(), color4);
        SpawnGear(gearTemplet5.GetComponent<RectTransform>(), color5);


    }

    void SpawnGear(RectTransform position, Color color)
    {
        GameObject gearUIClone = Instantiate(gearUI);

        gearUIClone.transform.parent = (canvas.transform);
        gearUIClone.GetComponent<RectTransform>().sizeDelta = position.sizeDelta;
        gearUIClone.GetComponent<RectTransform>().localScale = position.localScale;
        gearUIClone.GetComponent<RectTransform>().position = position.position;

        gearUIClone.GetComponent<Image>().color = color;
        gearUIClone.GetComponent<GearInfo>().color = color;
    }
}
