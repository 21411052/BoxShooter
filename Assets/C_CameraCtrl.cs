using UnityEngine;
using System.Collections;

public class C_CameraCtrl : MonoBehaviour {
	private C_Player c_player;
	
	void Start () {
		c_player = GameObject.FindWithTag("Player").GetComponent< C_Player >();
	}
}