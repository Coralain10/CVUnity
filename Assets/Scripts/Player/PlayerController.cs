using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class PlayerController : MonoBehaviour
{
    public LiveArray liveArr;
    public ParticleSystem bloodParticle;
    Rigidbody2D rb;
    TouchingDirections touchingDirections;
    short speed = 16;
    float forwardInput;
    float jumpFirstPosition;
    bool isDying;
    bool isJumping;
    
    bool _isFacingRight;
    public bool IsFacingRight
    {
        get => _isFacingRight;
        private set
        {
            _isFacingRight = value;
            transform.localScale *= new Vector2(-1,1);
        }
    }


    void Awake()
    {
        touchingDirections = GetComponent<TouchingDirections>();
        rb = GetComponent<Rigidbody2D>();
        _isFacingRight = true;
        isJumping = false;
    }

    void FixedUpdate()
    {
        if (isJumping) Jump();
    }

    void Update()
    {
        if (!liveArr.lostAllLives)
        {
            setFacingDirection();
            Move();
            CheckJump();
        }
    }

    void setFacingDirection ()
    {
        forwardInput = Input.GetAxis("Horizontal");
        if (forwardInput > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if (forwardInput < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }

    void Move()
    {
        if (touchingDirections.IsOnGround)
        {
            rb.velocity = new Vector2(forwardInput * speed, rb.velocity.y);
        }
        else
        {
            float airResistance = 2f;
            rb.velocity = new Vector2(forwardInput * (speed/airResistance), rb.velocity.y);
        }
    }

    void CheckJump() {
        if (touchingDirections.IsOnGround)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJumping = true;
            }

            if ( rb.velocity.x == 0 )
            {
                jumpFirstPosition = transform.position.x;
            }
        }
    }

    void Jump()
    {
        //Impultso para saltar según cuánto corrió
        float jumpMaxDistance = 1.5f;
        float jumpCurrDistance = Mathf.Min( Mathf.Abs(transform.position.x - jumpFirstPosition), jumpMaxDistance );
        float jumpMaxHeight = 2.5f, jumpMinHeight = 1.25f;
        float jumpCurrHeight = Mathf.Max(jumpMaxHeight * (jumpCurrDistance/jumpMaxDistance), jumpMinHeight);
        float jumpForce = Mathf.Sqrt( jumpCurrHeight * -2 * (Physics2D.gravity.y * rb.gravityScale)) * rb.mass;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isJumping = false;
    }

    void gotDamage()
    {
        bloodParticle.Play();
        liveArr.SetDamage();
        if (liveArr.lostAllLives)
        {
            isDying = false;
            Debug.Log("GAME OVER");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            isDying = true;
            StartCoroutine( Dying() );
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Spikes"))
        {
            isDying = false;
            // StartCoroutine( liveArr.Recover() );
            liveArr.Recover();
        }
    }

    IEnumerator Dying() {
        while (isDying) {
            gotDamage();
            yield return new WaitForSeconds(0.25f);
        }
    }
}
