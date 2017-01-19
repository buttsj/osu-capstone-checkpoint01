using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour {
    Rigidbody rb;
    private Vector3 paddleVelocity;
	void Start () {
        rb = GetComponent<Rigidbody>();
        paddleVelocity = new Vector3(30f, 0, 0);
    }
	
	void FixedUpdate () {

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -paddleVelocity;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = paddleVelocity;
        }
        else {
            rb.velocity = Vector3.zero;
        }

	}
}
