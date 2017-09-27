using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

  // Display for the timer
  public Text timerText;

  // The time to beat the level displayed at the end of the level
  public Text timeText;

  // The allowed to beat the level
  public float timeToBeat = 30;

	// The level number that the player is on
	protected static int currentLevel = 1;

	// The final level that the player can play
	protected static int finalLevel = 3;

  // Whether or not the level has been beat
  protected bool levelBeat = false;

  // Called when the level is first started
  public void Start () {
    this.levelBeat = false;
    this.timeText.text = "";
  }

  // Has the player ran out of time?
  public bool isTimeOut() {
    return this.timeToBeat <= 0;
  }

  public void Update () {
    if(!this.levelBeat) {
      timeToBeat -= Time.deltaTime;
      if(timeToBeat < 0) {
        timeToBeat = 0;
      }
      this.timerText.text = ((int) timeToBeat).ToString();
    }
  }

	// Returns the level that the user is currently on
	public int getCurrentLevel() {
		return LevelController.currentLevel;
	}

	/*
		Returns whether or not the game has been beat. Should be called after
		the level has been advanced
	 */
	public bool hasBeatGame() {
		return LevelController.currentLevel > LevelController.finalLevel;
	}

  // Repeat the current level that the user is on
  public void repeatLevel() {
    IEnumerator coroutine = this.loadLevel();
    StartCoroutine(coroutine);
  }

	// Advance the current level to the next level
  public void advanceLevel() {
    float timeToBeatLevel = Time.timeSinceLevelLoad;
    this.levelBeat = true;
    LevelController.currentLevel++;
    this.timeText.text = timeToBeatLevel.ToString("0.00") + " Seconds";
    IEnumerator coroutine = this.loadLevel();
    StartCoroutine(coroutine);
  }

  // Load up the next level to be played
  protected IEnumerator loadLevel() {
    yield return new WaitForSeconds(5);
    string nextLevel;
    if(this.hasBeatGame()) {
      // Reset back to the first level in case they play again
      currentLevel = 1;
      nextLevel = "Victory Screen";
    } else {
      nextLevel = "Level" + this.getCurrentLevel();
    }
    SceneManager.LoadScene(
        nextLevel,
        LoadSceneMode.Single
    );
  }
}
