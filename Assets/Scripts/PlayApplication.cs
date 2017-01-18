using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayApplication : MonoBehaviour {

	public void Play() {
        // Play Game
        SceneManager.LoadScene("PONG");
    }
}
