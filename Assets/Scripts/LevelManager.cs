using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

	//Esses dois métodos fazem essencialmente a mesma coisa
	public void LoadLevel(string name)
    {
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}
	public void QuitRequest()
    {
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

	public void LoadNextLevel()
    {
		Debug.Log(PlayerPrefs.GetInt("LastScore: ")); //Aqui é um jeito de imprimir o valor salvo do PlayerPrefs.
		if(LifeCounter.lifeRemain > 0 && PlayerPrefs.GetInt("LastScore") >= ScoreKeeper.minWaveToLevelUp)
        {
			gameObject.GetComponent<ScoreKeeper>().SaveScore(); //Precisa da referencia pro script, que coloquei em um mesmo objeto os 3 pra facilitar.
			ScoreUp();	
			Application.LoadLevel(Application.loadedLevel + 1);
		}
	}

	public void ScoreUp()
    {
        //minScoreToLevelUp += minScoreToLevelUp + 2000; //Essa linha ficou meio ambigua pelo += e a mesma variavel depois.
        ScoreKeeper.minWaveToLevelUp += 3;
	}
	
}


