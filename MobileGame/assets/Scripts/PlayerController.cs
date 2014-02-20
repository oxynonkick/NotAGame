using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float maxSpeed = 5;
	public float HP = 10;
	bool _facingRight = false;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.1f;
	public LayerMask whatIsGround;
	public float jumpForce = 70f;

	private float _move;

	public bool Grounded
	{
		get {return grounded;}
	}
	public float Move
	{
		get {return _move;}
	}

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update() {
		if (grounded && Input.GetButtonDown("Jump")) {
						anim.SetBool ("Ground", false);
						rigidbody2D.AddForce (new Vector2 (0, jumpForce));
				}
	}

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Ground", grounded);

		anim.SetFloat ("vSpeed", rigidbody2D.velocity.y);

		_move = Input.GetAxis ("Horizontal");

		anim.SetFloat("Speed", Mathf.Abs(_move));

		rigidbody2D.velocity = new Vector2 (_move * maxSpeed, rigidbody2D.velocity.y);

		if (_move > 0 && !_facingRight)
						Flip ();
		if (_move < 0 && _facingRight)
						Flip ();
	}

	void Flip(){
		_facingRight = !_facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
		}

	void Hit(HitInfo info){
		Debug.Log ("Hit");
		HP -= info.Damage;
		rigidbody2D.AddForce (new Vector2(info.ImpactSpeed * 100, 100));
		if (HP <= 0) {
			Debug.Log("You are dead");
				}
	}
}
