using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour {

    public MovieTexture movieTexture;

    private AudioSource audioSource;

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
        //if(!movieTexture.isPlaying)
        //{
        //    print("Asdasd");
        //}
    }
}
