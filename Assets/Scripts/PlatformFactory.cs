using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFactory : MonoBehaviour
{
    [SerializeField]
    Platform platformPrefab = default;
    public void createPlatform(int size, Vector2Int pos) { 
        Platform[] platforms = new Platform[size];

        for (int i = 0; i < platforms.Length; i++) {
            Platform platform = platforms[i] = Instantiate(platformPrefab);
            platform.transform.SetParent(transform, false);
            platform.transform.localPosition = new Vector3(
                pos.x * 0.5f + i, 0.5f, pos.y * 0.5f
            );
        }
    }
    
}
