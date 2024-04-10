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

    List<GameTile> spawnPoints = new List<GameTile>();

    GameTileContentFactory contentFactory;
    public int SpawnPointCount => spawnPoints.Count;
    public void Initialize(Vector2Int size, GameTileContentFactory contentFactory)
    {
        this.size = size;
        this.contentFactory = contentFactory;
        // 鋪上tiles
        createTiles(size);

        // 建造牆壁
        Vector2Int classSize = new Vector2Int(size.x, 7);
        createWall(classSize);

        //建造平台
        Vector2Int startPos = new Vector2Int(-5, 5);
        createPlatform(5, startPos);
        startPos = new Vector2Int(-5, -3);
        createPlatform(5, startPos);

        //產生生怪點
        ToggleSpawnPoint(tiles[66]);
    }

    private void createTiles(Vector2Int size)
    {
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
                tile.Content = contentFactory.Get(GameTileContentType.Empty);
            }
        }
    }

    public GameTile GetSpawnPoint(int index)
    {
        return spawnPoints[index];
    }

    private void createWall(Vector2Int size)
    {
        createTopWall(size);
        createDownWall(size);
        createLeftWall(size);
        createRightWall(size);
    }

    private void createPlatform(int size, Vector2Int startPos)
    {
        for (int i = 0; i < size; i++)
        {
            Platform platform = platformFactory.Get();
            Vector2 pos = new Vector2(startPos.x * 0.5f + i, startPos.y * 0.5f);
            platform.SpawnOn(pos);
        }
    }

    public void ToggleSpawnPoint(GameTile tile)
    {
        if (tile.Content.Type == GameTileContentType.SpawnPoint)
        {
            if (spawnPoints.Count > 1)
            {
                spawnPoints.Remove(tile);
                tile.Content = contentFactory.Get(GameTileContentType.Empty);
            }
        }
        else if (tile.Content.Type == GameTileContentType.Empty)
        {
            tile.Content = contentFactory.Get(GameTileContentType.SpawnPoint);
            spawnPoints.Add(tile);
        }
    }


    private void createTopWall(Vector2Int size)
    {

        Vector2 offset = new Vector2((size.x / 2) - 0.5f, (size.y / 2) + 0.5f);

        for (int i = 0; i < size.x; i++)
        {
            Wall wall = wallFactory.Get();
            Vector2 pos = new Vector2(i - offset.x, offset.y);
            wall.SpawnOn(pos);
        }
    }
    private void createLeftWall(Vector2Int size)
    {
        Wall[] walls = new Wall[size.y * 1 - 2];

        Vector2 offset = new Vector2(size.x / 2 - 0.5f, size.y / 2 - 1 - 0.5f);

        for (int i = 0; i < walls.Length; i++)
        {
            Wall wall = wallFactory.Get();
            Vector2 pos = new Vector2(-offset.x, i - offset.y);
            wall.SpawnOn(pos);
        }
    }
    private void createRightWall(Vector2Int size)
    {
        Wall[] walls = new Wall[size.y * 1 - 2];

        Vector2 offset = new Vector2(size.x / 2 - 0.5f, size.y / 2 - 1 - 0.5f);

        for (int i = 0; i < walls.Length; i++)
        {
            Wall wall = wallFactory.Get();
            Vector2 pos = new Vector2(offset.x, i - offset.y);
            wall.SpawnOn(pos);
        }
    }
    private void createDownWall(Vector2Int size)
    {
        Vector2 offset = new Vector2((size.x / 2) - 0.5f, size.y / 2 - 1 + 0.5f);

        for (int i = 0; i < size.x; i++)
        {
            Wall wall = wallFactory.Get();
            Vector2 pos = new Vector2(i - offset.x, -offset.y);
            wall.SpawnOn(pos);
        }
    }
}
