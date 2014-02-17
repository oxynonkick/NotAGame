using UnityEngine;
using System.Collections;

public class CastFireball : MonoBehaviour {

	public Transform fireball;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp ("Fire1")) {
						Vector3 scale = gameObject.transform.parent.localScale;
						GameObject projectile = (GameObject)Instantiate (fireball, transform.position, transform.rotation);
						projectile.transform.localScale = new Vector3 (projectile.transform.localScale.x * -scale.x, projectile.transform.localScale.y * scale.y, projectile.transform.localScale.z);
				}
	}
	
}
