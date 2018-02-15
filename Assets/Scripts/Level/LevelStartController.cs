using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartController : MonoBehaviour {

	public Transform player;
	public int level;

	void Start () {
		AdvancementController.advancementCount = PlayerPrefs.GetInt ("LevelAdvancement");
		player.position = new Vector2(PlayerPrefs.GetFloat ("PositionX"), PlayerPrefs.GetFloat ("PositionY"));
		PlayerPrefs.SetInt ("Level", level);

		Destroy (gameObject);
	}
}
