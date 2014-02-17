using UnityEngine;
using System.Collections;

public class HitInfo{
	public float Damage;
	public float ImpactSpeed;
	public string DamageType;

	public HitInfo(float dmg,float imSpeed, string dmgT){
		Damage = dmg;
		ImpactSpeed = imSpeed;
		DamageType = dmgT;
	}
}

public class Projectile : MonoBehaviour {


	public float Speed = 10;
	public float lifeTime = 10;
	public float Damage = 1;
	public string DamgeType = "Normal";

	// Use this for initialization
	void Start () {
		if (transform.localScale.x < 0) 
			Speed *= -1;
		rigidbody2D.velocity = new Vector2 (Speed, 0);
		Invoke ("Destroy", lifeTime);
	}

	public void OnCollisionEnter2D(Collision2D colliderInfo){
		if (colliderInfo.transform.tag == "Enemy")
						colliderInfo.gameObject.SendMessage ("Hit", new HitInfo (Damage, Speed, DamgeType));
		if (colliderInfo.transform.name != "Player")
						Destroy (gameObject);
	}

	void Destroy(){
		Destroy (gameObject);
	}
}
	