using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
	[SerializeField]
	Transform ground = default;

	Vector2Int size;

	[SerializeField]
	GameTile tilePrefab = default;

	[SerializeField]
	WallFactory wallFactory = default;

	[SerializeField]
	PlatformFactory platformFactory = default;

	GameTile[] tiles;
	public void Initialize(Vector2Int size)
	{
		// 鋪上tiles
		createTiles(size);

		// 建造牆壁
		Vector2Int classSize = new Vector2Int(size.x, 7);
		wallFactory.createWall(classSize);

		//建造平台
		Vector2Int startPos = new Vector2Int(-5, 5);
		platformFactory.createPlatform(5, startPos);
		startPos = new Vector2Int(-5, -3);
		platformFactory.createPlatform(5, startPos);
	}

	private void createTiles(Vector2Int size) {
		this.size = size;
		ground.localScale = new Vector3(size.x, size.y, 1f);

		Vector2 offset = new Vector2(
			(size.x - 1) * 0.5f, (size.y - 1) * 0.5f
		);

		tiles = new GameTile[size.x * size.y];
		for (int i = 0, y = 0; y < size.y; y++)
		{
			for (int x = 0; x < size.x; x++, i++)
			{
				GameTile tile = tiles[i] = Instantiate(tilePrefab);
				tile.transform.SetParent(transform, false);
				tile.transform.localPosition = new Vector3(
					x - offset.x, 0.05f, y - offset.y
				);
			}
		}
	}
}
