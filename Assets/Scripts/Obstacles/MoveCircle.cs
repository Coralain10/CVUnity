using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCircle : CollisionOnTop
{
    float speed;
    float radius;
    float angle; //radians
    Vector3 posBefore;
    Collision2D otherCollision;

    protected override void Awake()
    {
        MoveRoulette mr = gameObject.GetComponentInParent(typeof(MoveRoulette)) as MoveRoulette;
        speed = mr.speed;
        radius = mr.radius;
        angle =  Mathf.Atan2( transform.localPosition.x, transform.localPosition.y );
        base.Awake();
    }

    void Update()
    {
        posBefore = transform.localPosition;
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
        if (isOnTop && otherCollision!=null)
        {
            otherCollision.transform.Translate( Vector2.one * (transform.localPosition - posBefore) );
        }
    }

    protected override void OnCollisionTopEnter(Collision2D other)
    {
        otherCollision = other;
    }
    protected override void OnCollisionTopExit(Collision2D other)
    {
        otherCollision = null;
    }
    // void OnCollisionStay2D(Collision2D other)
    // {
    //     // Vector2 distance = ;
    //     other.transform.Translate( Vector2.one * (transform.localPosition - posBefore) );
    // }
}
