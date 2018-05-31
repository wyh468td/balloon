using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public GameObject bg;
	public float speed = 5;
	private float bgWidth;
	private float cameraHalfWidth;//摄像机一半宽度
	void Awake () {
		bgWidth = bg.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite.bounds.size.x;
		cameraHalfWidth = Global.getInstance ().cameraWorldSize.x / 2;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		BackgroundUpdate ();
	}

	void BackgroundUpdate() {
		Vector3 pos = new Vector3 (speed * Time.deltaTime, 0, 0);
		for (int i = 0; i < bg.transform.childCount; i++) {
			if (bg.transform.GetChild (i).transform.position.x <= 0 - cameraHalfWidth - bgWidth / 2) {
				bg.transform.GetChild (i).transform.position = new Vector3 (bg.transform.GetChild (i%2==0 ? i+1 : i-1).transform.position.x + bgWidth,
					bg.transform.GetChild (i).transform.position.y, 0);
			}
			bg.transform.GetChild (i).transform.position -= pos;
		}
	}
}
