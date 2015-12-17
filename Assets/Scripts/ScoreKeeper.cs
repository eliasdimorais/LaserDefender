using UnityEngine;
using System.Collections;
using UnityEngine.UI;	

public class ScoreKeeper : MonoBehaviour {

	public int score = 0;
	private Text myText;
	int nextSound = 1000;
	public AudioClip levelUp;
	
	void Start(){
		myText = GetComponent<Text>();
		Reset();
	}
	public void Score(int points){
		Debug.Log("Scored points");
		score += points;
		myText.text = score.ToString();
		if(score >= nextSound){
			AudioSource.PlayClipAtPoint(levelUp, transform.position);
			nextSound *= 2;
		}
	}
	
	public void Reset(){
		score = 0;
	}
}
