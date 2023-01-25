using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	//Variables for the instantiation of the maze
	public Maze mazePrefab;
	private Maze mazeInstance;


	private void Start() {
		BeginGame();
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			RestartGame();
		}
	}


	//Functions for creating and clearing the maze
	private void BeginGame() {
		mazeInstance = Instantiate(mazePrefab) as Maze;
		StartCoroutine(mazeInstance.Generate());
	}

	private void RestartGame() {
		StopAllCoroutines();
		Destroy(mazeInstance.gameObject);
		BeginGame();
	}
}
