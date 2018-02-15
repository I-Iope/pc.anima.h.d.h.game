using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitialFade : MonoBehaviour {

	public Image canvasImage;

	public float darkTime;

	IEnumerator Start () {
		canvasImage.canvasRenderer.SetAlpha (1.0f);
		canvasImage.CrossFadeAlpha (0.0f, darkTime, false);
		yield return new WaitForSeconds (darkTime * 2);

		DestroyObject (gameObject);
	}
}

