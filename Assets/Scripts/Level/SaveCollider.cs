using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCollider : MonoBehaviour {

	private bool onCollision;
	private float positionX;
	private float positionY;
	private Animator anim;
	public AudioClip clipAudio;
	public AudioSource audioSource;
	public AudioSource generalAudioSource;

	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		anim.speed = 0;
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Player" ) {
			positionX = collider.transform.position.x;
			positionY = collider.transform.position.y;
			onCollision = true;
			}
	}

	void OnTriggerExit2D (Collider2D collider) {
		if (collider.gameObject.tag == "Player" ) {
			onCollision = false;
		}
	}

	void Update () {
		if (Input.GetButtonDown ("Interact") && onCollision) {
			PlayerPrefs.SetFloat ("PositionX", positionX);
			PlayerPrefs.SetFloat ("PositionY", positionY);
			PlayerPrefs.SetInt ("LevelAdvancement", AdvancementController.advancementCount);
			Action ();	
		}
	}

	private void Action () {
		audioSource.clip = clipAudio;
		audioSource.Play();
		anim.speed = 1;
		anim.Rebind ();
	}
}
