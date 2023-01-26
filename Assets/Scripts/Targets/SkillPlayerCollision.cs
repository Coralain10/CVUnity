using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillPlayerCollision : JumpOtherOnCollision
{
    PlayerController playerController;
    Skill skill;
    [SerializeField] int health = 4;
    [SerializeField] int hitDamage = 2;
    [SerializeField] int jumpSideForce = 64;
    
    void Start()
    {
        skill = GetComponent<Skill>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        jumpForce = 64; //96
    }
    
    void Update()
    {
        SetCollisionTopRange();
    }

    protected override void OnCollisionTopEnter(Collision2D other) {
        // Debug.Log("Player on top");
        GotDamage();
        base.OnCollisionTopEnter(other); //other jump
    }

    protected override void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.CompareTag("Player"))
        {
            base.OnCollisionEnter2D(other); //validate isOnTop
            if(!isOnTop) {
                other.rigidbody.AddForce( new Vector2(skill.direction * jumpSideForce, 0), ForceMode2D.Impulse);
                // Debug.Log("Player got damage");
                playerController.gotDamage();
                //TODO: player got damage
            }
        }
    }

    void GotDamage() {
        health -= hitDamage;
        if (health <= 0) skill.Die();
    }
}
