using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController  {

	// The level number that the player is on
	public int currentLevel = 1;

	// The final level that the player can play
	public int finalLevel = 3;

	/*
		Returns whether or not the game has been beat. Should be called after
		the level has been advanced
	 */
	public bool hasBeatGame() {
		return currentLevel > finalLevel;
	}

	// Advance the current level to the next level
	public void advanceLevel() {
		this.currentLevel++;
	}
}
