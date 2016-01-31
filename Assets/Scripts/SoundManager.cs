using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour 
{
	public AudioSource efxSource;                   
	public AudioSource musicSource;                
	public static SoundManager instance = null;                  
	public float lowPitchRange = .95f;             
	public float highPitchRange = 1.05f;           
	public AudioClip[] clips;

	void Awake ()
	{
		
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);


		DontDestroyOnLoad (gameObject);
	}
		
	public void PlaySingle(int clip)
	{
		
		efxSource.clip = clips[clip];
		efxSource.Play ();
	}
}
