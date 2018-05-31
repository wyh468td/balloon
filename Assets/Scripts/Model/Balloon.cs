using UnityEngine;
using System.Collections;

public class Balloon : LeanTouchBaseManager
{
	public float moveForce = 365f;
	public float power = 100;//气球的力
	public SpaceType spaceType;
	private Vector3 touchBegin;

	void Awake () {
		
	}
	// Use this for initialization
	void Start ()
	{
		GetComponent<Rigidbody2D>().AddForce(Vector2.right * moveForce);
		spaceType = SpaceType.Sky;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		//Debug.Log("OnCollisionEnter2D:" + coll.gameObject.name);
		if (coll.gameObject.name.Equals ("gold")) {
			
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		//Debug.Log("OnTriggerEnter2D:" + coll.tag);
		if (coll.tag == "gold") {
			//Debug.Log ("destroy");
			Destroy (coll.gameObject);
		} else if (coll.tag == "laser") {
			Destroy (coll.gameObject);
		}

	}

	void FlyUp (float upPower) {
		GetComponent<Rigidbody2D>().AddForce(Vector2.up * upPower);
	}

	void FlyDown (float downPower) {
		GetComponent<Rigidbody2D>().AddForce(Vector2.down * downPower);
	}

	protected override void OnEnable()
	{
		Lean.LeanTouch.OnFingerUp       += OnFingerUp;
		Lean.LeanTouch.OnFingerDown     += OnFingerDown;
	}

	protected override void OnDisable()
	{
		Lean.LeanTouch.OnFingerUp       -= OnFingerUp;
		Lean.LeanTouch.OnFingerDown     -= OnFingerDown;
	}

	protected override void OnFingerUp(Lean.LeanFinger finger)
	{
		Vector3 touchEnd = Camera.main.ScreenToWorldPoint(finger.ScreenPosition);
		string newRtn;
		float dx = touchEnd.x - touchBegin.x;
		float dy = touchEnd.y - touchBegin.y;
		if (Mathf.Abs(dx) > Mathf.Abs(dy)) {
			if (dx > 0) {
				newRtn = "right";
			} else {
				newRtn = "left";
			}
		} else {
			if (dy > 0) {
				newRtn = "up";
			} else {
				newRtn = "down";
			}
		}
		switch (newRtn) {
		case "up":
			FlyUp(Mathf.Abs(dy) * power);
			break;
		case "down":
			FlyDown(Mathf.Abs(dy) * power);
			break;
		default:
			break;
		}
	}

	protected override void OnFingerDown(Lean.LeanFinger finger)
	{
		touchBegin = Camera.main.ScreenToWorldPoint(finger.ScreenPosition);
	}
}

