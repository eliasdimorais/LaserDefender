using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width;
	public float height;
	public float speed = 5f;
	
	
	private bool movingRight = true;
	private float xMax;
	private float xMin;
	// Camera.main.ViewportToWorldPoint -> It translates viewport coordinates to world coordinates so we can figure out where in the gamespace a point on the screen is.
	
	void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoudary = Camera.main.ViewportToWorldPoint(new Vector3(0,0, distanceToCamera));
		Vector3 rightBoudary = Camera.main.ViewportToWorldPoint(new Vector3(1,0, distanceToCamera));
		xMax = rightBoudary.x;
		xMin = leftBoudary.x;
		
		foreach(Transform child in transform){
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			//put inside hierarchy 
			enemy.transform.parent = child;
		}
	}
	
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	// Update is called once per frame
	void Update () {
		if(movingRight){
			transform.position += Vector3.right * speed * Time.deltaTime;
		}else{
			transform.position += new Vector3(-speed * Time.deltaTime,0);
		}
		
		float rightEdgeOfFormation = transform.position.x + (0.5f*width);
		float leftEdgeOfFormation = transform.position.x - (0.5f*width);
		
		if (leftEdgeOfFormation < xMin){
			movingRight = true;
		}else if(rightEdgeOfFormation > xMax){	
			movingRight = false;		
		}
	}
}
