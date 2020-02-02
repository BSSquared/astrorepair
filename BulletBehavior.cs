using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    public float speed = 10f;
    public float lifeTime = 4f;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = transform.right * speed * Time.deltaTime;
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            FindObjectOfType<ResourceManager>().changeIron(2);
            FindObjectOfType<ResourceManager>().changeCoins(Random.Range(1,5));
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("asteroid"))
        {
            FindObjectOfType<ResourceManager>().changeIron(Random.Range(1, 5));
            Destroy(other.gameObject);
        }

        if(other.tag != "Player")
        {
            Destroy(gameObject);
        }
       
    }
}
