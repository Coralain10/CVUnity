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
        if (player == null) {
            player = GameObject.Find("Player");
        }
    }

    void LateUpdate()
    {
        if (player.transform.position.x < xMin) {
            transform.position = new Vector3(xMin, player.transform.position.y, transform.position.z);
        }
        else if (player.transform.position.x > xMax) {
            transform.position = new Vector3(xMax, player.transform.position.y, transform.position.z);
        } else {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}
