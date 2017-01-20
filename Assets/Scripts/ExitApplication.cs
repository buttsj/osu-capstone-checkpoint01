using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitApplication : MonoBehaviour {

    public void Exit() {
        StartCoroutine(Delay());
    }

    IEnumerator Delay() {
        // Delay for Button
        yield return new WaitForSeconds(0.65f);

        // Quit Application
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
