using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBuangHandler : MonoBehaviour {

    [HideInInspector]
    public int slotIndex; //Dimulai dari 0
    [HideInInspector]
    public GameObject player;

    public GameObject itemImage;
    public GameObject inputField;

    private Player playerScript;

    void Awake()
    {
        playerScript = player.GetComponent<Player>();
    }

	void OnEnable()
    {
        inputField.GetComponent<InputField>().text = "1";
        itemImage.GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/" + playerScript.inventoryName[slotIndex]);
    }

    public void BtnUp()
    {
        var count = int.Parse(inputField.GetComponent<InputField>().text);
        count++;
        if(count > playerScript.inventoryCount[slotIndex])
        {
            count = playerScript.inventoryCount[slotIndex];
        }
        inputField.GetComponent<InputField>().text = count.ToString();
    }

    public void BtnDown()
    {
        var count = int.Parse(inputField.GetComponent<InputField>().text);
        count--;
        if (count < 1)
        {
            count = 1;
        }
        inputField.GetComponent<InputField>().text = count.ToString();
    }

    public void BtnBuang()
    {
        var count = int.Parse(inputField.GetComponent<InputField>().text);

        if(playerScript.inventoryCount[slotIndex] - count == 0)
        {
            playerScript.inventoryCount.RemoveAt(slotIndex);
            playerScript.inventoryName.RemoveAt(slotIndex);
        }
        else
        {
            playerScript.inventoryCount[slotIndex] -= count;
        }

        playerScript.ShowInventory();
        playerScript.CountInventory();
        playerScript.CheckCraft();
    }

    public void InputFieldChange()
    {
        if(int.Parse(inputField.GetComponent<InputField>().text) < 1)
        {
            inputField.GetComponent<InputField>().text = "1";
        }
        else if(int.Parse(inputField.GetComponent<InputField>().text) > playerScript.inventoryCount[slotIndex])
        {
            inputField.GetComponent<InputField>().text = playerScript.inventoryCount[slotIndex].ToString();
        }
    }
}
