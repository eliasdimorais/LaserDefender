using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed = 15.0f;
	public float padding;
	float xmin;
	float xmax;
	
	void Start(){
		
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0,0,distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1,0,distance));
		xmin = leftMost.x - padding;
		xmax = rightMost.x - padding;
		
	}
	
	void Update() {
		if(Input.GetKey(KeyCode.LeftArrow)){
			//transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if(Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime;
			
		}
		//don't pass below x=0 and x > screen
		float newX = Mathf.Clamp(transform.position.x, xmin,xmax);
		transform.position = new Vector3(newX, transform.position.y, transform.position.z);
	}
	
}
