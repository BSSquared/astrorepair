using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerStageController : MonoBehaviour
{
    public Sprite Health100;
    public Sprite Health80;
    public Sprite Health60;
    public Sprite Health40;
    public Sprite Health20;

    //public int playerHealth = 100;
    //public int playerMaxHealth;


    public int numberToRepair = 10;
    public int healthAdded = 20;

    public SpriteRenderer sr;

    private void Start()
    {
        PlayerPrefs.SetInt("CurrentHealth", PlayerPrefs.GetInt("Maxhealth"));
    }


    private void Update()
    {
        //PlayerPrefs.SetInt("CurrentHealth" playerHealth);
        if (Input.GetKeyDown(KeyCode.R)){
            repairShip();
        }

        int currentHealths = PlayerPrefs.GetInt("CurrentHealth");
        int maxHealths = PlayerPrefs.GetInt("Maxhealth");

        float healthPercent = (float)currentHealths / (float)maxHealths;
        Debug.Log("currentHealths: " + currentHealths + " maxhealtsh: " +maxHealths + " health%: "+ healthPercent);
        if (healthPercent > .8)
        {
            if(sr.sprite != Health100)
            {
                sr.sprite = Health100;
            }
        }
        else if (healthPercent <= .8 && healthPercent > .6)
        {
            if (sr.sprite != Health80)
            {
                sr.sprite = Health80;
            }
        }
        else if (healthPercent <= .6 && healthPercent > .4)
        {
            if (sr.sprite != Health60)
            {
                sr.sprite = Health60;
            }
        }
        else if (healthPercent <= .4 && healthPercent > .2)
        {
            if (sr.sprite != Health40)
            {
                sr.sprite = Health40;
            }
        }
        else if (healthPercent <= .2 && healthPercent > 0)
        {
            if (sr.sprite != Health20)
            {
                sr.sprite = Health20;
            }
        }
        else if (healthPercent  <= 0)
        {
            //TODO call the end screen
            SceneManager.LoadScene("EndScreen");
        }
    }




    public void repairShip()
    {
        if(PlayerPrefs.GetInt("Iron") >= 10)
        {
            if(PlayerPrefs.GetInt("CurrentHealth") < PlayerPrefs.GetInt("Maxhealth"))
            {
                PlayerPrefs.SetInt("CurrentHealth", PlayerPrefs.GetInt("CurrentHealth") + healthAdded);
                if (PlayerPrefs.GetInt("CurrentHealth") > PlayerPrefs.GetInt("Maxhealth"))
                {
                    PlayerPrefs.SetInt("CurrentHealth", PlayerPrefs.GetInt("Maxhealth"));
                }
                PlayerPrefs.SetInt("Iron", PlayerPrefs.GetInt("Iron")-numberToRepair);
                FindObjectOfType<CanvasResourceManager>().UpdateScreen();
            }
        }
    }





}
