using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
	[SerializeField]
	Vector2Int boardSize = new Vector2Int(12, 12);

	[SerializeField]
	GameBoard board = default;

	[SerializeField]
	Camera mainCamera = default;
	void Awake()
	{
		board.Initialize(boardSize);
		mainCamera.transform.position = new Vector3(0.2f, 12.25f, -2.9f);
		mainCamera.transform.rotation = Quaternion.Euler(new Vector3(73.229f, 0, 0));
	}

	void OnValidate()
	{
		if (boardSize.x < 2)
		{
			boardSize.x = 2;
		}
		if (boardSize.y < 2)
		{
			boardSize.y = 2;
		}
	}
}
