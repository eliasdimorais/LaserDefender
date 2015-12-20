using UnityEngine;
using System.Collections;
using UnityEngine.UI;	

public class ScoreKeeper : MonoBehaviour
{
    #region Public Variables
    public static int minWaveToLevelUp = 3;  // Isso estava no LevelManager
    public int lastScore = 0, score = 0, wave = 1; //Tirei essas variaveis estaticas.
    public Text scoreText;  //Isso era privado, coloquei publico pra poder colocar uma referencia no GameController.
	public Text waveText;
    public AudioClip levelUp;
    #endregion

    #region Private Variables
    private int nextSound = 4000;
    #endregion

	void Start()
    {
		
	}

	public void Score(int points)
    {
		score += points;
		Debug.Log("Scored: " + score);
		scoreText.text = score.ToString();
		if(score >= nextSound)
        {
			AudioSource.PlayClipAtPoint(levelUp, transform.position);
			nextSound *= 2;
			SaveScore();
		}
		
	}
	//LevelManager.LoadNextLevel() HERE INSIDE IF
	//LevelManager.ScoreUp() HERE INSIDE IF
	public void Wave(){
		wave += 1;
		Debug.Log("Wave Number: " + wave);
		waveText.text = wave.ToString();
		if (wave == minWaveToLevelUp){
			gameObject.GetComponent<LevelManager>().LoadNextLevel();
			gameObject.GetComponent<LevelManager>().ScoreUp();
			score = lastScore;
		}
	}
	
	public void ResetScore()  //Mudei o nome de Reset pra ResetScore.
    {
		score = 0;
	}
	
	public void SaveScore()//Vou usar PlayerPrefs para guardar o score anterior, não tem muita segurança, mas é o jeito mais facil
    {
        PlayerPrefs.SetInt("LastScore", score); //Aqui estamos salvando no PlayerPrefs o antigo score.
        PlayerPrefs.Save(); //Depois de fazer alterações, precisamos salvar pra não serem perdidas.
		lastScore = score;
		Debug.Log("Last Score Saved: " + lastScore);
		
		
	}
}
