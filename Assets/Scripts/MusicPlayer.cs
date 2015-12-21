using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	
	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip endClip;
	
	private AudioSource music;
	
	void Start () {
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = true;
			music.Play();
		}
		
	}
	void OnLevelWasLoaded(int level){
		if (instance == this){
			Debug.Log("Music player loaded level " + level);
			music.Stop();
			if(level == 0){
				music.clip = startClip;	
			}
			else if(level == 1){
				music.clip = gameClip;	
			}
			else if(level == 2){
				music.clip = gameClip;	
			}
			else if(level == 4){
				music.clip = gameClip;	
			}
			else if(level == 4){
				music.clip = startClip;	
			}
			else if(level == 5){
				music.clip = endClip;	
			}
			else if(level == 6){
				music.clip = startClip;	
			}
			else if(level == 7){
				music.clip = startClip;	
			}
			music.loop = true;
			music.Play();
		}
	}
}
