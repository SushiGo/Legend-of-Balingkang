using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    
    private string facing = "right";
    private Rigidbody rBody;

    private bool canPickItem = false;
    private string itemName;

    public float moveSpeed;

    //-- JUMP --//
    public float jumpForce;
    private bool onGround = false;

    //-- INVENTORY --//
    public GameObject[] inventory;
    public GameObject notifInventoryPenuh;
    //[HideInInspector]
    public List<string> inventoryName;
    public List<int> inventoryCount;

    //-- CRAFTING --//
    public GameObject craftingAxe, craftingTorch;

    //-- CONVERSATION --//
    public GameObject actionBalloon;

    void Start ()
    {
        rBody = GetComponent<Rigidbody>();

        inventoryName = new List<string>();
        inventoryCount = new List<int>();
        ShowInventory();
    }
	
	void Update ()
    {
        #region //-- MOVE --//
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;

        if (x < 0) //Going left
        {
            if (facing == "right")
            {
                this.transform.Rotate(0, -180f, 0);
                facing = "left";
            }
            this.GetComponent<Animator>().SetBool("isMove", true);
            transform.Translate(0, 0, -x);
        }
        else if (x > 0) //Going right
        {
            if (facing == "left")
            {
                this.transform.Rotate(0, 180f, 0);
                facing = "right";
            }
            this.GetComponent<Animator>().SetBool("isMove", true);
            transform.Translate(0, 0, x);
        }
        else
        {
            this.GetComponent<Animator>().SetBool("isMove", false);
        }
        #endregion

        #region//-- PICK UP ITEM --//
        if (Input.GetKeyDown(KeyCode.E) && canPickItem)
        {
            PickItem(itemName);
        }
        #endregion
    }

    void FixedUpdate ()
    {
        #region //-- JUMP --//
        if (onGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                onGround = false;
                StartCoroutine(Jumping());
                this.GetComponent<Animator>().SetTrigger("isJump");
            }
        }
        #endregion //-- JUMP --//
    }

    IEnumerator Jumping()
    {
        //while (true)
        //{
            yield return new WaitForSeconds(0.5f);
            Vector3 jumpVector = new Vector3(0, jumpForce, 0);
            rBody.velocity = jumpVector;
        //}
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Ground")
        {
            print("onGround");
            onGround = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            ShowActionBalloon();
            itemName = other.name;
            canPickItem = true;
        }
        else if(other.tag == "SideQuest")
        {
            ShowActionBalloon();
            if(other.name == "sq1")
            {
                print("This is sq1");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Item")
        {
            canPickItem = false;
        }
        actionBalloon.SetActive(false);
    }

    private void ShowActionBalloon()
    {
        //Munculkan balon kata yang ada huruf E. Tujuannya untuk memberi tahu player, untuk mengambil item tekan 'E'
        actionBalloon.SetActive(true);
    }

    public void PickItem(string itemName)

    {
        print("Pick item: " + itemName);
        //Cek apakah masi ada slot kosong
        if(inventoryName.Count != 5)
        {
            print("Slot masih ada");
            //Apakah ada benda yang sama
            if(inventoryName.Contains(itemName))
            {
                print("Ada benda yang sama");
                //Apakah stack sudah penuh
                var i = 0;
                foreach(string val in inventoryName)
                {
                    if(val == itemName)
                    {
                        if(inventoryCount[i] < 10)
                        {
                            print("Stack masi cukup");
                            inventoryCount[i]++;
                            CountInventory();
                            CheckCraft();
                            break;
                        }
                        else
                        {
                            //Jika sudah mencapai slot terakhir
                            if(i == (inventoryName.Count-1))
                            {
                                print("Stack penuh, pindah stack");
                                inventoryName.Add(itemName);
                                inventoryCount.Add(1);
                                ShowInventory();
                                CountInventory();
                                CheckCraft();
                                break;
                            }
                        }
                    }
                    else
                    {
                        //Jika sudah mencapai slot terakhir
                        if (i == (inventoryName.Count - 1))
                        {
                            print("Stack penuh, pindah stack");
                            inventoryName.Add(itemName);
                            inventoryCount.Add(1);
                            ShowInventory();
                            CountInventory();
                            CheckCraft();
                            break;
                        }
                    }
                    i++;
                }
            }
            else
            {
                print("Benda baru");
                inventoryName.Add(itemName);
                inventoryCount.Add(1);
                ShowInventory();
                CountInventory();
                CheckCraft();
            }
        }
        else
        {
            print("Slot sudah penuh");
            //Apakah ada benda yang sama
            if (inventoryName.Contains(itemName))
            {
                print("Ada benda yang sama");
                //Apakah stack sudah penuh
                var i = 0;
                foreach (string val in inventoryName)
                {
                    if (val == itemName)
                    {
                        if (inventoryCount[i] < 10)
                        {
                            print("Stack masi cukup");
                            inventoryCount[i]++;
                            CountInventory();
                            CheckCraft();
                            break;
                        }
                        else
                        {
                            //Jika sudah mencapai slot terakhir
                            if (i == (inventoryName.Count - 1))
                            {
                                print("Inventory penuh");
                                //-- MUNCUL DIALOG BOX INVENTORY PENUH --//
                                ShowFullInventory();
                                break;
                            }
                        }
                    }
                    else
                    {
                        //Jika sudah mencapai slot terakhir
                        if (i == (inventoryName.Count - 1))
                        {
                            print("Inventory penuh");
                            //-- MUNCUL DIALOG BOX INVENTORY PENUH --//
                            ShowFullInventory();
                            break;
                        }
                    }
                    i++;
                }
            }
            else
            {
                print("Inventory penuh");
                //-- MUNCUL DIALOG BOX INVENTORY PENUH --//
                ShowFullInventory();
            }
        }
    }

    public void ShowFullInventory()
    {
        notifInventoryPenuh.SetActive(true);
    }

    public void ShowInventory()
    {
        foreach(var x in inventory)
        {
            x.SetActive(false);
        }
        for(int i = 0; i < inventoryName.Count; i++)
        {
            inventory[i].SetActive(true);
            inventory[i].GetComponent<Image>().sprite = Resources.Load<Sprite>("Items/" + inventoryName[i]);
        }
    }

    public void CountInventory()
    {
        for (int i = 0; i < inventoryCount.Count; i++)
        {
            inventory[i].GetComponentInChildren<Text>().text = inventoryCount[i].ToString();
        }
    }

    public void CheckCraft()
    {
        int woodCount = 0;
        int stoneCount = 0;
        int grassCount = 0;
        var i = 0;
        foreach(var iName in inventoryName)
        {
            if(iName == "Wood")
            {
                woodCount += inventoryCount[i];
            }
            else if(iName == "Stone")
            {
                stoneCount += inventoryCount[i];
            }
            else if(iName == "Grass")
            {
                grassCount += inventoryCount[i];
            }
            i++;
        }
        //Apakah ada bahan untuk Torch (1 wood, 1 grass)
        if(woodCount >= 1 && grassCount >= 1)
        {
            craftingTorch.GetComponent<Button>().interactable = true;
        }
        else
        {
            craftingTorch.GetComponent<Button>().interactable = false;
        }

        //Apakah ada bahan untuk Axe (1 wood, 2 stone)
        if (woodCount >= 1 && stoneCount >= 2)
        {
            craftingAxe.GetComponent<Button>().interactable = true;
        }
        else
        {
            craftingAxe.GetComponent<Button>().interactable = false;
        }
    }
}
