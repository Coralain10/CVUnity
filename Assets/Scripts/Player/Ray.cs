using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    Rigidbody2D rb;
    public bool toRight;
    public float[] bounds = {0,0};
    float speed = 10f;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2( ( toRight ? 1 : -1 ) * speed, rb.velocity.y );
    }
    
    void Update()
    {
        if ( transform.position.x < bounds[0] || transform.position.x > bounds[1] )
            Destroy(gameObject);
    }

    void OnCollisionEnter2D( Collision2D other )
    {
        rb.velocity = Vector2.zero;
        if (other.collider.CompareTag("Skill"))
        {
            other.gameObject.GetComponent<Skill>().GotDamage();
        }
        Destroy(gameObject);
    }
}
