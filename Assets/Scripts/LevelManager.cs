using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	
	public float minScoreToLevelUp = 500;
	
	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}
	public void BackMenu(string name){
		Application.LoadLevel(name);
	}
	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel(){
		Debug.Log(ScoreKeeper.score);
		if(LifeCounter.lifeRemain > 0 && ScoreKeeper.lastScore >= minScoreToLevelUp){
			ScoreKeeper.SaveScore();
			ScoreUp();	
			Application.LoadLevel(Application.loadedLevel + 1);
		}
		Debug.Log ("New Level load: " + name);
	}

	public void ScoreUp(){
		minScoreToLevelUp += minScoreToLevelUp + 2000;
	}
	
}


