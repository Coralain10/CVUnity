using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoulette : MonoBehaviour
{
    public float speed { get; private set; } //radians
    public float radius;
    private Transform cross;

    void Awake()
    {
        speed = 1; //incremento en radianes del ángulo
        radius = 2;
        // radius = Vector2.Distance(transform.localPosition, Vector2.zero);
        cross = transform.Find("Cross");
    }

    void Update()
    {
        cross.Rotate(Vector3.back, Time.deltaTime * speed * Mathf.Rad2Deg);
    }
}
