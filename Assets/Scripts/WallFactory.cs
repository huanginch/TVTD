using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WallFactory : GameObjectFactory
{
	// Start is called before the first frame update
	[SerializeField]
	Wall prefab = default;

	public Wall Get()
	{
		Wall instance = CreateGameObjectInstance(prefab);
		instance.OriginFactory = this;
		return instance;
	}

	public void Reclaim(Wall wall)
	{
		Debug.Assert(wall.OriginFactory == this, "Wrong factory reclaimed!");
		Destroy(wall.gameObject);
	}
}
