using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour {

    public string[] lines;
    public GameObject player;
    public GameObject panelSideQuest;
    public GameObject dialogAwal;
    public GameObject panelPilihOrang;
    public GameObject[] orangKuat;

    private Player playerScript;
    public int currentLine = 0;
    public int lastLine = 0;
    public bool isFinish = false;

    // Use this for initialization
    void Start ()
    {
        lastLine = lines.Length-1;
        playerScript = player.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void NextLine(Text dialogText)
    {
        if (currentLine > lastLine)
        {
            isFinish = true;
            No();
            playerScript.talkSideQuest = false;
            playerScript.actionBalloon.SetActive(false);

            if(dialogAwal)
            {
                dialogAwal.SetActive(false);
            }

            if(this.name == "sq2")
            {
                this.GetComponent<FollowPlayer>().enabled = true;
            }
            else if(this.name == "Target_sq2")
            {
                Destroy(GameObject.Find("sq2"));
            }
            else if(this.name == "Target_sq3")
            {
                foreach(var item in orangKuat)
                {
                    item.SetActive(true);
                }
            }
            else if (this.name == "sq3")
            {
                foreach (var item in GameObject.Find("Target_sq3").GetComponent<Conversation>().orangKuat)
                {
                    Destroy(item);
                }
                Destroy(GameObject.Find("sq3"));
            }
        }
        else if (lines[currentLine] == "")
        {
            if(this.name == "sq1")
            {
                //Cek apakah ada Axe di inventory
                if(playerScript.inventoryName.IndexOf("Axe") > -1)
                {
                    panelSideQuest.SetActive(true);
                    panelSideQuest.GetComponentInChildren<Text>().text = "Berikan kapak?";
                }
                else
                {
                    No(); //Tutup dialog box
                }
            }
            else if(this.name == "sq2")
            {
                panelSideQuest.SetActive(true);
                panelSideQuest.GetComponentInChildren<Text>().text = "Antar anak itu pulang?";
            }
            else if(this.name == "sq3")
            {
                //Jika orang" kuat sudah mengikuti
                if(GameObject.Find("Target_sq3").GetComponent<Conversation>().isFinish)
                {
                    panelSideQuest.SetActive(true);
                    panelSideQuest.GetComponentInChildren<Text>().text = "Minta bantuan orang untuk mengangkat?";
                }
                else
                {
                    playerScript.isRequiredFinish = true;
                    No();
                }
            }
            else if(this.name == "Target_sq3")
            {
                panelSideQuest.SetActive(true);
                panelSideQuest.GetComponentInChildren<Text>().text = "Minta bantuan?";
            }
        }
        else if (currentLine <= lastLine)
        {
            dialogText.text = lines[currentLine];
            currentLine++;
        }
    }

    public void Yes()
    {
        if(currentLine < lastLine)
        {
            if(this.name == "Target_sq3")
            {
                currentLine++;
            }
            else
            {
                currentLine++;
                playerScript.canMove = false;
                playerScript.inConversation = true;
                playerScript.dialogPanel.SetActive(true);
                NextLine(playerScript.dialogPanel.GetComponentInChildren<Text>());
            }
        }

        //REMOVE AXE for sq1
        if(this.name == "sq1")
        {
            int slotIndex = playerScript.inventoryName.IndexOf("Axe");
            playerScript.inventoryCount.RemoveAt(slotIndex);
            playerScript.inventoryName.RemoveAt(slotIndex);

            playerScript.ShowInventory();
            playerScript.CountInventory();
            playerScript.CheckCraft();
        }

        //isRequiredFinish in PlayerScript set to true
        else if(this.name == "sq2")
        {
            playerScript.isRequiredFinish = true;
        }

        //Muncul panel pilih orang
        else if(this.name == "Target_sq3")
        {
            if(!panelPilihOrang.activeSelf)
            {
                panelPilihOrang.SetActive(true);
                playerScript.dialogPanel.SetActive(false);
            }
        }
    }
    
    public void No()
    {
        playerScript.dialogPanel.SetActive(false);
        playerScript.canMove = true;
        playerScript.inConversation = false;
        currentLine = 0;
    }
}
