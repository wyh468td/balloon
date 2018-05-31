using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Shoot : Action {
	public SharedTransform bullet;
	public float moveForce = 50f;//1m/s
	public Vector3 positionOffset;//位置偏移
	public override void OnAwake() {
	}
	public override void OnStart() {
		Transform tempBullet = MonoBehaviour.Instantiate(bullet.Value, transform.position + positionOffset, transform.rotation);
		//tempBullet.parent = transform;
		tempBullet.GetComponent<Rigidbody2D>().AddForce(Vector2.left * moveForce);
	}
}
