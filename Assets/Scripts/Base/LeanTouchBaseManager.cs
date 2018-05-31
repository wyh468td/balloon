using UnityEngine;
using System.Collections;

public class LeanTouchBaseManager : MonoBehaviour {
	/// <summary>
	/// is debug = 1 , is not debug = 0
	/// </summary>
	protected int debugLeanTouch = 0;
	// 如果需要点击物体跟着手指移动则需要 needMove = 1
	protected int needMove = 0;
	protected bool canTouch = true;
	protected bool canUp = false;

	[Tooltip("This stores the layers we want the raycast to hit (make sure this GameObject's layer is included!)")]
	protected LayerMask LayerMask = UnityEngine.Physics.DefaultRaycastLayers;

	[Tooltip("The previously selected GameObject")]
	protected GameObject SelectedGameObject;

	// This stores the finger that's currently dragging this GameObject
	protected Lean.LeanFinger draggingFinger;

	protected virtual void OnEnable()
	{
		// Hook events
		Lean.LeanTouch.OnFingerDown     += OnFingerDown;
		Lean.LeanTouch.OnFingerSet      += OnFingerSet;
		Lean.LeanTouch.OnFingerUp       += OnFingerUp;
		Lean.LeanTouch.OnFingerDrag     += OnFingerDrag;
		Lean.LeanTouch.OnFingerTap      += OnFingerTap;
		Lean.LeanTouch.OnFingerSwipe    += OnFingerSwipe;
		Lean.LeanTouch.OnFingerHeldDown += OnFingerHeldDown;
		Lean.LeanTouch.OnFingerHeldSet  += OnFingerHeld;
		Lean.LeanTouch.OnFingerHeldUp   += OnFingerHeldUp;
		Lean.LeanTouch.OnMultiTap       += OnMultiTap;
		Lean.LeanTouch.OnDrag           += OnDrag;
		Lean.LeanTouch.OnSoloDrag       += OnSoloDrag;
		Lean.LeanTouch.OnMultiDrag      += OnMultiDrag;
		Lean.LeanTouch.OnPinch          += OnPinch;
		Lean.LeanTouch.OnTwistDegrees   += OnTwistDegrees;
		Lean.LeanTouch.OnTwistRadians   += OnTwistRadians;
	}

	protected virtual void OnDisable()
	{
		// Unhook events
		Lean.LeanTouch.OnFingerDown     -= OnFingerDown;
		Lean.LeanTouch.OnFingerSet      -= OnFingerSet;
		Lean.LeanTouch.OnFingerUp       -= OnFingerUp;
		Lean.LeanTouch.OnFingerDrag     -= OnFingerDrag;
		Lean.LeanTouch.OnFingerTap      -= OnFingerTap;
		Lean.LeanTouch.OnFingerSwipe    -= OnFingerSwipe;
		Lean.LeanTouch.OnFingerHeldDown -= OnFingerHeldDown;
		Lean.LeanTouch.OnFingerHeldSet  -= OnFingerHeld;
		Lean.LeanTouch.OnFingerHeldUp   -= OnFingerHeldUp;
		Lean.LeanTouch.OnMultiTap       -= OnMultiTap;
		Lean.LeanTouch.OnDrag           -= OnDrag;
		Lean.LeanTouch.OnSoloDrag       -= OnSoloDrag;
		Lean.LeanTouch.OnMultiDrag      -= OnMultiDrag;
		Lean.LeanTouch.OnPinch          -= OnPinch;
		Lean.LeanTouch.OnTwistDegrees   -= OnTwistDegrees;
		Lean.LeanTouch.OnTwistRadians   -= OnTwistRadians;
	}

	protected virtual void OnFingerDown(Lean.LeanFinger finger)
	{
		if (debugLeanTouch == 1) {
			Debug.Log("Finger " + finger.Index + " began touching the screen");
		}
		// Raycast information
		var ray = finger.GetRay();
		var hit = default(RaycastHit);
		// Was this finger pressed down on a collider?
		if (Physics.Raycast(ray, out hit, float.PositiveInfinity, LayerMask) == true)
		{
			// Remove the color from the currently selected one?
			if (SelectedGameObject != null)
			{
				if (debugLeanTouch == 1) {
					ColorGameObject (SelectedGameObject, Color.white);
				}
			}
			SelectedGameObject = hit.collider.gameObject;
			if (debugLeanTouch == 1) {
				ColorGameObject (SelectedGameObject, Color.green);
			}
			if (needMove == 1) {
				draggingFinger = finger;
			}
		}
	}

	protected virtual void OnFingerSet(Lean.LeanFinger finger)
	{
		if (debugLeanTouch == 1) {
			Debug.Log ("Finger " + finger.Index + " is still touching the screen");
		}
	}

	protected virtual void OnFingerUp(Lean.LeanFinger finger)
	{
		if (debugLeanTouch == 1) {
			Debug.Log ("Finger " + finger.Index + " finished touching the screen");
		}
		if (needMove == 1) {
			// Was the current finger lifted from the screen?
			if (finger == draggingFinger)
			{
				// Unset the current finger
				draggingFinger = null;
			}
		}
	}

	protected virtual void OnFingerDrag(Lean.LeanFinger finger)
	{
		if (debugLeanTouch == 1) {
			Debug.Log ("Finger " + finger.Index + " moved " + finger.DeltaScreenPosition + " pixels across the screen");
		}
	}

	protected virtual void OnFingerTap(Lean.LeanFinger finger)
	{
		if (debugLeanTouch == 1) {
			Debug.Log ("Finger " + finger.Index + " tapped the screen");
		}
		// Raycast information
		var ray = finger.GetRay();
		var hit = default(RaycastHit);

		// Was this finger pressed down on a collider?
		if (Physics.Raycast(ray, out hit, float.PositiveInfinity, LayerMask) == true)
		{
			// Remove the color from the currently selected one?
			if (SelectedGameObject != null)
			{
				if (debugLeanTouch == 1) {
					ColorGameObject (SelectedGameObject, Color.white);
				}
			}

			SelectedGameObject = hit.collider.gameObject;
			if (debugLeanTouch == 1) {
				ColorGameObject (SelectedGameObject, Color.green);
			}
		}
	}

	protected virtual void OnFingerSwipe(Lean.LeanFinger finger)
	{
		if (debugLeanTouch == 1) {
			Debug.Log ("Finger " + finger.Index + " swiped the screen");
		}
	}

	protected virtual void OnFingerHeldDown(Lean.LeanFinger finger)
	{
		if (debugLeanTouch == 1) {
			Debug.Log ("Finger " + finger.Index + " began touching the screen for a long time");
		}
	}

	protected virtual void OnFingerHeld(Lean.LeanFinger finger)
	{
		if (debugLeanTouch == 1) {
			Debug.Log ("Finger " + finger.Index + " is still touching the screen for a long time");
		}
	}

	protected virtual void OnFingerHeldUp(Lean.LeanFinger finger)
	{
		if (debugLeanTouch == 1) {
			Debug.Log ("Finger " + finger.Index + " stopped touching the screen for a long time");
		}
	}

	protected virtual void OnMultiTap(int fingerCount)
	{
		if (debugLeanTouch == 1) {
			Debug.Log ("The screen was just tapped by " + fingerCount + " finger(s)");
		}
	}

	protected virtual void OnDrag(Vector2 pixels)
	{
		if (debugLeanTouch == 1) {
			Debug.Log ("One or many fingers moved " + pixels + " across the screen");
		}
	}

	protected virtual void OnSoloDrag(Vector2 pixels)
	{
		if (debugLeanTouch == 1) {
			Debug.Log ("One finger moved " + pixels + " across the screen");
		}
	}

	protected virtual void OnMultiDrag(Vector2 pixels)
	{
		if (debugLeanTouch == 1) {
			Debug.Log ("Many fingers moved " + pixels + " across the screen");
		}
	}

	protected virtual void OnPinch(float scale)
	{
		if (debugLeanTouch == 1) {
			Debug.Log ("Many fingers pinched " + scale + " percent");
		}
	}

	protected virtual void OnTwistDegrees(float angle)
	{
		if (debugLeanTouch == 1) {
			Debug.Log ("Many fingers twisted " + angle + " degrees");
		}
	}

	protected virtual void OnTwistRadians(float angle)
	{
		if (debugLeanTouch == 1) {
			Debug.Log ("Many fingers twisted " + angle + " radians");
		}
	}
	//跟着手指移动方法
	protected virtual void LateUpdate()
	{
		// If there is an active finger, move this GameObject based on it
		if (draggingFinger != null)
		{
			// Does the main camera exist?
			if (Camera.main != null)
			{
				// Convert this GameObject's world position into screen coordinates and store it in a temp variable
				var screenPosition = Camera.main.WorldToScreenPoint(SelectedGameObject.transform.position);

				// Modify screen position by the finger's delta screen position
				screenPosition += (Vector3)draggingFinger.DeltaScreenPosition;

				// Convert the screen position into world coordinates and update this GameObject's world position with it
				SelectedGameObject.transform.position = Camera.main.ScreenToWorldPoint(screenPosition);
			}
		}
	}
	private static void ColorGameObject(GameObject gameObject, Color color)
	{
		// Make sure the GameObject exists
		if (gameObject != null)
		{
			// Get renderer from this GameObject
			var renderer = gameObject.GetComponent<Renderer>();

			// Make sure the Renderer exists
			if (renderer != null)
			{
				// Get material copy from this renderer
				var material = renderer.material;

				// Make sure the material exists
				if (material != null)
				{
					// Set new color
					material.color = color;
				}
			}
		}
	}
}
