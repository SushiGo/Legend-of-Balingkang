using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour {

    public GameObject panelBuang;
    public GameObject[] panelMore;
    public GameObject player;
    public GameObject equip;
    public GameObject btnUnequip;

    private Player playerScript;

    void Awake()
    {
        playerScript = player.GetComponent<Player>();
    }

    public void SlotNum(int i)
    {
        var panelBuangHandler = panelBuang.GetComponent<PanelBuangHandler>();
        panelBuangHandler.slotIndex = i;
    }

    public void SlotItemClicked(int slotIdx)
    {
        //Tutup panel more yang lagi active
        for(int i=0; i<5; i++)
        {
            if(i == slotIdx)
            {
                panelMore[i].SetActive(!panelMore[i].activeSelf);
            }
            else
            {
                panelMore[i].SetActive(false);
            }
        }

        //Tutup panel buang jika active
        if(panelBuang.activeSelf)
        {
            panelBuang.SetActive(false);
        }

        //Enable tombol "Pakai" jika item bisa di equip, disable jika item tidak bisa di equip
        if(panelMore[slotIdx].activeSelf)
        {
            if (playerScript.inventoryName[slotIdx] == "Torch" || playerScript.inventoryName[slotIdx] == "Axe")
            {
                GameObject.Find("BtnPakai").GetComponent<Button>().interactable = true;
            }
            else
            {
                GameObject.Find("BtnPakai").GetComponent<Button>().interactable = false;
            }
        }
    }

    public void EquipItem(int slotIdx)
    {
        equip.SetActive(true);
        playerScript.durability = 100;
        equip.GetComponent<Image>().sprite = playerScript.inventory[slotIdx].GetComponent<Image>().sprite;
        equip.GetComponentInChildren<Text>().text = playerScript.durability.ToString() + "%";

        playerScript.inventoryCount.RemoveAt(slotIdx);
        playerScript.inventoryName.RemoveAt(slotIdx);
        playerScript.ShowInventory();
        playerScript.CountInventory();

        equip.GetComponentInChildren<Text>().text = "100%";

        btnUnequip.GetComponent<Button>().interactable = true;
    }

    public void ChangeEquipBtnSpriteToNone()
    {
        equip.GetComponent<Image>().sprite = null;
    }
}
