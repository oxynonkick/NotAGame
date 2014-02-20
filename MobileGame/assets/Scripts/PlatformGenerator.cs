using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour 
{

	public GameObject PlatformUnit;
	public int Height;
	public int Width;

	// Use this for initialization
	void Start () 
	{
		Vector3 sizeOfUnit = PlatformUnit.renderer.bounds.size;
		for(int i = 0; i < Width; i++)
			for(int j = 0; j < Height; j++)
			{
				Vector3 unitPosition = transform.position;
				unitPosition.x += i*sizeOfUnit.x;
				unitPosition.y += j*sizeOfUnit.y;
				GameObject unit = Instantiate(PlatformUnit, unitPosition, transform.rotation) as GameObject;
				unit.transform.parent = transform;				
			}
	}
}
