using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {
	
	#region Public Variables
	public GameObject projectile;
	public float projectileSpeed = 5;
	public float health = 150;
	public float shotsPerSeconds = 0.5f;
	public int scoreValue = 0;
	public AudioClip fireSound;
	public AudioClip deathSound;
	
	#endregion
	
	#region Private variables
	private ScoreKeeper scoreKeeper;
	#endregion
	
	void Start(){
		scoreKeeper = GameObject.Find("GameController").GetComponent<ScoreKeeper>(); //Agora acha o objeto "GameController", não o texto de score
    }
	
	void Update(){
		float probability = Time.deltaTime * shotsPerSeconds;
		if(Random.value < probability){
			Fire();	
		}
	}
	
	void Fire(){
		//start shooting above object
		Vector3 startPosition = transform.position + new Vector3(0, -1, 0);
		GameObject laser = Instantiate(projectile, startPosition, Quaternion.identity) as GameObject;
		laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			health -= missile.GetDamage();
			missile.Hit();
			if (health <= 0){
				Die();
			}
		}
	}
	
	void Die(){
		AudioSource.PlayClipAtPoint(deathSound, transform.position);
		Destroy(gameObject);
		scoreKeeper.Score(scoreValue);
	}
}
