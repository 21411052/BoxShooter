using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

	public readonly float maxLife = 100;    //最大体力（readonlyは変数の変更ができなくなる）
	public float life = 100;    //現在体力
	public GameObject GameOverGUI;
	private bool gameover = false;


	void Start () {
		life = maxLife; //体力を全回復させる
	}

	void Update () {
		if(life <= 0){
			//体力が0になったら
			Dead();
		}
		if(gameover == true){
			//アニメーションの切替

			//GAME OVERのGUIを表示する
			GameOverGUI.SendMessage("Lose");
		}
	}

	public void Damage (float damage) {
		life -= damage; //体力を減らす
	}

	//死亡処理（死亡時の演出）
	public void Dead () {
		GameOver(); //ゲームオーバーにする
	}

	//ゲームオーバー処理
	public void GameOver () {
		gameover = true;
		Application.LoadLevel("title"); //シーンの再読み込み
	}

	//体力を表示
	public bool flag = true;    //trueの時体力を表示させる

	void OnGUI () {
		if(flag){
			GUI.Label(new Rect(10,40,100,100),"Life "+ life);
		}
	}
}
