using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	#region Public Variables
	public GameObject laser; 
	public float projectileSpeed;
	public float firingRate = 0.2f;
	public float health = 250f;
	public float speed = 15.0f;
	public float padding;
	public AudioClip fireSound;
	public AudioClip deathSound;
	public int lifeValue = 1;
	
	#endregion
	#region Private Variables
	private LifeCounter lifeCounter;
	
	#endregion
	float xmin;
	float xmax;
	
	void Start(){
		Camera camera = Camera.main;
		float distance = transform.position.z - Camera.main.transform.position.z;
		xmin = camera.ViewportToWorldPoint(new Vector3(0,0,distance)).x + padding;
		xmax = camera.ViewportToWorldPoint(new Vector3(1,0,distance)).x - padding;
		lifeCounter = GameObject.Find("GameController").GetComponent<LifeCounter>(); //Agora acha o objeto "GameController", não o texto de vida
		
	}
	void Fire(){
		Vector3 offset = new Vector3(0,1,0);
		GameObject beam = Instantiate (laser, transform.position+offset, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed,0);
		AudioSource.PlayClipAtPoint(fireSound, transform.position);
	}
	void Update() {
		//Dont use GetKey
		if(Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("Fire", 0.00001f, firingRate);
		}
		if(Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
		}
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
	
	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if(missile){
			Debug.Log("Player Collided with a missile");
			health -= missile.GetDamage();
			missile.Hit();
			lifeCounter.Lives(lifeValue);
			if (health <= 0){
				Die();
				AudioSource.PlayClipAtPoint(deathSound, transform.position);
			}
		}
		
	}
	
	void Die(){
		LevelManager man = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
		man.LoadLevel("Play Again"); //Name of the Scene
		//if there is an stamina life just create a method above somewhere and call here
		Destroy(gameObject);
		
	}
	
	
	
}
