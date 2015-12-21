using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

	//Esses dois métodos fazem essencialmente a mesma coisa
	public void LoadLevel(string name)
    {
		//Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}
	public void QuitRequest()
    {
		//Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel()
    {
		//Debug.Log(PlayerPrefs.GetInt("LastScore: ")); //Aqui é um jeito de imprimir o valor salvo do PlayerPrefs.
		//if(LifeCounter.lifeRemain > 0 && PlayerPrefs.GetInt("LastScore") >= ScoreKeeper.minWaveToLevelUp)
		if(LifeCounter.lifeRemain > 0 && gameObject.GetComponent<ScoreKeeper>().wave >= ScoreKeeper.minWaveToLevelUp)
        {
			gameObject.GetComponent<ScoreKeeper>().SaveScore(); //Precisa da referencia pro script, que coloquei em um mesmo objeto os 3 pra facilitar.
			gameObject.GetComponent<ScoreKeeper>().WaveUp(); //increase +1 on Waves to get harder each level
			//TransitionScene(); // load transition scene before next level
			Application.LoadLevel(Application.loadedLevel + 1); //load next level
		}
	}
	public void TransitionScene(){
		LoadLevel("Transition Scene"); //Name of the Scene		
		//Debug.Log("Transition Scene");	
	}
	
}


