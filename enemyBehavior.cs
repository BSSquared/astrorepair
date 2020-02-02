using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{

    public GameObject target;
    public float speed = 1f;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, target.transform.position, Time.deltaTime * speed);
        //--
        //Vector2 direction = Camera.main.ScreenToWorldPoint(target.position) - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Quaternion rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
        //transform.rotation = Quaternion.Slerp(transform.rotation, rotation,  Time.deltaTime);
        ////--

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("CurrentHealth", PlayerPrefs.GetInt("CurrentHealth") - 30);
            Destroy(gameObject);
        }
    }
}
