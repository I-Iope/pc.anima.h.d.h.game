using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioConnectorController : MonoBehaviour {

	public AudioClip audioClip;
	public AudioSource audioSource;
	public AudioSource generalAudioSource;
	public bool requireButtonPress;
	public bool stopPlayer;

	private bool waitForPress;
	private PlayerController playerController;
	private Animator anim;

	void Start () {
		playerController = FindObjectOfType<PlayerController> ();
		anim = gameObject.GetComponent<Animator> ();
	}

	void Update () {
		if (waitForPress && Input.GetButtonDown ("Interact")) {
			Action();	
		}

		if (stopPlayer) {
			if ((audioClip.length -0.3f) < audioSource.time) {
				playerController.canMove = true;
				stopPlayer = false;
				requireButtonPress = true;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.name == "Player") {
			if (requireButtonPress) {
				waitForPress = true;
				return;
			}

			if (stopPlayer) {
				playerController.canMove = false;
			}
			Action();
		}
	}

	void OnTriggerExit2D (Collider2D collider) {
		waitForPress = false;
		audioSource.Pause();
		anim.SetBool ("Collider", false);
	}

	private void Action () {
		audioSource.clip = audioClip;
		audioSource.Play();
		anim.SetBool ("Collider", true);
	}
}

		