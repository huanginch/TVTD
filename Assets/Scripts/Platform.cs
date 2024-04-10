using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	// Start is called before the first frame update
	PlatformFactory originFactory;

	public PlatformFactory OriginFactory
	{
		get => originFactory;
		set
		{
			Debug.Assert(originFactory == null, "Redefined origin factory!");
			originFactory = value;
		}
	}

	public void SpawnOn(Vector2 pos)
	{
		Vector3 newPos = new Vector3(pos.x, 0.5f, pos.y);
		transform.localPosition = newPos;
	}
}