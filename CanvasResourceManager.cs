using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasResourceManager : MonoBehaviour
{

    public Text CoinText;
    public Text IronText;
    public Text HealthText;

    private void Update()
    {
        UpdateScreen();
    }

    public void UpdateScreen()
    {
        CoinText.text = (PlayerPrefs.GetInt("Coins").ToString());
        IronText.text = (PlayerPrefs.GetInt("Iron").ToString());
        HealthText.text = (PlayerPrefs.GetInt("CurrentHealth")).ToString();
    }

}
