using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCircle : MonoBehaviour
{
    float speed;
    float radius;
    [SerializeField] float angle; //radians
    [SerializeField] float xBefore;
    public Vector3 dist;

    void Awake()
    {
        MoveRoulette mr = gameObject.GetComponentInParent(typeof(MoveRoulette)) as MoveRoulette;
        speed = mr.speed;
        radius = mr.radius;
        angle =  Mathf.Atan2( transform.localPosition.x, transform.localPosition.y );
        // distance = new Vector3(
        //     radius * Mathf.Cos(-speed * Time.deltaTime),
        //     radius * Mathf.Sin(-speed * Time.deltaTime),
        //     0 );
    }

    void FixedUpdate()
    {
        xBefore = transform.localPosition.x;
        if (angle >= 2 * Mathf.PI)
        {
            angle = 0;
        }
        else
        {
            angle -= speed * Time.deltaTime;
        }
        transform.localPosition = new Vector3 (
            radius * Mathf.Cos(angle),
            radius * Mathf.Sin(angle),
            transform.localPosition.z
        );
    }

    void OnCollisionStay2D(Collision2D other)
    {
        other.transform.Translate( Vector3.right * (transform.localPosition.x - xBefore) * 1 );
    }
}
