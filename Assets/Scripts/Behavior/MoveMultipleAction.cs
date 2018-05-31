using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using DG.Tweening;


public class MoveMultipleAction : Action {
	

	public SharedTransform target;
	public SharedInt spaceType;
	public float animationTime;//动画时长
	public MoveMultipleActionType MoveType;
	public MoveMultipleActionType MoveMultipleActionType {
		get;
	}
	private int tempSpaceType;
	private float cameraHalfHeight;//摄像机一半高度
	private float halfTransformHeight;//一半的高度
	private bool isMoved = false;
	private DG.Tweening.Sequence sequence;

	public override void OnAwake() {
		cameraHalfHeight = Global.getInstance ().cameraWorldSize.y / 2;
		halfTransformHeight = transform.localScale.y * transform.GetComponent<SpriteRenderer> ().sprite.bounds.size.y / 2;
	}
	public override void OnStart() {
		isMoved = false;
		sequence = DOTween.Sequence ();
		switch (MoveType) {
		case MoveMultipleActionType.ToTarget:
			float y = 0;
			tempSpaceType = (int)target.Value.GetComponent<Balloon> ().spaceType;
			switch (target.Value.GetComponent<Balloon> ().spaceType) {
			case SpaceType.Water:
				y = -cameraHalfHeight * 2;
				break;
			case SpaceType.Sky:
				y = 0;
				break;
			case SpaceType.Aether:
				y = cameraHalfHeight * 2;
				break;
			}
			Tweener tweener = transform.DOMoveY (y, animationTime);
			tweener.SetEase (Ease.InOutBack);
			sequence.Append (tweener.OnComplete (() => moveFinishCallback ()));
			break;
		case MoveMultipleActionType.UpAndDown:
			sequence.Append (transform.DOMoveY (transform.position.y + cameraHalfHeight - halfTransformHeight, animationTime).SetEase (Ease.Linear));
			sequence.Append (transform.DOMoveY (transform.position.y, animationTime).SetEase (Ease.Linear));
			sequence.Append (transform.DOMoveY (transform.position.y - cameraHalfHeight + halfTransformHeight, animationTime).SetEase (Ease.Linear));
			sequence.Append (transform.DOMoveY (transform.position.y, animationTime).SetEase (Ease.Linear).OnComplete (() => moveFinishCallback ()));
			break;
		}

	}

	public override void OnEnd() {
		sequence.Kill ();
	}

	public override TaskStatus OnUpdate() {
		if (isMoved) {
			return TaskStatus.Success;
		}
		return TaskStatus.Running;
	}

	public void moveFinishCallback(){
		isMoved = true;
		spaceType.Value = tempSpaceType;
	}
}
