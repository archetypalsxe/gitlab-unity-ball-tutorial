using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class LevelController : MonoBehaviour {

  // Display for the timer
  public string timerText;

	// The level number that the player is on
	protected static int currentLevel = 1;

	// The final level that the player can play
	protected static int finalLevel = 3;

  // The time that the level was started
  protected Timer startTime;

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
