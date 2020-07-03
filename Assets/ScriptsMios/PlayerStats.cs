using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int playerHealthMax;
    public int currentHealth;
    public float currentExp;
    public float expMax;
    public int mpMax;
    public int currentMp;

    public bool flashActive;

    [SerializeField]

    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer[] playerSprite;
   
    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponentsInChildren<SpriteRenderer>();
        expMax = 1000;
        mpMax = 100;
        playerHealthMax = 100;
        currentMp = mpMax;
        currentHealth = playerHealthMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (flashActive)
        {
            if (flashCounter > flashLength*.99f)
            {
                playerSprite[0].color = new Color(playerSprite[0].color.r, playerSprite[0].color.g, playerSprite[0].color.b, 0f);
                playerSprite[1].color = new Color(playerSprite[1].color.r, playerSprite[1].color.g, playerSprite[1].color.b, 0f);

            }else if (flashCounter > flashLength * .82f)
            {
                playerSprite[0].color = new Color(playerSprite[0].color.r, playerSprite[0].color.g, playerSprite[0].color.b, 1f);
                playerSprite[1].color = new Color(playerSprite[1].color.r, playerSprite[1].color.g, playerSprite[1].color.b, 0.4f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                playerSprite[0].color = new Color(playerSprite[0].color.r, playerSprite[0].color.g, playerSprite[0].color.b, 0f);
                playerSprite[1].color = new Color(playerSprite[1].color.r, playerSprite[1].color.g, playerSprite[1].color.b, 0f);
            }
            else if (flashCounter > flashLength * .49f)
            {
                playerSprite[0].color = new Color(playerSprite[0].color.r, playerSprite[0].color.g, playerSprite[0].color.b, 1f);
                playerSprite[1].color = new Color(playerSprite[1].color.r, playerSprite[1].color.g, playerSprite[1].color.b, 0.4f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                playerSprite[0].color = new Color(playerSprite[0].color.r, playerSprite[0].color.g, playerSprite[0].color.b, 0f);
                playerSprite[1].color = new Color(playerSprite[1].color.r, playerSprite[1].color.g, playerSprite[1].color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                playerSprite[0].color = new Color(playerSprite[0].color.r, playerSprite[0].color.g, playerSprite[0].color.b, 1f);
                playerSprite[1].color = new Color(playerSprite[1].color.r, playerSprite[1].color.g, playerSprite[1].color.b, 0.4f);
            }
            else if (flashCounter > 0)
            {
                playerSprite[0].color = new Color(playerSprite[0].color.r, playerSprite[0].color.g, playerSprite[0].color.b, 0f);
                playerSprite[1].color = new Color(playerSprite[1].color.r, playerSprite[1].color.g, playerSprite[1].color.b, 0f);
            }
            else 
            {
                playerSprite[0].color = new Color(playerSprite[0].color.r, playerSprite[0].color.g, playerSprite[0].color.b, 1f);
                playerSprite[1].color = new Color(playerSprite[1].color.r, playerSprite[1].color.g, playerSprite[1].color.b, 0.4f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }

   public void HurtPlayer(int dmgtoPlayer)
    {
        currentHealth -= dmgtoPlayer;
        flashActive = true;
        flashCounter = flashLength;
        if(currentHealth <= 0)
        {
            //gameObject.GetComponent<Transform>().position.Set(0, 0, 0);
            //gameObject.SetActive(false);
        }
    }
    public void GainExp(float expgain)
    {
        currentExp += expgain;
    }
}
