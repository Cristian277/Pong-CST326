using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody rb;
    public Vector3 startPosition;
    public bool player1Bool = false;
    public bool player2Bool = false;
    private Vector3 leftPosition = new Vector3(-5, 0, 0);
    private Vector3 rightPosition = new Vector3(5, 0, 0);


    // Saves starting position (0,0,0)
    void Start()
    {
        startPosition = transform.position;
        Launch();
    }

    //Reset is called in the manager
    public void Reset()
    {
        rb.velocity = Vector3.zero;
        //if player 1 scored then bool should be true so set the coordinates to the opposite side
        if (player1Bool)
        {
            transform.position = rightPosition;
        }
        else
        {
            transform.position = leftPosition;
        }
        speed = 5f;
        
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Throws the ball in a random direction
    private void Launch()
    {
        float x;
        float y;

        if(transform.position == rightPosition)
        {
            x = Random.Range(0, 1) == 0 ? -1 : -1; //change 1 to positive or negative depending on the bool
            y = Random.Range(0, 1) == 0 ? -1 : 1;
        }
        else if(transform.position == leftPosition)
        {
            x = Random.Range(0, 1) == 0 ? 1 : 1; //change 1 to positive or negative depending on the bool
            y = Random.Range(0, 1) == 0 ? -1 : 1;
        }
        else
        {
            x = Random.Range(0, 1) == 0 ? -1 : 1; //change 1 to positive or negative depending on the bool
            y = Random.Range(0, 1) == 0 ? -1 : 1;
        }
        
        rb.velocity = new Vector3(speed * x, speed * y,0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Paddle1"||collision.collider.name == "Paddle2")
        {
            speed += 4;
            Vector3 direction = rb.velocity.normalized;
            rb.velocity = direction * speed;
        }
    }

}
