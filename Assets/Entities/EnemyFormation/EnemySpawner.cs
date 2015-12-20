using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	#region Public Variables
	
	public GameObject enemyPrefab;
	public float width;
	public float height;
	public float speed = 5f;
	public float spawnDelay = 0.5f;
	#endregion
	
	#region Private Variables
	private bool movingRight = true;
	private float xMax;
	private float xMin;
	private ScoreKeeper scoreKeeper;
	// Camera.main.ViewportToWorldPoint -> It translates viewport coordinates to world coordinates so we can figure out where in the gamespace a point on the screen is.
	#endregion
	
	void Start () {
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoudary = Camera.main.ViewportToWorldPoint(new Vector3(0,0, distanceToCamera));
		Vector3 rightBoudary = Camera.main.ViewportToWorldPoint(new Vector3(1,0, distanceToCamera));
		xMax = rightBoudary.x;
		xMin = leftBoudary.x;
		SpawnUntilFull();
		scoreKeeper = GameObject.Find("GameController").GetComponent<ScoreKeeper>();
	}
	void SpawnEnemies(){
		foreach(Transform child in transform){
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			//put inside hierarchy 
			enemy.transform.parent = child;
		}
	}
	void SpawnUntilFull(){
		Transform freePosition = NextFreePosition();
		if(freePosition){
			GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			//put inside hierarchy 
			enemy.transform.parent = freePosition;
		}
		if(NextFreePosition()){
			Invoke("SpawnUntilFull", spawnDelay);
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
		if(AllMembersDead()){
			Debug.Log("Members dead!");
			SpawnUntilFull();
			
			
		}
	}
	Transform NextFreePosition(){
		foreach(Transform childPositionGameObject in transform){
			if (childPositionGameObject.childCount == 0){
				return childPositionGameObject;
			}
		}
		return null;
	}
	bool AllMembersDead(){
		foreach(Transform childPositionGameObject in transform){
			if (childPositionGameObject.childCount > 0){
				return false;
			}
		}
		scoreKeeper.Wave();
		return true;
	}
}
