using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform platform;
	public Transform player;
	public Transform enemy;
	public Camera mainCamera;
	public float maxSize;
	public float maxOffsetUp;
	public float maxOffsetDown;
	Transform lastPlatform;
	Transform newPlatform;
	Vector3 randomSize;
	
	// Use this for initialization
	void Start () {
		randomSize = new Vector3 (Random.Range (1, maxSize), 1.5f, 0);
		lastPlatform = (Transform)Instantiate (platform, new Vector3 (player.position.x, player.position.y - 1, 0), new Quaternion ());
		lastPlatform.localScale = randomSize;
		randomSize = new Vector3 (Random.Range (1, maxSize), 1.5f, 0);
		newPlatform = (Transform)Instantiate (platform, new Vector3 (lastPlatform.position.x + lastPlatform.localScale.x * 1.5f + randomSize.x * 1.5f, lastPlatform.position.y + Random.Range (maxOffsetDown, maxOffsetUp), 0), new Quaternion ());
		newPlatform.localScale = randomSize;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag ("Enemy") == null && Random.Range(1,101) > 50)
						Instantiate (enemy, new Vector3 (player.position.x + Random.Range(3,6), player.position.y + 2), new Quaternion ());
		if (player.position.x - newPlatform.position.x >= 0) {
						randomSize = new Vector3 (Random.Range (1, maxSize), 1.5f, 0);
						lastPlatform.SendMessage ("DestroyPlatform");
						lastPlatform = newPlatform;
			newPlatform = (Transform)Instantiate (platform, new Vector3 (lastPlatform.position.x + lastPlatform.localScale.x * 1.5f + randomSize.x * 1.5f, lastPlatform.position.y + Random.Range (maxOffsetDown, maxOffsetUp), 0), new Quaternion ());
						newPlatform.localScale = randomSize;
				}
	}
}
