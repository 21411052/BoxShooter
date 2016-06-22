using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
	public GameObject bullet;
	public Transform spawn;
	public float speed = 1000f;

	//以下修正された変数
	public Transform rifle; //修正箇所
	private float time = 0f;    //経過時間
	public float interval = 0.0000001f;   //何秒おきに発砲するか

	void Update () {
		time += Time.deltaTime; //経過時間を加算

		if(Input.GetButton("Fire1")){
			if(time >= interval){
				Shoot();    //発砲
				time = 0f;  //初期化
			}
		}
	}

	void Shoot () {
		GameObject obj = GameObject.Instantiate(bullet)as GameObject;
		obj.transform.position = spawn.position;
		obj.GetComponent<Rigidbody>().AddForce (-rifle.forward * speed);    //修正箇所
		//銃の向きが元から反転しているため、併せてforwardも反転させる
	}
}