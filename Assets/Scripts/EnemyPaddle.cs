using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddle : MonoBehaviour {
    Rigidbody rb;
    GameObject ball;
    Vector3 paddleVelocity;

	void Start () {
        ball = GameObject.Find("Ball");
        rb = GetComponent<Rigidbody>();
        paddleVelocity = new Vector3(25f, 0, 0);
	}
	
	void FixedUpdate () {
        if (transform.position.x < ball.transform.position.x)
        {
            rb.velocity = paddleVelocity;
        }
        else if (transform.position.x > ball.transform.position.x)
        {
            rb.velocity = -paddleVelocity;
        }
        else {
            rb.velocity = Vector3.zero;
        }
	}
}
