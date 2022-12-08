using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    public Tilemap tileMap;
    [SerializeField] float yOverflow;
    short pixelSize = 24;
    int xMin = 0;
    int xMax = 0;
    
    void Start()
    {
        //tileMap = GetComponent<Tilemap>();
        if (tileMap) {
            xMax = tileMap.size.x - (Screen.width/pixelSize)/4;
        }
        if (player == null) {
            player = GameObject.Find("Player");
        }
    }

    void LateUpdate()
    {
        if (player.transform.position.x < xMin) {
            transform.position = new Vector3(xMin, player.transform.position.y + yOverflow, transform.position.z);
        }
        else if (player.transform.position.x > xMax) {
            transform.position = new Vector3(xMax, player.transform.position.y + yOverflow, transform.position.z);
        } else {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y + yOverflow, transform.position.z);
        }
    }
}
