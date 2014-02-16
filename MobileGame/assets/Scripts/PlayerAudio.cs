using UnityEngine;
using System.Collections;

public class PlayerAudio : MonoBehaviour {

	public AudioClip Jump;
	public AudioClip Charge;
	public AudioClip Shoot;

	private GameObject _player;
	private bool _grounded;

	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		_grounded = _player.GetComponent<PlayerController>().Grounded;
		if ( _grounded && Input.GetButtonDown ("Jump")) 
						Play (Jump, false, (float)1.0);
		if (Input.GetButtonDown ("Fire1"))
						Play (Charge, false, (float)0.5);
		if (Input.GetButtonUp ("Fire1"))
						Play (Shoot, true, (float)1.0);
	
	}

	void Play(AudioClip sound, bool canInterupt, float volume)
	{
		if (canInterupt) {
						audio.clip = sound;
						audio.volume = volume;
						audio.Play ();
				} 
		else
			if (!audio.isPlaying) {
			audio.clip = sound;
			audio.volume = volume;
			audio.Play ();
				}
	}
}
