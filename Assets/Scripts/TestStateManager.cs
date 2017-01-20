using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestStateManager : MonoBehaviour {

    private const int NUMSTATES = 3;

    private GameObject paddle1;
    private GameObject paddle2;
    private GameObject ball;
    private GameObject manager;

    public Text winText;

    void Start () {

        paddle1 = GameObject.Find("Paddle1");
        paddle2 = GameObject.Find("Paddle2");
        ball = GameObject.Find("Ball");
        manager = GameObject.Find("GameManager");

    }
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            setTestPositions((new Vector3(0, 2, -16)), (new Vector3(0, 2, 16)), (new Vector3(0, 2, -15)));
            ball.GetComponent<BallBehavior>().Active = false;
            setTestVelocities((new Vector3(0, 0, 0)), (new Vector3(0, 0, 0)), (new Vector3(0, 0, 0)));
            setTestScores(0, 0);
            winText.text = "";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            setTestPositions((new Vector3(0, 2, -16)), (new Vector3(0, 2, 16)), (new Vector3(0, 2, -15)));
            ball.GetComponent<BallBehavior>().Active = false;
            setTestVelocities((new Vector3(0, 0, 0)), (new Vector3(0, 0, 0)), (new Vector3(0, 0, 0)));
            setTestScores(10, 0);
            winText.text = "";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            setTestPositions((new Vector3(0, 2, -16)), (new Vector3(0, 2, 16)), (new Vector3(0, 2, -15)));
            ball.GetComponent<BallBehavior>().Active = false;
            setTestVelocities((new Vector3(0, 0, 0)), (new Vector3(0, 0, 0)), (new Vector3(0, 0, 0)));
            setTestScores(0, 10);
            winText.text = "";
        }

    }

    private void setTestPositions(Vector3 p1, Vector3 p2, Vector3 ball)
    {
        paddle1.transform.position = p1;
        paddle2.transform.position = p2;
        this.ball.transform.position = ball;
    }

    private void setTestVelocities(Vector3 p1, Vector3 p2, Vector3 ball)
    {
        paddle1.GetComponent<Rigidbody>().velocity = p1;
        paddle2.GetComponent<Rigidbody>().velocity = p2;
        this.ball.GetComponent<Rigidbody>().velocity = ball;
    }

    private void setTestScores(int p1, int p2)
    {
        manager.GetComponent<GameManager>().setP1Score(p1);
        manager.GetComponent<GameManager>().setP2Score(p2);
    }

}
