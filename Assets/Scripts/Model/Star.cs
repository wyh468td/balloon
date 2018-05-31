using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour {
	public float moveForce = 50f;//1m/s
	public int minRotation = 30;
	public int maxRotation = 60;
	// Use this for initialization
	void Start () {
		int rotation = Random.Range (minRotation, maxRotation);
		transform.Rotate(new Vector3(0, 0, rotation));
		float eur = (360 - rotation) * Mathf.Deg2Rad;
		float forceY = Mathf.Abs(moveForce * Mathf.Sin(eur));
		float forceX = Mathf.Abs(moveForce * Mathf.Cos(eur));
		Vector2 ForceDirect = new Vector2(Vector2.left.x * forceX, Vector2.down.y * forceY);
		GetComponent<Rigidbody2D>().AddForce(ForceDirect);
	}

	// Update is called once per frame
	void Update () {

	}
}
