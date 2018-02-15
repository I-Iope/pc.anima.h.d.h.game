using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour {

	public int testAdvancement;
	public GameObject prefab;

	void Update () {
		if (AdvancementController.advancementCount >= testAdvancement) {
			Instantiate (prefab);
			Destroy (gameObject);
		}
	}
}
