using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RotateStates : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;

    public static bool activeGears = false;

    public GameObject[] listaDeSlots;

    private void Update()
    {

        VerifySlots();

        if (activeGears)
        {
            text.text = "YAY, PARABÉNS," +
                        "TASK CONCLUÍDA!";
        }
        else
        {
            text.text = "ENCAIXE AS ENGRNAGENS  EM QUALQUER ORDEM!";

        }
    }
    public void VerifySlots()
    {
        if (listaDeSlots[0].GetComponent<GearSlot>().isOccupied == true && listaDeSlots[1].GetComponent<GearSlot>().isOccupied == true && listaDeSlots[2].GetComponent<GearSlot>().isOccupied == true && listaDeSlots[3].GetComponent<GearSlot>().isOccupied == true && listaDeSlots[4].GetComponent<GearSlot>().isOccupied == true)
        {
            activeGears = true;
        }
        else
        {
            activeGears = false;
        }
    }
}
