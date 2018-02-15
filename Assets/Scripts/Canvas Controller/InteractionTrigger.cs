using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger : MonoBehaviour {

	public TextAsset initialText;

	private TextBoxManager textBoxManager;
	private InputFieldManager inputFieldManager;

	public bool destroyWhenActivated;
	public bool requireButtonPress;
	public bool enableInput;

	public TextAsset correctText;
	public TextAsset wrongText;
	public string answerText;
	public TextAsset endText;
	public int advancementTest;

	public static bool typing;

	private bool waitForPress;

	void Start () {
		textBoxManager = FindObjectOfType<TextBoxManager> ();
		inputFieldManager = FindObjectOfType<InputFieldManager> ();
	}

	void Update () {
		if (waitForPress && Input.GetButtonDown ("Interact") && !typing) {
			Action ();
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (requireButtonPress) {
			waitForPress = true;
			return;
		}

		if (collider.name == "Player") {
			Action ();
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.name == "Player")
			waitForPress = false;
	}

	void Action () {
		Validate ();

		textBoxManager.ReloadScript (initialText.text.Split ('\n'));
		textBoxManager.EnableTextBox ();

		if (enableInput) {
			textBoxManager.advancementNumber = advancementTest;
			textBoxManager.activeInput = true;
			inputFieldManager.SetInformations (correctText, wrongText, answerText);
			initialText = endText;
			enableInput = false;
		} else if (initialText != endText) {
			AdvancementController.advancementCount = advancementTest;
			PlayerPrefs.SetInt ("LevelAdvancement", advancementTest);
		}

		if (destroyWhenActivated)
			Destroy (gameObject);
	}

	void Validate () {
		if (advancementTest <= PlayerPrefs.GetInt ("LevelAdvancement")) {
			if (destroyWhenActivated) {
				Destroy (this.gameObject);
			}
			initialText = endText;
			enableInput = false;
		}
	}
}
