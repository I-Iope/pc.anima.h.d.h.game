using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour {

	private TextBoxManager textBoxManager;

	[HideInInspector]
	public TextAsset correctText;
	[HideInInspector]
	public TextAsset wrongText;

	public InputField inputField;

	private string[] textLines;
	private int advancementNumber;

	[HideInInspector]
	public bool enable;
	[HideInInspector]
	public string answerText;

	public static bool response;



	void Start () {
		textBoxManager = FindObjectOfType<TextBoxManager> ();
		DisableInputField ();
	}

	void Update () {
		if (!enable)
			return;

		if (Input.GetButtonDown ("Enter") && inputField.text != null) {			
			if (inputField.text.ToLower().Equals (answerText)) {
				textLines = correctText.text.Split ('\n');
				AdvancementController.advancementCount = advancementNumber;
				PlayerPrefs.SetInt ("LevelAdvancement", advancementNumber);
			} else {
				textLines = wrongText.text.Split ('\n');
				textBoxManager.answer = false;
			}

			textLines [0] = inputField.text + "...";

			textBoxManager.ReloadScript (textLines);
			textBoxManager.activeInput = false;
			textBoxManager.EnableTextBox ();

			DisableInputField ();
		}
	}

	public void SetInformations (TextAsset correctTxt, TextAsset wrongTxt, string answerText) {
		correctText = correctTxt;
		wrongText = wrongTxt;
		this.answerText = answerText;
}

	public void EnableInputField (int advancement) {
		advancementNumber = advancement;
		enable = true;
		inputField.enabled = true;
		inputField.gameObject.SetActive (true);
	}

	public void DisableInputField () {
		inputField.text = null;
		enable = false;
		inputField.gameObject.SetActive (false);
	}

}