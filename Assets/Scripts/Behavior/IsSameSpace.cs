using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class InSameSpace : Conditional {
	
	public SharedTransform target;
	public SharedInt int1;
	public override TaskStatus OnUpdate()
	{
		if (((int)target.Value.GetComponent<Balloon> ().spaceType) == int1.Value) {
			return TaskStatus.Success;
		}
		return TaskStatus.Failure;
	}
}
