

using UnityEngine;
using System.Collections;

public enum ScreenDirection
{
	ScreenDirectionVertical,
	ScreenDirectionHorizon
}

public class ScreenAdapt : MonoBehaviour
{
	public float designRatio = 0.625f;
	public float designWidth = 720.0f;
	public float designHeight = 1136.0f;

	public ScreenDirection screenDirection = ScreenDirection.ScreenDirectionVertical;

	private float aspectRatio = 0.0f;
	private Camera myCamera = null;

	void Awake ()
	{
		this.myCamera = this.GetComponent<Camera> ();
		switch (this.screenDirection) {
		case ScreenDirection.ScreenDirectionVertical:
			this.adaptScreenVertical ();
			break;
		case ScreenDirection.ScreenDirectionHorizon:
			this.adaptScreenHorizon ();
			break;
		}
		Vector3 worldPoint = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
		Global.getInstance ().cameraWorldSize = new Vector2 (worldPoint.x * 2, worldPoint.y * 2);
	}
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void adaptScreenVertical ()
	{
		this.aspectRatio = Screen.width * 1.0f / Screen.height;
		if (this.aspectRatio <= this.designRatio) {
			// thin
			this.myCamera.orthographicSize = this.designHeight * 1.0f / 100 / 2;
		} else {
			// fat
			this.myCamera.orthographicSize = this.designWidth * 1.0f / this.aspectRatio / 100 / 2;
		}
	}

	void adaptScreenHorizon ()
	{
		this.aspectRatio = Screen.height * 1.0f / Screen.width;
		if (this.aspectRatio <= this.designRatio) {
			// thin
			this.myCamera.orthographicSize = this.designWidth * 1.0f * this.aspectRatio / 100 / 2;
		} else {
			// fat
			this.myCamera.orthographicSize = this.designHeight * 1.0f / 100 / 2;
		}
	}
}
