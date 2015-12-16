using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	
	// Use this for initialization
	void Start () {
		foreach(Transform child in transform){
			GameObject enemy = Instantiate(enemyPrefab, new Vector3(0,0), Quaternion.identity) as GameObject;
			//put inside hierarchy 
			enemy.transform.parent = transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
