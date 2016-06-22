using UnityEngine;
using System.Collections;

public class ScoreSystem : MonoBehaviour {

	private float score;

	void Start () {
		score = 0;
	}

	public void AddScore (float addScore) {
		score += addScore;
	}

	public void SubtractScore (float subScore){
		score -= subScore;
	}

	void OnGUI () {
		GUI.Label(new Rect(10,10,100,100),"Score : "+score);
	}
}