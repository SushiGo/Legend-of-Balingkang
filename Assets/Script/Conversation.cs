using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour {

    public string[] lines;
    public GameObject player;
    public GameObject panelSideQuest;
    //public string[] LinesEnding;

    private Player playerScript;
    private int currentLine = 0;
    private int lastLine = 0;
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

            if(this.name == "sq2")
            {
                this.GetComponent<FollowPlayer>().enabled = true;
            }
            else if(this.name == "Target_sq2")
            {
                Destroy(GameObject.Find("sq2"));
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
            currentLine++;
            playerScript.canMove = false;
            playerScript.inConversation = true;
            playerScript.dialogPanel.SetActive(true);
            NextLine(playerScript.dialogPanel.GetComponentInChildren<Text>());
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
    }
    
    public void No()
    {
        playerScript.dialogPanel.SetActive(false);
        playerScript.canMove = true;
        playerScript.inConversation = false;
        currentLine = 0;
    }
}
