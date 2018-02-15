using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitControll : MonoBehaviour {

	void Update () {
		if (Input.GetButtonDown ("Exit")) {
			SceneManager.LoadScene ("Main Menu", LoadSceneMode.Single);
		}
	}
}
