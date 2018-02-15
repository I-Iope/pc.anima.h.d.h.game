using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalFade : MonoBehaviour {

	public float waitTime;
	public int loadScene;

	IEnumerator Start () {
		for (int cont = 0; cont < 20; cont ++) {
			GetComponent<SpriteRenderer> ().color += new Color (0, 0, 0, 0.05f);
			yield return new WaitForSeconds (waitTime);
		}

			yield return new WaitForSeconds (4);
		SceneManager.LoadScene (loadScene);
	}
}
