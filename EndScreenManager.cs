using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text timeScore;

    void Start()
    {
        if(PlayerPrefs.GetFloat("highscore") < PlayerPrefs.GetFloat("Timer"))
        {
            PlayerPrefs.SetFloat("highscore", PlayerPrefs.GetFloat("Timer"));
        }
        float coinsAdd = PlayerPrefs.GetInt("Coins") + ((int)PlayerPrefs.GetFloat("Timer") * PlayerPrefs.GetFloat("timecoinMultiplyer"));

        PlayerPrefs.SetInt("Coins", (int)coinsAdd);
        timeScore.text = PlayerPrefs.GetFloat("Timer").ToString() + " Seconds";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void continueButton()
    {
        //TODO call and ad
        PlayerPrefs.SetInt("CurrentHealth", PlayerPrefs.GetInt("Maxhealth"));
        SceneManager.LoadScene("Game");
    }

    public void replayButton()
    {
        PlayerPrefs.SetInt("CurrentHealth", PlayerPrefs.GetInt("Maxhealth"));
        PlayerPrefs.SetFloat("Timer", 0);
        PlayerPrefs.SetInt("Iron", 0);
        SceneManager.LoadScene("Game");
    }

    public void mainmenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
