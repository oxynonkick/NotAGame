using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float Speed = 2f;
	public float TravelDistance = 10f;
	public Transform PlayerCheck;
	public LayerMask WhatToAttack;
	public float HP = 2;
	
	private Vector3 _initialPosition;
	private bool _facingRight = false;
	private Animator _anim;
	private float _playerCheckRadius = 0.1f;
	private bool _needToAtack;
	private bool _dead;
	private float _deathSpeed;

	// Use this for initialization
	void Start () 
	{
		_initialPosition = transform.position;	
		_anim = GetComponent<Animator>();						
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
				if (!_dead) {
						_needToAtack = Physics2D.OverlapCircle (PlayerCheck.position, _playerCheckRadius, WhatToAttack);
						if (_needToAtack) {	
								_anim.SetBool ("Atack", true);	
								return;
						}
						_anim.SetBool ("Atack", false);
						if ((_initialPosition.x - transform.position.x) > TravelDistance || (transform.position.x - _initialPosition.x) > TravelDistance) {
								_initialPosition = transform.position;
								Flip ();
						} else {
								if (_facingRight) 
										rigidbody2D.velocity = new Vector2 (Speed, rigidbody2D.velocity.y);
								else
										rigidbody2D.velocity = new Vector2 (-Speed, rigidbody2D.velocity.y);
								_anim.SetFloat ("Speed", Speed);
						}
				} else {
						gameObject.collider2D.isTrigger = true;
						rigidbody2D.gravityScale = 0;
						rigidbody2D.velocity = new Vector2 (_deathSpeed, 0);
						//Shrink
						if (transform.localScale.x > 0) {
								transform.Rotate (0, 0, 2);
								if (transform.localScale.x > 0 && transform.localScale.y > 0)
										transform.localScale = new Vector3 (transform.localScale.x - 0.01f, transform.localScale.y - 0.01f, transform.localScale.z);
								else
										Destroy (gameObject);
						} else {
								transform.Rotate (0, 0, -2);
								if (transform.localScale.x < 0 && transform.localScale.y > 0)
										transform.localScale = new Vector3 (transform.localScale.x + 0.01f, transform.localScale.y - 0.01f, transform.localScale.z);
								else
										Destroy (gameObject);
						}
				}
	}
	
	void Flip(){
		_facingRight = !_facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}


	void Hit(HitInfo info){
		HP -= info.Damage;
		if (HP <= 0) {
			_dead = true;
			_deathSpeed = info.ImpactSpeed / 2;
		}
	}

}
