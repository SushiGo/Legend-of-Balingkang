using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingButton : MonoBehaviour {

    public GameObject player;

    private Player playerScript;

    void Awake()
    {
        playerScript = player.GetComponent<Player>();
    }

    public void Crafting(string itemName)
    {
        playerScript.PickItem(itemName);

        //Kurangi bahan
        if(itemName == "Torch")
        {
            for (int i = (playerScript.inventoryName.Count - 1); i >= 0; i--)
            {
                if (playerScript.inventoryName[i] == "Wood")
                {
                    if (playerScript.inventoryCount[i] - 1 == 0)
                    {
                        playerScript.inventoryCount.RemoveAt(i);
                        playerScript.inventoryName.RemoveAt(i);
                        break;
                    }
                    else
                    {
                        playerScript.inventoryCount[i] -= 1;
                        break;
                    }
                }
            }

            for (int i = (playerScript.inventoryName.Count - 1); i >= 0; i--)
            {
                if (playerScript.inventoryName[i] == "Grass")
                {
                    if (playerScript.inventoryCount[i] - 1 == 0)
                    {
                        playerScript.inventoryCount.RemoveAt(i);
                        playerScript.inventoryName.RemoveAt(i);
                        break;
                    }
                    else
                    {
                        playerScript.inventoryCount[i] -= 1;
                        break;
                    }
                }
            }
        }
        else if(itemName == "Axe")
        {
            for (int i = (playerScript.inventoryName.Count - 1); i >= 0; i--)
            {
                if (playerScript.inventoryName[i] == "Wood")
                {
                    if (playerScript.inventoryCount[i] - 1 == 0)
                    {
                        playerScript.inventoryCount.RemoveAt(i);
                        playerScript.inventoryName.RemoveAt(i);
                        break;
                    }
                    else
                    {
                        playerScript.inventoryCount[i] -= 1;
                        break;
                    }
                }
            }

            var hasRemove = false;
            for (int i = (playerScript.inventoryName.Count - 1); i >= 0; i--)
            {
                if (playerScript.inventoryName[i] == "Stone")
                {
                    if(playerScript.inventoryCount[i] - 2 < 0)
                    {
                        playerScript.inventoryCount.RemoveAt(i);
                        playerScript.inventoryName.RemoveAt(i);
                        hasRemove = true;
                    }
                    else if(hasRemove)
                    {
                        playerScript.inventoryCount[i] -= 1;
                        break;
                    }
                    else if (playerScript.inventoryCount[i] - 2 == 0)
                    {
                        playerScript.inventoryCount.RemoveAt(i);
                        playerScript.inventoryName.RemoveAt(i);
                        break;
                    }
                    else
                    {
                        playerScript.inventoryCount[i] -= 2;
                        break;
                    }
                }
            }
            if(PlayerPrefs.GetInt("isTutorial") == 1)
            {
                playerScript.tutorialPanel.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Tutorial/tutorial5");
            }
        }
        
        playerScript.ShowInventory();
        playerScript.CountInventory();
        playerScript.CheckCraft();
    }
}
