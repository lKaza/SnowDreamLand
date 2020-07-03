using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    private PlayerStats healthMan;
    public Slider healthBar;
    public Slider mpBar;
    public Slider expBar;
    public Text hpText;
    public Text mpText;
    public Text expText;
    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = healthMan.playerHealthMax;
        mpBar.maxValue = healthMan.mpMax;
        expBar.maxValue = healthMan.expMax;


        mpBar.value = healthMan.currentMp;
        healthBar.value = healthMan.currentHealth;
        expBar.value = healthMan.currentExp;

        hpText.text = "HP: " + healthMan.currentHealth + "/" + healthMan.playerHealthMax;
        mpText.text = "MP: " + healthMan.currentMp + "/" + healthMan.mpMax;
        expText.text = "Exp: " + healthMan.currentExp + "/" + healthMan.expMax;

    }
}
