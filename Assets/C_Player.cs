using UnityEngine;
using System.Collections;

public class C_Player : MonoBehaviour {
	private	CharacterController charaCon;		// キャラクターコンポーネント用の変数
	private Vector3	move = Vector3.zero;		// キャラ移動量.
	private float	speed = 5.0f;
	private const float GRAVITY = 9.8f;
	private float jumpPower = 7.0f;
	private float		rotationSpeed = 150.0f;	// プレイヤーの回転速度
	private bool		moveType = true;			// １人称視点動作：true , ３人称視点動作：false
	public GameObject targetEnemy = null;			// ターゲット格納用の変数.


	
	void Start(){
		charaCon = GetComponent< CharacterController >();  

	    // マウスカーソルを削除する
		Cursor.visible = false;
		// マウスカーソルを画面内にロックする
		Screen.lockCursor = true;

	}
	
	void Update () {
		playerMove_1stParson ();
		if (moveType) {
			playerMove_1stParson ();		// １人称視点動作
		}
	}

	
	// ■■■１人称視点の移動■■■
	private void playerMove_1stParson(){
	    // ▼▼▼移動量の取得▼▼▼
	    float y = move.y;
		move = new Vector3(Input.GetAxis("Horizontal") , 0.0f , Input.GetAxis("Vertical"));		// 左右上下のキー入力を取得し、移動量に代入.
		Vector3 forward = move;	// 移動方向を取得.
		move = transform.TransformDirection(move);
		move *= speed;				// 移動速度を乗算.

	    // ▼▼▼重力／ジャンプ処理▼▼▼
	    move.y += y;
		if (charaCon.isGrounded) {
			if (Input.GetKeyDown (KeyCode.Space)) {	// ジャンプ処理.
				 move.y = jumpPower;
		  }
		}
	    move.y -= GRAVITY * Time.deltaTime;	// 重力を代入.

		// ▼▼▼移動処理▼▼▼
	   	charaCon.Move(move * Time.deltaTime);	// キャラ移動.
	}

	// ■■■動作切り替え■■■
	public void changeMoveType(bool type){
		moveType = type;
	}

	}

	


