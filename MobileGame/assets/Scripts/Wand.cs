using UnityEngine;
using System.Collections;

public class Wand : MonoBehaviour {

	private SpriteRenderer _spriteRenderer; 
	public Sprite WandInitial;
	public Sprite WandCharged;


	// Use this for initialization
	void Start () {
		_spriteRenderer = GetComponent<SpriteRenderer>();	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Fire1"))
						_spriteRenderer.sprite = WandCharged;
				else
						_spriteRenderer.sprite = WandInitial;
	}
}
