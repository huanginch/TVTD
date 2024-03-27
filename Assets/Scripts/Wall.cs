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

	public void SpawnOn(GameTile tile)
	{
		Vector3 newPos = new Vector3(tile.transform.localPosition.x, 0.5f, tile.transform.localPosition.z);
		transform.localPosition = newPos;
	}
}
