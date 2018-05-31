using UnityEngine;
using System.Collections;

public class ItemManager : MonoBehaviour
{
	public float spawnTime = 1f;		// The amount of time between each spawn.
	public float spawnDelay = 1f;		// The amount of time before spawning starts.
	public float minDistanceX = 0.3f;	//item放置在屏幕右侧的最小距离
	public float maxDistanceX = 3.0f;	//item放置在屏幕右侧的最大距离
	public bool isCameraWith = false;	//是否在屏幕外侧随机摆放
	public bool isCameraHeight = false;	//是否依据屏幕高度随机摆放
	private float cameraHalfWidth;		//摄像机一半宽度
	private float cameraHalfHeight;		//摄像机一半高度
	public GameObject[] enemies;		// Array of enemy prefabs.
	// Use this for initialization
	void Awake () {
	}

	void Start ()
	{
		cameraHalfWidth = Global.getInstance ().cameraWorldSize.x / 2;
		cameraHalfHeight = Global.getInstance ().cameraWorldSize.y / 2;
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", spawnDelay, spawnTime);
	}
	
	void Spawn()
	{
		
		int enemyIndex = Random.Range(0, enemies.Length);
		float enemyDistanceX = Random.Range (minDistanceX, maxDistanceX);
		float enemyDistanceY = 0;
		if (isCameraHeight) {
			enemyDistanceY = Random.Range (-cameraHalfHeight, cameraHalfHeight);
		}
		Instantiate(enemies[enemyIndex], new Vector3(isCameraWith ? cameraHalfWidth + enemyDistanceX : transform.position.x + enemyDistanceX, transform.position.y + enemyDistanceY, 0), transform.rotation);
	}
}

