using UnityEngine;
using System.Collections;
using UnityEngine.UI;	

public class ScoreKeeper : MonoBehaviour {

	public static int score = 0;
	private Text myText;
	int nextSound = 1000;
	public AudioClip levelUp;
	public static int lastScore = 0;
	
	void Start(){
		myText = GetComponent<Text>();
		Reset();
	}
	public void Score(int points){
		score += points;
		Debug.Log("Scored: " + score);
		myText.text = score.ToString();
		if(score >= nextSound){
			AudioSource.PlayClipAtPoint(levelUp, transform.position);
			nextSound *= 2;
			SaveScore();
		}
		Debug.Log("Last Score Saved: " + lastScore);
	}
	
	public static void Reset(){
		score = 0;
	}
	
	public static void SaveScore(){
		lastScore = ScoreKeeper.score;
	}
}
