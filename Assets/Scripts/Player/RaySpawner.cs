using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class RaySpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject rayPrefab;
    Ray ray;
    Transform playerTransform;
    PlayerController playerController;
    public Tilemap tileMap;
    public float[] bounds = {0,0};
    float topOffset = 0.2f;
    float sideOffset = 0.51f;
    
    void Awake()
    {
        GameObject player = GameObject.Find("Player");
        playerTransform = player.transform;
        playerController = player.GetComponent<PlayerController>();
        bounds[0] = tileMap.localBounds.min.x;
        bounds[1] = tileMap.localBounds.max.x;
        ray = rayPrefab.GetComponent<Ray>();
        ray.bounds = bounds;
        // 
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ray.toRight = playerController.IsFacingRight;
            Vector3 shootPos = new Vector3 (
                playerTransform.position.x + (ray.toRight?1:-1) * sideOffset ,
                playerTransform.position.y + topOffset,
                24 );
            Instantiate(rayPrefab, shootPos, rayPrefab.transform.rotation, gameObject.transform);
        }
    }
}
