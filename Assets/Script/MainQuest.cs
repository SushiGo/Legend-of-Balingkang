using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainQuest : MonoBehaviour {

    public GameObject dialogPanel;
    public Text dialogText;

    private bool inConversation;
    private Conversation conversationScript;

    public MovieTexture movieTextureYes;
    public MovieTexture movieTextureNo;
    private AudioSource audioSource;

    private bool yesPlaying, noPlaying;
    public bool finishPlaying;

    // Use this for initialization
    void Start ()
    {
        StartCoroutine(ShowDialog());
        conversationScript = this.GetComponent<Conversation>();

        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (inConversation)
            {
                conversationScript.NextLine(dialogText);
            }
        }
    }

    IEnumerator ShowDialog()
    {
        yield return new WaitForSeconds(1.7f);
        dialogPanel.SetActive(true);
        inConversation = true;
        this.GetComponent<Conversation>().NextLine(dialogText);
    }

    public void Yes()
    {
        yesPlaying = true;
    }

    public void No()
    {
        noPlaying = true;
    }

    void OnGUI()
    {
        if(yesPlaying)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movieTextureYes, ScaleMode.StretchToFill);
        }
        else if(noPlaying)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movieTextureNo, ScaleMode.StretchToFill);
        }
        if(!movieTextureYes.isPlaying && !movieTextureNo.isPlaying)
        {
            yesPlaying = false;
            noPlaying = false;
        }
    }

    public void Play(string value)
    {
        if(value == "yes")
        {
            audioSource.clip = movieTextureYes.audioClip;
            movieTextureYes.Play();
        }
        else if(value == "no")
        {
            audioSource.clip = movieTextureNo.audioClip;
            movieTextureNo.Play();
        }
        audioSource.Play();
    }
}
