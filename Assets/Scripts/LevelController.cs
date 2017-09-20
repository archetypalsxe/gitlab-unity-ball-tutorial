using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

  // Display for the timer
  public Text timerText;

  // The allowed to beat the level
  public float timeToBeat = 30;

	// The level number that the player is on
	protected static int currentLevel = 1;

	// The final level that the player can play
	protected static int finalLevel = 3;

  // The time that the level was started
  protected Timer startTime;

  // Called when the level is first started
  public void Start () {
    this.startTime = new Timer (1000);
  }

  public void Update () {
    timeToBeat -= Time.deltaTime;
    if(this.timeToBeat <= 0) {
      Debug.Log("Time out!");
      this.timerText.text = "Times Out!!!";
    } else {
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

	// Advance the current level to the next level
	public void advanceLevel() {
		LevelController.currentLevel++;
	}
}
