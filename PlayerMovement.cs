using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed = 4f;
    public float travelDistance = .1f;

    Vector2 PlayerDestination;

    public float acceleration = PlayerPrefs.GetInt("acceleration");
    public float maxSpeed = PlayerPrefs.GetFloat("maxSpeed");

    //---
    float leftConstraint = Screen.width;
    float rightConstraint = Screen.width;
    float bottomConstraint = Screen.height;
    float topConstraint = Screen.height;
    float buffer = 1.0f;
    Camera cam;
    float distanceZ;

    //--

    private Vector2 speed;

    private void Start()
    {
        //--
        cam = Camera.main;
        distanceZ = Mathf.Abs(cam.transform.position.z + transform.position.z);

        leftConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;
        bottomConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        topConstraint = cam.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, distanceZ)).y;
        //--
        PlayerDestination = rb.position;

        Debug.Log("Top: " + topConstraint);
        Debug.Log("Bottom: " + bottomConstraint);
        Debug.Log("Right: " + rightConstraint);
        Debug.Log("Left: " + leftConstraint);



    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))  //move Player Left
        {
            moveLeft();
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))  //move Player Up
        {
            moveUp();
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))  //move Player Right
        {
            moveRight();
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))  //move Player Down
        {
            moveDown();
        }

        //transform.position = Vector2.Lerp(rb.position, new Vector2(PlayerDestination.x, PlayerDestination.y),   Time.deltaTime);  //player lerping to the new location

        rb.velocity = speed;
    }

    void FixedUpdate()
    {
        if (transform.position.x < leftConstraint - buffer)
        {
            transform.position = new Vector3(rightConstraint + buffer, transform.position.y, transform.position.z);
        }
        if (transform.position.x > rightConstraint + buffer)
        {
            transform.position = new Vector3(leftConstraint - buffer, transform.position.y, transform.position.z);
        }
        if (transform.position.y < bottomConstraint - buffer)
        {
            transform.position = new Vector3(transform.position.x, topConstraint + buffer, transform.position.z);
        }
        if (transform.position.y > topConstraint + buffer)
        {
            transform.position = new Vector3(transform.position.x, bottomConstraint - buffer, transform.position.z);
        }
    }


    void moveRight()
    {
        //PlayerDestination.xrb.AddForce.transform.
        if(speed.x <= maxSpeed)
        { 
            speed.x += acceleration;
        }
}
    void moveLeft()
    {
        if (speed.x >= -maxSpeed)
        { 
            speed.x -= acceleration;
        }
}


    void moveUp()
    {
        //PlayerDestination.y += travelDistance;
        if (speed.y <= maxSpeed)
        { 
            speed.y += acceleration;
        }
}
    void moveDown()
    {
        //PlayerDestination.y -= travelDistance;
        if (speed.y >= -maxSpeed)
        { 
            speed.y -= acceleration;
        }
    }
}
