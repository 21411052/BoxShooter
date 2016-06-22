using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {

	//Dmage関数
	void Damage () {
		Destroy(gameObject);    //自身を消去
	}
}