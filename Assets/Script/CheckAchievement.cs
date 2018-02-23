using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckAchievement : MonoBehaviour {

    public GameObject[] panelPic;
    public GameObject bonusPic;

	// Use this for initialization
	void Start ()
    {
        int totalAchievement = 0;
		for(int i=0; i<panelPic.Length; i++)
        {
            var tempCount = 0;
            for(int j=0; j<PlayerPrefsX.GetIntArray("achievementLevel" + (i+1)).Length; j++)
            {
                if(PlayerPrefsX.GetIntArray("achievementLevel" + (i+1))[j] == 1)
                {
                    tempCount++;
                }
            }

            if(tempCount == PlayerPrefsX.GetIntArray("achievementLevel" + (i+1)).Length) //Achievement complete 100%
            {
                panelPic[i].transform.GetChild(0).GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Picture/pic" + i);
                panelPic[i].transform.GetChild(2).gameObject.SetActive(false);
                panelPic[i].transform.GetChild(3).gameObject.SetActive(false);
                totalAchievement++;
            }
            else
            {
                panelPic[i].transform.GetChild(2).GetComponent<Text>().text = tempCount.ToString();
            }
        }

        if(totalAchievement == 5)
        {
            bonusPic.transform.GetChild(0).GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Picture/pic5");
            bonusPic.transform.GetChild(2).gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
