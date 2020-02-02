using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidBehvaior : MonoBehaviour
{
    private int randomSize;
    public Rigidbody2D rb;

    private  float randX;
    private float randY;
    private float travelSpeed;
    private float rot =0f;
    private float randomScreenPositions = 25f;

    [System.Obsolete]
    private void Start()
    {
        randomSize = Random.Range(1,5);

        rb.transform.localScale = new Vector3Int(randomSize, randomSize, 1);
        Debug.Log(randomSize);
        randX = Random.RandomRange(-randomScreenPositions, randomScreenPositions);
        randY = Random.RandomRange(-randomScreenPositions, randomScreenPositions);
        travelSpeed = Random.value;
        
    }

    private void Update()
    {
        transform.position = Vector2.Lerp(rb.position, new Vector2(randX, randY), travelSpeed * Time.deltaTime);
        if(Vector2.Distance(transform.position, new Vector2(randX, randY)) < .5)
        {
            Destroy(gameObject);
            //TODO particals making it looked like it moved farther away so you cant hit it any more
        }
        rot += .5f;
        rb.SetRotation(rot);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            //FindObjectOfType<playerStageController>().playerHealth -= (5 * randomSize);
            PlayerPrefs.SetInt("CurrentHealth", PlayerPrefs.GetInt("CurrentHealth") - (5 * randomSize));
            Destroy(gameObject);
        }
    }


}
