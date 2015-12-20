using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeCounter : MonoBehaviour
{

	public static int lifeRemain = 3; //change number lives here and ALSO on Reset() method
	public Text lifeText;
	
	void Start()
    {
		if(lifeRemain > 1)
			lifeRemain = 3;
        else
			Reset();
	}

	public void Lives(int lives)
    {
		Debug.Log("Lost one life");
		lifeRemain -= lives;
		lifeText.text = lifeRemain.ToString();
	}
	
	public static void Reset()
    {
		lifeRemain = 3; 
	}
}
