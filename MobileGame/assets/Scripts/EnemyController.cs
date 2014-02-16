using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float Speed = 2f;
	public float TravelDistance = 10f;
	public Transform PlayerCheck;
	public LayerMask WhatToAttack;
	public int HP = 2;
	
	private Vector3 _initialPosition;
	private bool _facingRight = false;
	private Animator _anim;
	private float _playerCheckRadius = 0.1f;
	private bool _needToAtack;

	// Use this for initialization
	void Start () 
	{
		_initialPosition = transform.position;	
		_anim = GetComponent<Animator>();						
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		_needToAtack = Physics2D.OverlapCircle(PlayerCheck.position, _playerCheckRadius, WhatToAttack);
		if(_needToAtack) 
		{	
			_anim.SetBool("Atack", true);	
			return;
		}
		_anim.SetBool("Atack", false);
		if ( (_initialPosition.x - transform.position.x) > TravelDistance || (transform.position.x - _initialPosition.x) > TravelDistance)
		{
			_initialPosition = transform.position;
			Flip ();
		}
		else
		{
			if (_facingRight) 
				rigidbody2D.velocity = new Vector2(Speed, rigidbody2D.velocity.y);				
			else
				rigidbody2D.velocity = new Vector2(-Speed, rigidbody2D.velocity.y);
			_anim.SetFloat("Speed",Speed);
		}
	}
	
	void Flip(){
		_facingRight = !_facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	public void Hit(){
		HP--;
		if(HP == 0)
			Destroy (gameObject);
		}
}
