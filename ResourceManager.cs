using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{


    public void changeCoins(int amount)
    {
        PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins")+amount);
        FindObjectOfType<CanvasResourceManager>().UpdateScreen();
    }

    public void changeIron(int amount)
    {
        PlayerPrefs.SetInt("Iron", PlayerPrefs.GetInt("Iron") + amount);
        FindObjectOfType<CanvasResourceManager>().UpdateScreen();
    }
}
