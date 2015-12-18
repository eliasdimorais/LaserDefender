using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour {

	public static int lifeRemain = 3; //change number lives here and under Reset method
	private Text myText;
	
	void Start(){
		myText = GetComponent<Text>();
		Reset();
	}
	public void Lives(int lives){
		Debug.Log("Lost one life");
		lifeRemain -= lives;
		myText.text = lifeRemain.ToString();
	}
	
	public static void Reset(){
		lifeRemain = 3; 
	}
}
