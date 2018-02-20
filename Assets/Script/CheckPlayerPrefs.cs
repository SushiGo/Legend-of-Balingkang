using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerPrefs : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        //-- TUTORIAL --//
        if (!PlayerPrefs.HasKey("isTutorial"))
        {
            PlayerPrefs.SetInt("isTutorial", 1);
        }

        //-- CUTSCENE --//
        if (!PlayerPrefs.HasKey("cutSceneName"))
        {
            PlayerPrefs.SetString("cutSceneName", "1");
        }

        //-- ACHIEVEMENT --//
        if (!PlayerPrefs.HasKey("achievementLevel1"))
        {
            var numberArray = new int[1];
            PlayerPrefsX.SetIntArray("achievementLevel1", numberArray);
        }
        if (!PlayerPrefs.HasKey("achievementLevel2"))
        {
            var numberArray = new int[2];
            PlayerPrefsX.SetIntArray("achievementLevel2", numberArray);
        }
        if (!PlayerPrefs.HasKey("achievementLevel3"))
        {
            var numberArray = new int[5];
            PlayerPrefsX.SetIntArray("achievementLevel3", numberArray);
        }
        if (!PlayerPrefs.HasKey("achievementLevel4"))
        {
            var numberArray = new int[4];
            PlayerPrefsX.SetIntArray("achievementLevel4", numberArray);
        }
        if (!PlayerPrefs.HasKey("achievementLevel5"))
        {
            var numberArray = new int[4];
            PlayerPrefsX.SetIntArray("achievementLevel5", numberArray);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Reset Tutorial (developer mode)
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("isTutorial", 1);
            
            var numberArray = new int[1];
            PlayerPrefsX.SetIntArray("achievementLevel1", numberArray);

            var numberArray2 = new int[2];
            PlayerPrefsX.SetIntArray("achievementLevel2", numberArray2);

            var numberArray3 = new int[5];
            PlayerPrefsX.SetIntArray("achievementLevel3", numberArray3);

            var numberArray4 = new int[4];
            PlayerPrefsX.SetIntArray("achievementLevel4", numberArray4);
            PlayerPrefsX.SetIntArray("achievementLevel5", numberArray4);
        }
    }
}
