using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSides : MonoBehaviour
{
    //BLOQUE SIEMPRE INICIA CENTRADO
    //private Rigidbody2D rb;
    public float speed;
    public float xRange;
    private float xMax;
    private float xMin;
    private bool isRightFaced;

    void Awake()
    {
        //rb = GetComponent<Rigidbody2D>();
        isRightFaced = true;
        xMin = transform.position.x - xRange;
        xMax = transform.position.x + xRange;
    }

    void FixedUpdate()
    {
        if (isRightFaced)
        {
            if (transform.position.x < xMax)
            {
                transform.Translate( Vector2.right * Time.deltaTime * speed );
            }
            else
            {
                isRightFaced = false;
                transform.localScale *= new Vector2(-1,1);
            }
        }
        else
        {
            if (transform.position.x > xMin)
            {
                transform.Translate( Vector2.left * Time.deltaTime * speed );
            }
            else
            {
                isRightFaced = true;
                transform.localScale *= new Vector2(-1,1);
            }
        }
    }

    void OnCollisionStay2D(Collision2D other) {
        other.transform.Translate( (isRightFaced ? Vector2.right:Vector2.left) * Time.deltaTime * speed );
    }
}
