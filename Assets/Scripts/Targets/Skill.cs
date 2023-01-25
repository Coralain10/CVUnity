using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Skill : TargetGO
{
    Rigidbody2D rb;
    CapsuleCollider2D col;
    ContactFilter2D castFilter;
    GameObject obj;
    [SerializeField] RaycastHit2D[] closeHits = new RaycastHit2D[5];
    [SerializeField] float speed = 2;
    [SerializeField] float walkStart;
    [SerializeField] float walkMaxDistance = 3f;
    [SerializeField] float halfWidth;
    [SerializeField] float visionRange = 4f;
    [SerializeField] int direction;
    [SerializeField] bool isPlayerClose;
    // public float xMin;
    // public float xMax;

    // public override void RestoreObj(SaveTarget target)
    // {
    //     base.RestoreObj(target);
    // }
    // public void RestoreInfo(SkillInfo skillInfo)
    // {
    //     RestoreInfo((TargetInfo)skillInfo);
    // }

    //TODO  Move | Physics2D raycast:
    // 1 a cada lado + offset de 0.25f aprox. si no toca suelo, girar.
    // 1 al frente. Si player cerca, perseguirlo, sino, retornar mov normal.

    override protected void Awake() {
        base.Awake();
        obj = transform.Find("Object").gameObject;
        rb = obj.GetComponent<Rigidbody2D>();
        col = obj.GetComponent<CapsuleCollider2D>();
        direction = Random.value > 0.5f ? 1 : -1;
        float padding = 0.1f;
        halfWidth = col.bounds.size.x * obj.transform.localScale.x / 2.0f + padding;
        walkStart = obj.transform.position.x;
    }

    void FixedUpdate() {
        if (!isOnGround() || crashedOnNotPlayer())
        {
            ChangeDirection();
        }
        // Physics2D.Raycast(obj.transform.position, direction*Vector2.right, out closeHit, visionRange);
        // if (closeHit.transform.tag == "Player") {
        //     Debug.Log("Cerca a jugador");
        // }
        isPlayerClose = col.Cast(direction*Vector2.right, castFilter, closeHits, visionRange) > 0;
    }
    void Update()
    {
        if (!isPlayerClose && Mathf.Abs(obj.transform.position.x - walkStart) >= walkMaxDistance)
        {
            ChangeDirection();
        }
        rb.velocity = new Vector2( direction*speed , rb.velocity.y);
    }
    bool isOnGround() {
        Vector2 checkStart = (Vector2) obj.transform.position +
                            new Vector2(direction*halfWidth, -0.48f);
        RaycastHit2D rhit = Physics2D.Raycast(checkStart, Vector2.down, 0.5f);
        // Debug.DrawRay(checkStart, Vector2.down * 0.5f, Color.blue);
        //  && rhit.transform.tag != "Ground"
        //si llega al límite de un bloque, cambia de dirección
        return rhit.collider != null;
    }
    bool crashedOnNotPlayer() {
        Vector2 checkStart = (Vector2) obj.transform.position +
                            new Vector2(direction*halfWidth, 0.4f);
        RaycastHit2D rhit = Physics2D.Raycast(checkStart, Vector2.down, 0.8f);
        // Debug.DrawRay(checkStart, Vector2.down * 0.5f, Color.blue);
        //si llega al límite de un bloque, cambia de dirección
        if (rhit.collider == null) return false;
        else if ( rhit.transform.tag == "Player" ) return false;
        else return !rhit.collider.isTrigger;
    }
    void ChangeDirection()
    {
        direction *= -1;
        walkStart = obj.transform.position.x;
    }

    // void OnTriggerEnter2D (Collider2D other)
    // {
    //     if (other.CompareTag("Player"))
    //     {
    //         tManager.skillsRows[infoIndex].obtained = obtained = true;
    //     }
    // }
    // void OnDrawGizmosSelected()
    // {
    //     if (rhit.collider != null && obj!= null)
    //     {
    //         Gizmos.color = Color.yellow;
    //         Gizmos.DrawLine(obj.transform.position, rhit.transform.position);
    //     }
    // }
}