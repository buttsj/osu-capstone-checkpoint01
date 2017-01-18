using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour {

    private bool active;

    private GameObject paddle1;

	void Start () {

        active = false;

        paddle1 = GameObject.Find("Paddle1");
	}
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            active = true;
        }

        if (active)
        {

        }
        else
        {
            transform.position = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y, paddle1.transform.position.z + 1);
        }

	}

}
