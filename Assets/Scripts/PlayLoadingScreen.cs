using UnityEngine;
using UnityEngine.UI;

public class PlayLoadingScreen : MonoBehaviour {

    public MovieTexture movie;
    float timer = 0.0f;

    void Start()
    {
        GetComponent<RawImage>().texture = movie as MovieTexture;
        movie.Play();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 12.0f)
        {
            Debug.Log("movie is done");
            // load next scene
            timer = 0.0f;
        }
     }

}
