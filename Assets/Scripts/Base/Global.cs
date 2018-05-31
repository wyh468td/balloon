using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Global {
	public Vector3 cameraWorldSize;//摄像机世界坐标系下大小
	static public Global instance = null;
	static public Global getInstance(){
		if (instance == null) {
			instance = new Global ();
			Application.targetFrameRate = 60;
			return instance;
		} else {
			return instance;
		}
	}
}