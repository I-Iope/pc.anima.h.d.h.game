using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

	public float backgroundSize;
	public float paralaxSpeed;

	private Transform cameraTransform;
	private Transform[] layers;
	private float viewZone = 10;
	private float lastCameraX;
	private int leftIndex;
	private int rightIndex;

	private void Start() {
		cameraTransform = Camera.main.transform;
		lastCameraX = cameraTransform.position.x;
		layers = new Transform[transform.childCount];
		leftIndex = 0;
		rightIndex = (layers.Length - 1);

		for (int i = 0; i < transform.childCount; i++)
			layers [i] = transform.GetChild (i);
	}

	private void Update() {
		float deltaX = cameraTransform.position.x - lastCameraX;
		transform.position += Vector3.right * (deltaX * paralaxSpeed);
		lastCameraX = cameraTransform.position.x;

		if (cameraTransform.position.x < (layers [leftIndex].transform.position.x + viewZone))
			ScrollLeft();		

		if (cameraTransform.position.x > (layers [rightIndex].transform.position.x - viewZone))
			ScrollRight();
	}

	private void ScrollLeft() {
		Vector3 position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
		position.y = layers [rightIndex].position.y;
		layers [rightIndex].position = position;
		leftIndex = rightIndex;
		rightIndex--;

		if (rightIndex < 0) 
			rightIndex = layers.Length - 1;
	}

	private void ScrollRight() {
		Vector3 position = Vector3.right * (layers[leftIndex].position.x + backgroundSize);
		position.y = layers [rightIndex].position.y;
		layers [rightIndex].position = position;
		rightIndex = leftIndex;
		leftIndex++;

		if (leftIndex == layers.Length) 
			leftIndex = 0;
	}
}
