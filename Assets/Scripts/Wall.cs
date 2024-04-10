using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
	// Start is called before the first frame update
	WallFactory originFactory;

	public WallFactory OriginFactory
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
