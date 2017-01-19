using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

    private bool active;

    private GameObject paddle1;

    private Rigidbody rb;

    private Vector3 oldVelocity;

    private Vector3 ballVelocity;

    private int paddle1Score;
    private int paddle2Score;

    void Start() {

        active = false;

        paddle1 = GameObject.Find("Paddle1");

        rb = GetComponent<Rigidbody>();

        ballVelocity = new Vector3(0, 0, 30f);

        paddle1Score = 0;
        paddle2Score = 0;
    }

    void FixedUpdate() {

        if (Input.GetKeyDown(KeyCode.Space) && !active)
        {
            active = true;
            rb.velocity = ballVelocity + paddle1.GetComponent<Rigidbody>().velocity;
        }

        if (!active)
        {
            transform.position = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y, paddle1.transform.position.z + 1);
        }
        oldVelocity = rb.velocity;

        ScoreUpdate();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Paddle1" || collision.gameObject.name == "Paddle2")
        {
            if (!collision.gameObject.GetComponent<Rigidbody>().velocity.Equals(Vector3.zero))
            {
                rb.velocity = new Vector3(collision.gameObject.GetComponent<Rigidbody>().velocity.x, 0, -oldVelocity.z );
            }
            else
            {
                rb.velocity = -oldVelocity;
            }
        }
        else if (collision.gameObject.name == "RightWall" || collision.gameObject.name == "LeftWall") {
            rb.velocity = new Vector3(-oldVelocity.x, 0, oldVelocity.z);
        }  
        Debug.Log(rb.velocity);
    }


    private void ScoreUpdate()
    {
        if (transform.position.z > 10)
        {
            paddle1Score++;
            if (paddle1Score >= 11)
            {
                Debug.Log("Player 1 Wins!");
            }
            else
            {
            }
        }
        else if (transform.position.z < -10)
        {
            paddle2Score++;
            if (paddle2Score >= 11)
            {
                Debug.Log("Player 2 Wins!");
            }
        }
    }
}
