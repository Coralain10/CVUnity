using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoulette : MonoBehaviour
{
    public float speed = 2; //radians
    public float radius = 2;
    private Transform cross;

    void Awake()
    {
        // radius = Vector2.Distance(transform.localPosition, Vector2.zero);
        cross = transform.Find("Cross");
    }

    void Update()
    {
        cross.Rotate(Vector3.back, Time.deltaTime * speed * Mathf.Rad2Deg);
    }
}
