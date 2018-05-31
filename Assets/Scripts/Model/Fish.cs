using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour {
	public float moveForce = 50f;//1m/s
	public int minRotation = 45;
	public int maxRotation = 60;
	// Use this for initialization
	void Start () {
		int rotation = Random.Range (minRotation, maxRotation);
		transform.Rotate(new Vector3(0, 0, 360 - rotation));
		float eur = (360 - rotation) * Mathf.Deg2Rad;   
		float forceY = Mathf.Abs(moveForce * Mathf.Sin(eur));  
		float forceX = Mathf.Abs(moveForce * Mathf.Cos(eur));  
		Vector2 ForceDirect = new Vector2(Vector2.left.x * forceX, Vector2.up.y * forceY);
		GetComponent<Rigidbody2D>().AddForce(ForceDirect);
		GetComponent<Rigidbody2D>().AddTorque (rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
