using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopManager : MonoBehaviour
{
    public Text AccPricetag;
    public Text maxHealthPriceTag;
    public Text MaxSpeedPriceTag;
    public Text coinMultiplyerPriceTag;
    public Text coinAmount;

    public Text accCurrent;
    public Text maxHealthCurrent;
    public Text maxSpeedCurrent;
    public Text coinMultCurrent;

    private int accPrice;
    private int maxhealthPrice;
    private int maxSpeedPrice;
    private int CoinMultPrice;



    void Start()
    {

        calculateCost();
    }

    // Update is called once per frame
    void Update()
    {

        calculateCost();
        AccPricetag.text = "Add .1 for " + accPrice.ToString();
        maxHealthPriceTag.text = "Add 10 for " + maxhealthPrice.ToString();
        MaxSpeedPriceTag.text = "Add 1 for " + maxSpeedPrice.ToString();
        coinMultiplyerPriceTag.text = "Add 1x for " + CoinMultPrice.ToString();
        coinAmount.text = PlayerPrefs.GetInt("Coins").ToString();

        accCurrent.text = PlayerPrefs.GetFloat("acceleration").ToString();
        maxHealthCurrent.text = (PlayerPrefs.GetInt("Maxhealth").ToString());
        maxSpeedCurrent.text = PlayerPrefs.GetFloat("maxSpeed").ToString();
        coinMultCurrent.text = PlayerPrefs.GetInt("timecoinMultiplyer").ToString();


        Debug.Log("Acc: " + PlayerPrefs.GetFloat("acceleration") + "MaxHealth: " + PlayerPrefs.GetInt("Maxhealth") + "MaxSpeed: " + PlayerPrefs.GetFloat("maxSpeed") + "Mult: " + PlayerPrefs.GetInt("timecoinMultiplyer"));
    }

    public void buyAcceleration()
    {
        if(PlayerPrefs.GetInt("Coins") >= accPrice)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - accPrice);
            PlayerPrefs.SetFloat("acceleration", (PlayerPrefs.GetFloat("acceleration") + .1f));
            PlayerPrefs.Save();
        }
    }

    public void buyMaxSpeed()
    {
        if (PlayerPrefs.GetInt("Coins") >= maxSpeedPrice)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - maxSpeedPrice);
            PlayerPrefs.SetFloat("maxSpeed", (PlayerPrefs.GetFloat("maxSpeed") + 1f));
            PlayerPrefs.Save();
        }
    }

    public void buyMaxHealth()
    {
        if (PlayerPrefs.GetInt("Coins") >= maxhealthPrice)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - maxhealthPrice);
            PlayerPrefs.SetInt("Maxhealth", (PlayerPrefs.GetInt("Maxhealth") + 10));
            PlayerPrefs.Save();
        }
    }

    public void buyCoinMultiplyer()
    {
        if (PlayerPrefs.GetInt("Coins") >= CoinMultPrice)
        {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - CoinMultPrice);
            PlayerPrefs.SetInt("timecoinMultiplyer", (PlayerPrefs.GetInt("timecoinMultiplyer") + 1));
            PlayerPrefs.Save();
        }
    }

    void calculateCost()
    {
        float numberofupgrades = (PlayerPrefs.GetFloat("acceleration") - .5f) * 10;
        accPrice = ((int)numberofupgrades * 50) + 50;

        numberofupgrades = (PlayerPrefs.GetFloat("maxSpeed") - 5f);
        maxSpeedPrice = ((int)numberofupgrades * 75) + 75;

        numberofupgrades = (PlayerPrefs.GetInt("Maxhealth") - 100);
        maxhealthPrice = ((int)(numberofupgrades/10) * 150) + 150;

        numberofupgrades = (PlayerPrefs.GetInt("timecoinMultiplyer") - 1);
        CoinMultPrice = ((int)numberofupgrades * 500) + 200;


    }
}
