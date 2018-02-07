using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCutscene : MonoBehaviour {

    private MovieTexture movieTexture;
    private AudioSource audioSource;
    private bool isPlaying = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        movieTexture = Resources.Load<MovieTexture>("CutScene/Scene_" + PlayerPrefs.GetString("cutSceneName"));
        audioSource.clip = movieTexture.audioClip;
        movieTexture.Stop();
        movieTexture.Play();
        audioSource.Play();
        isPlaying = true;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(isPlaying)
        {
            if(!movieTexture.isPlaying)
            {
                if(PlayerPrefs.GetString("cutSceneName") == "1")
                {
                    Initiate.Fade("Level1", Color.black, 2.0f);
                }
                else if(PlayerPrefs.GetString("cutSceneName") == "2-3")
                {
                    PlayerPrefs.SetString("cutSceneName", "4");
                    Initiate.Fade("PlayCutScene", Color.black, 2.0f);
                }
                else if (PlayerPrefs.GetString("cutSceneName") == "4")
                {
                    Initiate.Fade("Level2", Color.black, 2.0f);
                }
                else if (PlayerPrefs.GetString("cutSceneName") == "5-6")
                {
                    PlayerPrefs.SetString("cutSceneName", "7");
                    Initiate.Fade("PlayCutScene", Color.black, 2.0f);
                }
                else if (PlayerPrefs.GetString("cutSceneName") == "7")
                {
                    Initiate.Fade("Level3", Color.black, 2.0f);
                }
            }
        }
	}

    void OnGUI()
    {
        if (movieTexture != null)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movieTexture, ScaleMode.StretchToFill);
            
        }
    }
}
