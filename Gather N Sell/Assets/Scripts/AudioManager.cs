using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour {
	public GameObject gameManager;
	public Player player;
	public AudioSource SoundEffectManager;
	public AudioClip dayAmbient;
	public AudioClip acceptSale;
	public AudioClip declineSale;

	public AudioClip nightAmbient;
	public AudioClip woodCollectProcess;
	public AudioClip woodCollectSuccess;
	public AudioClip berriesCollectProcess;
	public AudioClip berriesCollectSuccess;
	public AudioClip coalCollectProcess;
	public AudioClip coalCollectSuccess;

	private bool dayScene = false;

	public void Awake(){
		DontDestroyOnLoad (this);
	}

	public void Start(){
		if (SceneManager.GetActiveScene ().name == "Day")
			this.GetComponent<AudioSource> ().clip = dayAmbient;
		else {
			this.GetComponent<AudioSource> ().clip = nightAmbient;
			this.GetComponent<AudioSource> ().Stop ();
		}
		this.GetComponent<AudioSource> ().Play ();
	}

	public void ChangingScene(){
		this.GetComponent<AudioSource> ().Stop ();
		if (dayScene) {
			this.GetComponent<AudioSource> ().clip = dayAmbient;
			dayScene = true;
		} else {
			this.GetComponent<AudioSource> ().clip = nightAmbient;
			dayScene = false;
		}
		this.GetComponent<AudioSource> ().Play ();
	}

	public void AcceptSale(){
		SoundEffectManager.clip = acceptSale;
		SoundEffectManager.Play ();
	}

	public void DeclineSale(){
		SoundEffectManager.clip = declineSale;
		SoundEffectManager.Play ();
	}

	public void WoodCollectProcess(){
		SoundEffectManager.clip = woodCollectProcess;
		SoundEffectManager.loop = true;
		SoundEffectManager.Play ();
	}

	public void WoodCollectSuccess(){
		//SoundEffectManager.Stop ();
		SoundEffectManager.clip = woodCollectSuccess;
		SoundEffectManager.loop = false;
		SoundEffectManager.Play ();
	}

	public void BerriesCollectProcess(){
		SoundEffectManager.clip = berriesCollectProcess;
		SoundEffectManager.loop = true;
		SoundEffectManager.Play ();
	}

	public void BerriesCollectSuccess(){
		//SoundEffectManager.Stop ();
		SoundEffectManager.clip = berriesCollectSuccess;
		SoundEffectManager.loop = false;
		SoundEffectManager.Play ();
	}

	public void CoalCollectProcess(){
		SoundEffectManager.clip = coalCollectProcess;
		SoundEffectManager.loop = true;
		SoundEffectManager.Play ();
	}

	public void CoalCollectSuccess(){
		//SoundEffectManager.Stop ();
		SoundEffectManager.clip = coalCollectSuccess;
		SoundEffectManager.loop = false;
		SoundEffectManager.Play ();
	}
}
