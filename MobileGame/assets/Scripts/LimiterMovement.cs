using UnityEngine;
using System.Collections;

public class LimiterMovement : MonoBehaviour {

	private GameObject _player;

	public float DistanceToLimiter;

	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		float move = _player.GetComponent<PlayerController> ().Move;
		if(_player.transform.position.x - transform.position.x > DistanceToLimiter)
			if (move > 0) 
			{
				Vector3 position = _player.transform.position;
				position.x -= DistanceToLimiter;
				transform.position = position;
			}
	}
}
