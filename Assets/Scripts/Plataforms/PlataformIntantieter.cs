using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformIntantieter : MonoBehaviour {

	public int advancementNumber;
	public GameObject prefab;

	void Update () {
		if (AdvancementController.advancementCount >= advancementNumber) {
			Instantiate (prefab);
			Destroy (gameObject);
		}
	}
}
