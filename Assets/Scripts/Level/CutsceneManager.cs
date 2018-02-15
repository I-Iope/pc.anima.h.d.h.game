using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour {

	public Sprite[] images;
	public Image canvasImage;

	public float waitTime;
	public float fadeTime;
	public float imageTime;
	public float darkTime;

	public int level;

	IEnumerator Start () {
		canvasImage.canvasRenderer.SetAlpha (0.0f);
		yield return new WaitForSeconds (waitTime);

		foreach (Sprite image in images) {
			canvasImage.sprite = image;
			canvasImage.CrossFadeAlpha (1.0f, fadeTime, false);

			yield return new WaitForSeconds (fadeTime + imageTime);

			canvasImage.CrossFadeAlpha (0.0f, fadeTime, false);

			yield return new WaitForSeconds (fadeTime + darkTime);
		}

		PlayerPrefs.SetInt ("Level", level);
		PlayerPrefs.SetFloat ("PositionX", -53f);
		PlayerPrefs.SetFloat ("PositionY", 0.0f);
		PlayerPrefs.SetInt ("LevelAdvancement", 0);

		SceneManager.LoadScene (level, LoadSceneMode.Single);
	}
}

