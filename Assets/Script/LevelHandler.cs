using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour {

    public MovieTexture movieTexture;

    private AudioSource audioSource;

    public GameObject player;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (movieTexture != null)
        {
            audioSource.clip = movieTexture.audioClip;
            movieTexture.Play();
            audioSource.Play();
        }
    }
    
	void Start ()
    {
        player = GameObject.Find("Player");
	}
	
	void Update ()
    {
		
	}

    void OnGUI()
    {
        if(movieTexture != null && movieTexture.isPlaying)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movieTexture, ScaleMode.StretchToFill);
        }
        if (!movieTexture.isPlaying)
        {
            player.GetComponent<Player>().enabled = true;
        }
    }

    public void No()
    {
        var sqName = player.GetComponent<Player>().sideQuestType;
        GameObject.Find(sqName).GetComponent<Conversation>().No();
    }

    public void Yes()
    {
        var sqName = player.GetComponent<Player>().sideQuestType;
        GameObject.Find(sqName).GetComponent<Conversation>().Yes();
    }

    public void NextLine()
    {
        var sqName = player.GetComponent<Player>().sideQuestType;
        var dialogText = player.GetComponent<Player>().dialogText;
        GameObject.Find(sqName).GetComponent<Conversation>().NextLine(dialogText);
    }
}
