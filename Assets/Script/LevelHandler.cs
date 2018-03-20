using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour {

    public GameObject tutorialPanel;

    public MovieTexture movieTexture;

    private AudioSource audioSource;

    public GameObject player;

    public GameObject[] picture;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (movieTexture != null)
        {
            audioSource.clip = movieTexture.audioClip;
            movieTexture.Stop();
            movieTexture.Play();
            audioSource.Play();
        }
    }
    
	void Start ()
    {
        player = GameObject.Find("Player");
        if(PlayerPrefs.GetInt("isTutorial") == 1)
        {
            if(tutorialPanel)
            {
                tutorialPanel.SetActive(true);
            }
        }

        CheckPicture();

        //Save level -> checkpoint
        var tempName = int.Parse(SceneManager.GetActiveScene().name.Substring(5, 1));
        if(tempName > PlayerPrefs.GetInt("level"))
        {
            PlayerPrefs.SetInt("level", tempName);
        }
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
        if (movieTexture != null && !movieTexture.isPlaying)
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

    public void PlayCutscene(string cutSceneName)
    {
        movieTexture = Resources.Load<MovieTexture>("CutScene/Scene_" + cutSceneName);
        audioSource.clip = movieTexture.audioClip;
        movieTexture.Play();
        audioSource.Play();
    }

    public void CheckPicture()
    {
        if(picture.Length != 0)
        {
            var tempName = SceneManager.GetActiveScene().name;
            tempName = tempName.Substring(5, 1);
            var tempArr = PlayerPrefsX.GetIntArray("achievementLevel" + tempName);

            for(int i=0; i<tempArr.Length; i++)
            {
                if(tempArr[i] == 1) //picture sudah didapat
                {
                    if(picture[i].GetComponentInChildren<Bush>())
                    {
                        picture[i].GetComponentInChildren<Bush>().isPicture = false;
                    }
                    else if(picture[i].GetComponentInChildren<Conversation>())
                    {
                        picture[i].GetComponentInChildren<Conversation>().isPicture = false;
                    }
                    else
                    {
                        Destroy(picture[i]);
                    }
                }
            }
        }
    }
}
