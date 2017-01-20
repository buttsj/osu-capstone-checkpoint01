using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayApplication : MonoBehaviour {

	public void Play() {  
        StartCoroutine(Delay());
    }

    IEnumerator Delay() {
        // Delay Button Press
        yield return new WaitForSeconds(0.65f);

        // Play Game
        SceneManager.LoadScene("PingPong");
    }
}
