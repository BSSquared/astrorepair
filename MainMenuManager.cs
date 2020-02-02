using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Text highscoreText;

    public Canvas MainCanvas;
    public Canvas ShopCanvas;
    public Canvas InstructionCanvas;
    public Canvas AboutCanvas;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Maxhealth") == 0)
        {
            PlayerPrefs.SetInt("Maxhealth", 100);
        }
        if (PlayerPrefs.GetFloat("acceleration") == 0)
        {
            PlayerPrefs.SetFloat("acceleration", .5f);
        }
        if (PlayerPrefs.GetFloat("maxSpeed") == 0)
        {
            PlayerPrefs.SetFloat("maxSpeed", 5f);
        }
        if (PlayerPrefs.GetInt("timecoinMultiplyer") == 0)
        {
            PlayerPrefs.SetInt("timecoinMultiplyer", 1);
        }
        PlayerPrefs.Save();
        highscoreText.text = PlayerPrefs.GetFloat("highscore").ToString();
    }

    public void StartGame()
    {

        PlayerPrefs.SetInt("CurrentHealth", PlayerPrefs.GetInt("Maxhealth"));
        PlayerPrefs.SetFloat("Timer", 0);
        PlayerPrefs.SetInt("Iron", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Game");
    }

    public void shopButton()
    {
        MainCanvas.enabled = false;
        ShopCanvas.enabled = true;
        InstructionCanvas.enabled = false;
        AboutCanvas.enabled = false;
    }

    public void InstructionsButton()
    {
        MainCanvas.enabled = false;
        ShopCanvas.enabled = false;
        InstructionCanvas.enabled = true;
        AboutCanvas.enabled = false;
    }

    public void AboutButton()
    {
        MainCanvas.enabled = false;
        ShopCanvas.enabled = false;
        InstructionCanvas.enabled = false;
        AboutCanvas.enabled = true;
    }

    public void mainMenu()
    {
        MainCanvas.enabled = true;
        ShopCanvas.enabled = false;
        InstructionCanvas.enabled = false;
        AboutCanvas.enabled = false;
    }

}
