﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour {

    private const int NUMSTATES = 4;

    private int currentSavePosition;

    private GameObject paddle1;
    private GameObject paddle2;
    private GameObject ball;
    private GameObject manager;
    
    private Vector3[] paddle1Positions;
    private Vector3[] paddle2Positions;
    private Vector3[] ballPositions;

    private Vector3[] paddle1Velocities;
    private Vector3[] paddle2Velocities;
    private Vector3[] ballVelocities;

    private bool[] ballActiveStates;

    private int[] p1Scores;
    private int[] p2Scores;

    public Text savedText;
    private int textTimer;
    private const int MAXTIME = 60;

    public Text winText;

    void Start () {

        currentSavePosition = 0;

        paddle1 = GameObject.Find("Paddle1");
        paddle2 = GameObject.Find("Paddle2");
        ball = GameObject.Find("Ball");
        manager = GameObject.Find("GameManager");

        paddle1Positions = new Vector3[NUMSTATES];
        paddle2Positions = new Vector3[NUMSTATES];
        ballPositions = new Vector3[NUMSTATES];

        paddle1Velocities = new Vector3[NUMSTATES];
        paddle2Velocities = new Vector3[NUMSTATES];
        ballVelocities = new Vector3[NUMSTATES];

        ballActiveStates = new bool[NUMSTATES];

        p1Scores = new int[NUMSTATES];
        p2Scores = new int[NUMSTATES];

        savedText.text = "";

        for(int i = 0; i < NUMSTATES; i++)
        {
            paddle1Positions[i] = new Vector3(0, 2, -16);
            paddle2Positions[i] = new Vector3(0, 2, 16);
            ballPositions[i] = new Vector3(0, 2, -15);

            paddle1Velocities[i] = new Vector3(0.0f, 0.0f, 0.0f);
            paddle2Velocities[i] = new Vector3(0.0f, 0.0f, 0.0f);
            ballVelocities[i] = new Vector3(0.0f, 0.0f, 0.0f);

            ballActiveStates[i] = false;

            p1Scores[i] = 0;
            p2Scores[i] = 0;
        }

    }
	
	void Update() {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            int displayPosition = currentSavePosition + 1;
            savedText.text = "Saved to " + displayPosition;

            saveCurrentPositions();

            saveCurrentVelocities();

            saveScores();

            ballActiveStates[currentSavePosition] = ball.GetComponent<BallBehavior>().Active;

            currentSavePosition++;

            if(currentSavePosition >= NUMSTATES)
            {
                currentSavePosition = 0;
            }
        }

        handleSaveMessage();

        loadState();

	}

    private void saveCurrentPositions()
    {
        paddle1Positions[currentSavePosition] = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y, paddle1.transform.position.z);
        paddle2Positions[currentSavePosition] = new Vector3(paddle2.transform.position.x, paddle2.transform.position.y, paddle2.transform.position.z);
        ballPositions[currentSavePosition] = new Vector3(ball.transform.position.x, ball.transform.position.y, ball.transform.position.z);
    }

    private void saveCurrentVelocities()
    {
        Vector3 paddle1Velocity = paddle1.GetComponent<Rigidbody>().velocity;
        paddle1Velocities[currentSavePosition] = new Vector3(paddle1Velocity.x, paddle1Velocity.y, paddle1Velocity.z);

        Vector3 ballVelocity = ball.GetComponent<Rigidbody>().velocity;
        ballVelocities[currentSavePosition] = new Vector3(ballVelocity.x, ballVelocity.y, ballVelocity.z);
    }

    private void saveScores()
    {
        p1Scores[currentSavePosition] = manager.GetComponent<GameManager>().GetP1Score;
        p2Scores[currentSavePosition] = manager.GetComponent<GameManager>().GetP2Score;
    }

    private void handleSaveMessage()
    {
        if (savedText.text != "")
        {
            textTimer++;
            if (textTimer >= MAXTIME)
            {
                savedText.text = "";
                textTimer = 0;
            }
        }
    }

    private void loadState()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            int statePosition = 0;
            paddle1.transform.position = paddle1Positions[statePosition];
            paddle1.GetComponent<Rigidbody>().velocity = paddle1Velocities[statePosition];

            paddle2.transform.position = paddle2Positions[statePosition];
            paddle2.GetComponent<Rigidbody>().velocity = paddle2Velocities[statePosition];

            ball.transform.position = ballPositions[statePosition];
            ball.GetComponent<Rigidbody>().velocity = ballVelocities[statePosition];
            ball.GetComponent<BallBehavior>().Active = ballActiveStates[statePosition];

            manager.GetComponent<GameManager>().setP1Score(p1Scores[statePosition]);
            manager.GetComponent<GameManager>().setP2Score(p2Scores[statePosition]);

            winText.text = "";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            int statePosition = 1;
            paddle1.transform.position = paddle1Positions[statePosition];
            paddle1.GetComponent<Rigidbody>().velocity = paddle1Velocities[statePosition];

            paddle2.transform.position = paddle2Positions[statePosition];
            paddle2.GetComponent<Rigidbody>().velocity = paddle2Velocities[statePosition];

            ball.transform.position = ballPositions[statePosition];
            ball.GetComponent<Rigidbody>().velocity = ballVelocities[statePosition];
            ball.GetComponent<BallBehavior>().Active = ballActiveStates[statePosition];

            manager.GetComponent<GameManager>().setP1Score(p1Scores[statePosition]);
            manager.GetComponent<GameManager>().setP2Score(p2Scores[statePosition]);

            winText.text = "";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            int statePosition = 2;
            paddle1.transform.position = paddle1Positions[statePosition];
            paddle1.GetComponent<Rigidbody>().velocity = paddle1Velocities[statePosition];

            paddle2.transform.position = paddle2Positions[statePosition];
            paddle2.GetComponent<Rigidbody>().velocity = paddle2Velocities[statePosition];

            ball.transform.position = ballPositions[statePosition];
            ball.GetComponent<Rigidbody>().velocity = ballVelocities[statePosition];
            ball.GetComponent<BallBehavior>().Active = ballActiveStates[statePosition];

            manager.GetComponent<GameManager>().setP1Score(p1Scores[statePosition]);
            manager.GetComponent<GameManager>().setP2Score(p2Scores[statePosition]);

            winText.text = "";
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            int statePosition = 3;
            paddle1.transform.position = paddle1Positions[statePosition];
            paddle1.GetComponent<Rigidbody>().velocity = paddle1Velocities[statePosition];

            paddle2.transform.position = paddle2Positions[statePosition];
            paddle2.GetComponent<Rigidbody>().velocity = paddle2Velocities[statePosition];

            ball.transform.position = ballPositions[statePosition];
            ball.GetComponent<Rigidbody>().velocity = ballVelocities[statePosition];
            ball.GetComponent<BallBehavior>().Active = ballActiveStates[statePosition];

            manager.GetComponent<GameManager>().setP1Score(p1Scores[statePosition]);
            manager.GetComponent<GameManager>().setP2Score(p2Scores[statePosition]);

            winText.text = "";
        }
    }

}
