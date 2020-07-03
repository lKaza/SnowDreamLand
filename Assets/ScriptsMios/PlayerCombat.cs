using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    

    public float attackRange = 0.5f;
    public int attackDamage = 20;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    private float attackTime = 0.5f;
    private float attackCounter = 0.5f;
    private bool isAttacking;

   
    public Rigidbody2D rb;

    Vector3 hitbox;
    // Update is called once per frame

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        hitbox.x = 0;
        hitbox.y = 0;
        if (isAttacking)
        {
            
            rb.velocity = Vector2.zero;

            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                animator.SetBool("isAttacking", false);
                isAttacking = false;
            }
        }
        if (Time.time >=nextAttackTime)
        {
            

            if (Input.GetKeyDown(KeyCode.Space))
        {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
        }
        }
    }
    void Attack()
    {
        animator.SetBool("isAttacking", true);
        isAttacking = true;
        attackCounter = attackTime;
        if (animator.GetFloat("lastMoveX") == 0.1f)
        {
            hitbox = attackPoint.position + hitbox;
            hitbox.x += 0.15f;
            hitbox.y += 0.135f;
            SetAttackPosition(hitbox);

        }else if (animator.GetFloat("lastMoveX") == -0.1f)
        {
            hitbox = attackPoint.position + hitbox;
            hitbox.x += -0.15f;
            hitbox.y += 0.135f;
            SetAttackPosition(hitbox);

        }
        else if (animator.GetFloat("lastMoveY") == 0.1f)
        {
            hitbox = attackPoint.position + hitbox;
            hitbox.y += 0.45f;
            SetAttackPosition(hitbox);

        }
        else if (animator.GetFloat("lastMoveY") == -0.1f)
        {
            hitbox = attackPoint.position + hitbox;
            
            SetAttackPosition(hitbox);

        }


    }

    void SetAttackPosition(Vector3 pos)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(pos, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().KnockBack(pos);
            enemy.GetComponent<Enemy>().TakeDamage(20);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
      Gizmos.DrawWireSphere(hitbox, attackRange);
    }
}
