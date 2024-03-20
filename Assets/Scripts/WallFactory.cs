using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFactory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Wall wallPrefab = new Wall();

	public void createWall(Vector2Int size)
	{
		createTopWall(size);
		createDownWall(size);
		createLeftWall(size);
		createRightWall(size);
	}

	private void createTopWall(Vector2Int size) 
	{
		Wall[] walls = new Wall[size.x * 1];

		Vector2 offset = new Vector2((size.x / 2) - 0.5f, size.y / 2 + 0.5f); 

		for (int i = 0; i < walls.Length; i++)
        {
			Wall wall = walls[i] = Instantiate(wallPrefab);
			wall.transform.SetParent(transform, false);
			wall.transform.localPosition = new Vector3(
				i - offset.x, 0.5f, offset.y
			);
		}
	}
	private void createLeftWall(Vector2Int size) {
		Wall[] walls = new Wall[size.y * 1 - 2];

		Vector2 offset = new Vector2(size.x / 2 - 0.5f, size.y / 2 - 1 - 0.5f); //todo: the 12 should the the size of game board

		for (int i = 0; i < walls.Length; i++)
		{
			Wall wall = walls[i] = Instantiate(wallPrefab);
			wall.transform.SetParent(transform, false);
			wall.transform.localPosition = new Vector3(
				-offset.x, 0.5f, i - offset.y
			);
		}
	}
	private void createRightWall(Vector2Int size) {
		Wall[] walls = new Wall[size.y * 1 - 2];

		Vector2 offset = new Vector2(size.x / 2 - 0.5f, size.y / 2 - 1 - 0.5f); //todo: the 12 should the the size of game board

		for (int i = 0; i < walls.Length; i++)
		{
			Wall wall = walls[i] = Instantiate(wallPrefab);
			wall.transform.SetParent(transform, false);
			wall.transform.localPosition = new Vector3(
				offset.x, 0.5f, i - offset.y
			);
		}
	}
	private void createDownWall(Vector2Int size) {
		Wall[] walls = new Wall[size.x * 1];

		Vector2 offset = new Vector2((size.x / 2) - 0.5f, size.y / 2 - 1 + 0.5f); 

		for (int i = 0; i < walls.Length; i++)
		{
			Wall wall = walls[i] = Instantiate(wallPrefab);
			wall.transform.SetParent(transform, false);
			wall.transform.localPosition = new Vector3(
				i - offset.x, 0.5f, -offset.y
			);
		}
	}
}
