using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlatformFactory : GameObjectFactory
{
	// Start is called before the first frame update
	[SerializeField]
	Platform prefab = default;

	public Platform Get()
	{
		Platform instance = CreateGameObjectInstance(prefab);
		instance.OriginFactory = this;
		return instance;
	}

	public void Reclaim(Platform platform)
	{
		Debug.Assert(platform.OriginFactory == this, "Wrong factory reclaimed!");
		Destroy(platform.gameObject);
	}
}
