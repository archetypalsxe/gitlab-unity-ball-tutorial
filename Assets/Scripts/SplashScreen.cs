using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SplashScreen : MonoBehaviour {

    /**
     * Text saying to press any key to begin
     */
    public Text pressAnyKeyText;

    /**
     * Whether or not pressing a key will have any affect
     */
    protected bool ready = false;

    /**
     * Clear out the text and display after 5 seconds
     */
    void Start()
    {
        pressAnyKeyText.text = "";
        IEnumerator coroutine = this.waitSomeTime(5);
        StartCoroutine(coroutine);
    }

    /**
     * Check for any keys being pressed
     */
    void Update() {
        if (
            (Input.anyKeyDown | Input.touchCount > 0) & ready
        ) {
            SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        }
    }

    protected IEnumerator waitSomeTime(int seconds) {
        yield return new WaitForSeconds(seconds);
        pressAnyKeyText.text = "Press Any Key to Begin!";
        this.ready = true;
    }
}
