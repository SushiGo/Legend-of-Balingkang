using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToScene(string sceneName)
    {
        //PlayerPrefs.SetString("cutSceneName", "1");
        if(SceneManager.GetActiveScene().name == "Level3b_KapalCina")
        {
            Initiate.Fade(sceneName, Color.black, 0.5f);
        }
        else
        {
            Initiate.Fade(sceneName, Color.black, 2.0f);
        }
    }

    public void PlayAgain()
    {
        Initiate.Fade("Level" + PlayerPrefs.GetInt("level"), Color.black, 2.0f);
    }

    public void ChangeCutScene(string name)
    {
        PlayerPrefs.SetString("cutSceneName", name);
    }
}
