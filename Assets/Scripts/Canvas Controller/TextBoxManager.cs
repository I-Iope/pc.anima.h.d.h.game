using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextBoxManager : MonoBehaviour {

	public TextAsset textFile;
	public GameObject textBox;
	public Text text;
	private PlayerController player;
	private InputFieldManager inputFieldManager;

	public string[] textLines;
	public bool isActive;
	public bool stopPlayerMovement;
	public float typeSpeed;
	public int advancementNumber;

	[HideInInspector]
	public int currentLine = 0;
	[HideInInspector]
	public int endAtLine;
	[HideInInspector]
	public bool activeInput;
	[HideInInspector]
	public bool die;

	private bool isTyping = false;
	private bool cancelTyping = false;
	public bool answer = true;

	void Start () {
		player = FindObjectOfType<PlayerController> ();
		inputFieldManager = FindObjectOfType<InputFieldManager> ();
	
			textLines = textFile.text.Split ('\n');
			endAtLine = textLines.Length - 1;

		if ((advancementNumber > PlayerPrefs.GetInt ("LevelAdvancement")) && isActive) {		
			PlayerPrefs.SetInt ("LevelAdvancement", advancementNumber);
			EnableTextBox ();
		} else {
			DisableTextBox ();
		}
	}

	void Update () {
		if (!isActive)	
			return;

		if (Input.GetButtonDown("Pass")) {
			if (!isTyping) {
				currentLine++;

				if (currentLine > endAtLine) {
					if (activeInput) {
						inputFieldManager.EnableInputField (advancementNumber);
					} else {					
						DisableTextBox ();
					}
				} else {
					StartCoroutine (TextScroll(textLines [currentLine]));
				}

		} else if (!cancelTyping){
				cancelTyping = true;
		}
	}
}

	private IEnumerator TextScroll (string textLine) {
		int letter = 0;
		text.text = "";
		isTyping = true;
		cancelTyping = false;

		while (isTyping && !cancelTyping && (letter < textLine.Length - 1)) {
			text.text += textLine [letter];
			letter ++;
			yield return new WaitForSeconds (typeSpeed);
		}

		text.text = textLine;
		isTyping = false;
		cancelTyping = false;
	}

	public void EnableTextBox () {
		textBox.SetActive (true);
		isActive = true;
		InteractionTrigger.typing = true;

		if (stopPlayerMovement)
			player.canMove = false;

		StartCoroutine (TextScroll(textLines [currentLine]));
	}

	private IEnumerator WrongAnswer(){
		yield return new WaitForSeconds (1.8f);
		SceneManager.LoadScene (PlayerPrefs.GetInt ("Level"));
	}

	public void DisableTextBox () {
		textBox.SetActive (false);
		isActive = false;
		InteractionTrigger.typing = false;
		player.canMove = true;

		if (!answer) {
			answer = true;
			StartCoroutine (WrongAnswer ());
		}
	}

	public void ReloadScript (string[] theText) {
		if (theText != null) {
			textLines = theText;
			currentLine = 0;
			endAtLine = textLines.Length - 1;
		}
	}
}
