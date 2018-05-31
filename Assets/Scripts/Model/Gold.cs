using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {

	public float moveForce = 50f;//1m/s
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().AddForce(Vector2.left * moveForce);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
