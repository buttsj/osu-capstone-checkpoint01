using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-16.0f * Time.deltaTime , 0.0f, 0.0f));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(16.0f * Time.deltaTime, 0.0f, 0.0f));
        }
	}
}
