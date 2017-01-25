using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

    private bool active;

    private GameObject paddle1;
    private GameObject paddle2;

    private Rigidbody rb;

    private Vector3 oldVelocity;

    private Vector3 ballVelocity;

    private int zTimer;
    private float oldZPos;
    private const int MAXZTIMER = 10;

    void Start() {

        active = false;

        paddle1 = GameObject.Find("Paddle1");

        rb = GetComponent<Rigidbody>();

        ballVelocity = new Vector3(0, 0, 30f);

        zTimer = 0;
    }

    void FixedUpdate() {

        if (Input.GetKeyDown(KeyCode.Space) && !active)
        {
            active = true;
            rb.velocity = ballVelocity + paddle1.GetComponent<Rigidbody>().velocity;
        }

        handleInactiveBall();

        if (!active)
        {
            transform.position = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y, paddle1.transform.position.z + 1);
        }

        oldVelocity = rb.velocity;
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Paddle1" || collision.gameObject.name == "Paddle2")
        {
            if (!collision.gameObject.GetComponent<Rigidbody>().velocity.Equals(Vector3.zero))
            {
                rb.velocity = new Vector3(collision.gameObject.GetComponent<Rigidbody>().velocity.x, 0, -oldVelocity.z);
                oldVelocity = rb.velocity;
            }
            else
            {
                rb.velocity = -oldVelocity;
                oldVelocity = rb.velocity;
            }

            float xDifference = gameObject.transform.position.x - collision.gameObject.transform.position.x;
            if (collision.gameObject.name == "Paddle1" && (xDifference > 3f || xDifference < -3f))
            {
                gameObject.transform.Translate(0, 0, -5);
            }
            else if (collision.gameObject.name == "Paddle2" && (xDifference > 3f || xDifference < -3f)) {
                gameObject.transform.Translate(0, 0, 5);
            }

        }
        else if (collision.gameObject.name == "RightWall" || collision.gameObject.name == "LeftWall") {
            rb.velocity = new Vector3(-oldVelocity.x, 0, oldVelocity.z);
            oldVelocity = rb.velocity;
        }

        AudioSource source = collision.gameObject.GetComponent<AudioSource>();
        source.Play();
    }

    public void ResetBall()
    {
        transform.position = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y, paddle1.transform.position.z+1);
        rb.velocity = Vector3.zero;
        active = false;
        zTimer = 0;
    }

    public void RestBall()
    {
        transform.position = new Vector3(50, 50, 50);
        rb.velocity = Vector3.zero;
    }

    public bool Active {
        get { return active; }
        set { active = value; }
    }

    private void handleInactiveBall()
    {
        if (oldZPos == transform.position.z)
        {
            zTimer++;
        }
        else
        {
            zTimer = 0;
        }
        if (zTimer > MAXZTIMER)
        {
            if(oldZPos > 0)
            {
                transform.position = new Vector3(0.0f, 2.0f, 20.0f);
            }
            else if(oldZPos <= 0)
            {
                transform.position = new Vector3(0.0f, 2.0f, -20.0f);
            }
        }
        oldZPos = transform.position.z;
    }

}
