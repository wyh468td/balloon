using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraFollow : MonoBehaviour 
{
	private Transform player;		// Reference to the player's transform.
	public float cameraMoveY = 2;
	private float cameraMoveYDeltaTime;
	private float cameraHalfHeight;//摄像机一半高度

	void Awake ()
	{
		// Setting up the reference.
		player = GameObject.FindGameObjectWithTag("Player").transform;
		//transform.DOMove (new Vector3(5, 0, 0), 10);
		cameraHalfHeight = Global.getInstance ().cameraWorldSize.y / 2;
		cameraMoveYDeltaTime = cameraHalfHeight * Time.deltaTime * cameraMoveY;
	}

	void FixedUpdate ()
	{
		TrackPlayer();
	}
	
	
	void TrackPlayer ()
	{
		float balloonY = player.transform.position.y;
		float cameraY = transform.position.y;
		if (balloonY >= cameraHalfHeight) {
			if (cameraY != cameraHalfHeight * 2) {
				if (player.GetComponent<Balloon> ().spaceType != SpaceType.Aether) {
					player.GetComponent<Balloon> ().spaceType = SpaceType.Aether;
				}
				transform.position += new Vector3 (0, cameraMoveYDeltaTime, 0);
			}
			if(cameraY > cameraHalfHeight * 2){
				transform.position = new Vector3 (transform.position.x, cameraHalfHeight * 2, transform.position.z);
			}
		} else if (balloonY >= -cameraHalfHeight && balloonY <= cameraHalfHeight) {
			if (player.GetComponent<Balloon> ().spaceType != SpaceType.Sky) {
				player.GetComponent<Balloon> ().spaceType = SpaceType.Sky;
			}
			if(cameraY < 0){
				transform.position += new Vector3 (0, cameraMoveYDeltaTime, 0);
				if (transform.position.y > 0) {
					transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
				}
			} else if (cameraY > 0){
				transform.position -= new Vector3 (0, cameraMoveYDeltaTime, 0);
				if (transform.position.y < 0) {
					transform.position = new Vector3 (transform.position.x, 0, transform.position.z);
				}
			}
		} else {
			if(cameraY != -cameraHalfHeight * 2){
				if (player.GetComponent<Balloon> ().spaceType != SpaceType.Water) {
					player.GetComponent<Balloon> ().spaceType = SpaceType.Water;
				}
				transform.position -= new Vector3 (0, cameraMoveYDeltaTime, 0);
			}
			if(cameraY < -cameraHalfHeight * 2){
				transform.position = new Vector3 (transform.position.x, -cameraHalfHeight * 2, transform.position.z);
			}
		}
	}
}
