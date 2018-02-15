using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CeditsScene : MonoBehaviour {

	public void onClick() {
		SceneManager.LoadScene ("Main Menu", LoadSceneMode.Single);
	}
}
