using UnityEngine;
using System.Collections;
 
public class Enemy : MonoBehaviour {
	     
	    public Transform player;    //プレイヤーを代入
	    public float speed = 3; //移動速度
	    public float limitDistance = 0.5f; //敵キャラクターがどの程度近づいてくるか設定(この値以下には近づかない）
	    public float score = 10;    //敵を倒した際にもらえるスコア
	    public GameObject explosion;    //爆発エフェクト
	    public ScoreSystem Score;   //スコアシステムを使用する
	    private bool isQuitting = false;

	public float life = 30; //敵の体力
	 
	    private bool isGround = false;
	 
	    void Start () {
		        //Playerオブジェクトを検索し、参照を代入
		        player = GameObject.FindGameObjectWithTag("Player").transform;
		        Score = GameObject.Find("ScoreSystem").GetComponent<ScoreSystem>(); //スコアシステムを代入
		    }
	     
	    void Update () {
		        Vector3 playerPos = player.position;                 //プレイヤーの位置
		        Vector3 direction = playerPos - transform.position; //方向と距離を求める。
		        float distance = direction.sqrMagnitude;            //directionから距離要素だけを取り出す。
		        direction = direction.normalized;                   //単位化（距離要素を取り除く）
		        direction.y = 0f;                                   //後に敵の回転制御に使うためY軸情報を消去。これにより敵上下を向かなくなる。
		 
		//プレイヤーの距離が一定以上でなければ、敵キャラクターはプレイヤーへ近寄ろうとしない
		if (distance >= limitDistance) {
				
			//プレイヤーとの距離が制限値以上なので普通に近づく
			transform.position = transform.position + (direction * speed * Time.deltaTime);

		} else
			Debug.Log (distance);
		 
		        //プレイヤーの方を向く
		        transform.rotation = Quaternion.LookRotation(direction);
		 
		        //重力落下処理（プレイヤーの距離関係なく下に移動する）
		        Vector3 rayPos = transform.position;
		        rayPos.y -= 1f;
		 
		        //地面衝突判定処理。（今回は直接座標を操作しているため実装したが、直接座標操作はあまり好ましくないため
		        //後でUnityのキャラクター操作機能を用いた敵キャラクターの実装を紹介する。）
		if (!Physics.Raycast (rayPos, Vector3.down, 0.1f)) {
				//地面からわずかに浮くのは、わざとである。（キャラクター操作機能（CharacterControllerを用いれば起きない））
			transform.position = transform.position + (Vector3.down * 9.8f * Time.deltaTime);
			if (transform.position.y < 1f)
				transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
		}
		        //地面判定線を見れるようにする
	        Debug.DrawRay (rayPos, Vector3.down*1/10);
		 
		        //敵のY座標が-5以下の時自身を削除
		        if (transform.position.y <= -5f) {
			            Destroy(gameObject);
			        }
	 }
	//Dmage関数
	void Damage () {
		Destroy(gameObject);    //自身を消去
	}

	void OnApplicationQuit () {
		isQuitting = true;
	}

	void OnDestroy () {
		if(!isQuitting){
//			GameObject.Instantiate(explosion, transform.position, Quaternion.identity);
			Score.AddScore(score);  //修正箇所
		}
	}
		//Damage関数ここを修正していく
	public void Damage ( float damage ) {
		life -= damage; //体力から差し引く
		if(life <= 0){
			//体力が0以下になった時
			Dead(); //死亡処理
		}
 	}

	//死亡処理
	public void Dead () {
//		GameObject.Instantiate(explosion, transform.position, Quaternion.identity); //爆発パーティクルを生成
		Score.AddScore(score);  //スコアを加算
		Destroy(this.gameObject);   //自身を削除
	}
		    

}

	 
