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
        paddleVelocity = new Vector3(30f, 0, 0);
	}
	
	void FixedUpdate () {
        if (ball.GetComponent<Rigidbody>().velocity.z > 0)
        {
            float positionDifference = transform.position.x - ball.transform.position.x;
            if (positionDifference < -1)
            {
                rb.velocity = paddleVelocity;
            }
            else if (positionDifference > 1)
            {
                rb.velocity = -paddleVelocity;
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
        else {
            rb.velocity = Vector3.zero;
        }
	}
}
