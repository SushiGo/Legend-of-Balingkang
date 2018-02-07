using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneCollide : MonoBehaviour {

    public string sceneName;
    public string cutsceneName;

	// Use this for initialization
	void Start (){
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            if(cutsceneName != "")
            {
                PlayerPrefs.SetString("cutSceneName", cutsceneName);
            }
            Initiate.Fade(sceneName, Color.black, 2.0f);
        }
    }
}
