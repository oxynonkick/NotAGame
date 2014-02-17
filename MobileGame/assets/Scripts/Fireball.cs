using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	public float Speed = 10;
	public float lifeTime = 10;

	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		if (player.transform.localScale.x > 0) 
		{
			Speed *= -1;
			Vector3 scale = transform.localScale;
			scale.x *= -1;
			transform.localScale = scale;			
		}
		rigidbody2D.velocity = new Vector2 (Speed, 0);
		Invoke ("Destroy", lifeTime);
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void OnCollisionEnter2D(Collision2D colliderInfo){
		if (colliderInfo.transform.tag == "Enemy")
						colliderInfo.gameObject.SendMessage ("Hit");
		if (colliderInfo.transform.name != "Player")
						Destroy (gameObject);
	}

	void Destroy(){
		Destroy (gameObject);
	}
}
	