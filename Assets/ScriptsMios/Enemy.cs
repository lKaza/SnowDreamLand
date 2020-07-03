using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyController controllerSpeed;

    public Animator animador;
    public EnemyController controller;

    public int maxHealth = 100;
    public int currentHealth;
    public float expvalue;

    public PlayerStats player;

    public bool flashActive;
    [SerializeField]

    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer enemySprite;

    private float speederino;
    public float staggerTime;
    // Start is called before the first frame update
    void Start()
    {
        controllerSpeed = GetComponent<EnemyController>();
        enemySprite = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (flashActive)
        {
            if (flashCounter > flashLength * .99f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
                

            }
            else if (flashCounter > flashLength * .82f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
             
            }
            else if (flashCounter > flashLength * .66f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
               
            }
            else if (flashCounter > flashLength * .49f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
               
            }
            else if (flashCounter > flashLength * .33f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
               
            }
            else if (flashCounter > flashLength * .16f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
              
            }
            else if (flashCounter > 0)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
                
            }
            else
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
              
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }}

    public void TakeDamage(int damage)
    {
        //play hurt animation
            flashActive = true;
            flashCounter = flashLength;
            currentHealth -= damage;
       
        if(currentHealth <= 0)
        {         
            Die();
        }
    }

    public void KnockBack(Vector3 pos)
    {       
        StartCoroutine(Stagger());
        Vector2 difference = transform.position - pos;
        transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y-0.1f);
    }
    void Die()
    {        
        animador.SetBool("isAlive", false);  
        GetComponent<Collider2D>().enabled = false;
        player.GainExp(expvalue); 
        StartCoroutine(MonsterDeath());       
    }
    IEnumerator MonsterDeath()
    {

        controller.enabled = false;
        
        yield return new WaitForSeconds(3f);
        this.enabled = false;

        Destroy(this.gameObject);
    }
    IEnumerator Stagger()
    {
        speederino = controllerSpeed.GetSpeed();
        controllerSpeed.SetSpeed(0f);
        yield return new WaitForSeconds(staggerTime);
        controllerSpeed.SetSpeed(speederino);
    }

}
