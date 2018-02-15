using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2D;
	private Animator animator;

	public LayerMask plataform;
	public Vector2 floorCollisionPoint;

	[SerializeField]
	private float velocity;
	private float horizontal;
	private bool eRightSide;

	public bool onFloor;
	public float radius;
	public float jumpForce;
	public bool canMove;
	
	void Start () {
		rb2D = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		eRightSide = (transform.localScale.x > 0);
	}

	void Update () {
		if (!canMove) {
			animator.SetFloat ("velocity", 0);
			animator.SetLayerWeight (1, 0); 
			animator.SetBool ("fall", false);
			rb2D.velocity = new Vector2(0, rb2D.velocity.y);

			return;
		}

		horizontal = Input.GetAxis ("Horizontal");

		InputControll ();
		Moviment (horizontal);
		ChangeDirection (horizontal);
		IsOnTheFloor ();
		LayersControll ();

		if (transform.position.y < -14.45) {
			SceneManager.LoadScene (PlayerPrefs.GetInt("Level"), LoadSceneMode.Single);
		}
	}

	private void Moviment (float horiz) {
		rb2D.velocity = new Vector2((horiz * velocity), rb2D.velocity.y);

		animator.SetFloat ("velocity", Mathf.Abs(horiz));
	}

	private void ChangeDirection (float horiz) {
		if ((horiz > 0 && !eRightSide) || (horiz < 0 && eRightSide)) {
			eRightSide = !eRightSide;
			transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
		}
	}

	private void OnDrawGizmos () {
		var positionPoint = floorCollisionPoint;
		positionPoint.x += transform.position.x;
		positionPoint.y += transform.position.y;

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (positionPoint, radius);
	}

	private void IsOnTheFloor () {
		var positionPoint = floorCollisionPoint;
		positionPoint.x += transform.position.x;
		positionPoint.y += transform.position.y;

		onFloor = Physics2D.OverlapCircle (positionPoint, radius, plataform);
	}

	private void Jump () {
		if (onFloor && rb2D.velocity.y <= 0) {
			rb2D.AddForce(new Vector2(0, jumpForce));
			animator.SetTrigger ("jump");
		}
	}

	private void InputControll () {
		if (Input.GetButtonDown("Jump")) {
			Jump ();
		}
	}

	private void LayersControll () {
		// Layer 1 = Jump
		if (onFloor) {
			animator.SetLayerWeight (1, 0); 
			animator.SetBool ("fall", false);
			return;
		}
		animator.SetLayerWeight (1, 1); 
		Fall ();
	}

	private void Fall () {
		if (rb2D.velocity.y <= 0) {
			animator.SetBool ("fall", true);
			animator.ResetTrigger ("jump");
		}
	}
}
