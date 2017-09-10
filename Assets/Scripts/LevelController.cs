using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

	// The level number that the player is on
	public int currentLevel = 1;

	// The final level that the player can play
	public int finalLevel = 3;

	// Use this for initialization
	void Start () {
		this.currentLevel = 1;
	}

	// Update is called once per frame
	void Update () {

	}
}
