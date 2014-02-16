using UnityEngine;
using System.Collections;

public class CastFireball : MonoBehaviour {

	public Transform fireball;

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonUp("Fire1"))
		   Instantiate(fireball,transform.position,transform.rotation);
	}
}
