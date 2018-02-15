using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuControll : MonoBehaviour {

	public Button continueButton;

	void Start () {
		if (PlayerPrefs.GetInt ("Level").Equals (null))
			continueButton.interactable = false;
	}

	public void NewGame () {
		SceneManager.LoadScene (1, LoadSceneMode.Single);
	}

	public void Continue () {
		SceneManager.LoadScene (PlayerPrefs.GetInt ("Level"), LoadSceneMode.Single);
	}

	public void Credits () {
		SceneManager.LoadScene ("Credits", LoadSceneMode.Single);
	}

	public void Quit () {
		Application.Quit ();
	}
}
