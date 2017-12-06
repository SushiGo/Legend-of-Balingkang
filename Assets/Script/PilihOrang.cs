using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PilihOrang : MonoBehaviour {

    public int jumlah = 0;
    public GameObject btnSelesai;

	public void SetPilih(bool value)
    {
        if(value == true)
        {
            jumlah++;
        }
        else
        {
            jumlah--;
        }

        if(jumlah == 3)
        {
            btnSelesai.GetComponent<Button>().interactable = true;
        }
        else
        {
            btnSelesai.GetComponent<Button>().interactable = false;
        }
    }
}
