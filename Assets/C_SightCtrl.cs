using UnityEngine;
using System.Collections;

public class C_SightCtrl : MonoBehaviour {
	private C_Player c_player;
	private C_CameraCtrl c_mainCamera , c_subCamera;
	private bool cameraSight = true;		// １人称視点：true  , ３人称視点：flase
	
	// ■■■■■■
	void Start () {
		c_player		= GameObject.Find("Player").GetComponent< C_Player >();
		c_mainCamera	= GameObject.Find("Main Camera").GetComponent< C_CameraCtrl >();
		c_subCamera	= GameObject.Find("Sub Camera").GetComponent< C_CameraCtrl >();
		

	}

}