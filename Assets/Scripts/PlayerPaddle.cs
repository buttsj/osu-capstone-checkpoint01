using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour {
    Rigidbody rb;

	void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	void FixedUpdate () {

        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-16f, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(16f, 0, 0);
        }
        else {
            rb.velocity = Vector3.zero;
        }

	}
}
