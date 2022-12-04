using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public int xMin;
    public int xMax;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void LateUpdate()
    {
        if (player.transform.position.x < xMin) {
            transform.position = new Vector2(xMin, player.transform.position.y);
        }
        else if (player.transform.position.x > xMax) {
            transform.position = new Vector2(xMax, player.transform.position.y);
        } else {
            transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
        }
    }
}
