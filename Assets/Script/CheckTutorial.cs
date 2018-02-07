using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTutorial : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		if(!PlayerPrefs.HasKey("isTutorial"))
        {
            PlayerPrefs.SetInt("isTutorial", 1);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		//Reset Tutorial (developer mode)
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("isTutorial", 1);
        }
	}
}
