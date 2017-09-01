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

	private int wood;
	private int berries;
	private int coal;
	private bool dayScene = false;

	public void Awake(){
		DontDestroyOnLoad (this);
		if (SceneManager.GetActiveScene ().name == "Day")
			this.GetComponent<AudioSource> ().clip = dayAmbient;
		else
			this.GetComponent<AudioSource> ().clip = nightAmbient;
		this.GetComponent<AudioSource> ().Play ();
	}

	public void Start(){
		//player = GameManager.player;
		//player = gameManager.GetComponent<GameManager>().player;
		if (SceneManager.GetActiveScene ().name == "Day")
			this.GetComponent<AudioSource> ().clip = dayAmbient;
		else
			this.GetComponent<AudioSource> ().clip = nightAmbient;
		this.GetComponent<AudioSource> ().Play ();

		wood = player.LumberSupply;
		berries = player.BerrySupply;
		coal = player.CoalSupply;
	}

	public void Update(){
		if (SceneManager.GetActiveScene ().name != "Day") {
			if (player.LumberSupply > wood) {
				this.WoodCollectSuccess ();
				wood = player.LumberSupply;
			} else if (player.BerrySupply > berries) {
				this.BerriesCollectSuccess ();
				berries = player.BerrySupply;
			} else if (player.CoalSupply > coal) {
				this.CoalCollectSuccess ();
				coal = player.CoalSupply;
			}
		}
		if (!this.GetComponent<AudioSource> ().isPlaying)
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
