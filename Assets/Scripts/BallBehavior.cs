using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

    private bool active;

    private GameObject paddle1;

    private Rigidbody rb;

	void Start () {

        active = false;

        paddle1 = GameObject.Find("Paddle1");

        rb = GetComponent<Rigidbody>();
	}
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            active = true;
            rb.AddForce(new Vector3(0.0f, 0.0f, 30.0f), ForceMode.VelocityChange);
        }

        if (!active)
        {
            transform.position = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y, paddle1.transform.position.z + 1);
        }

	}

}
