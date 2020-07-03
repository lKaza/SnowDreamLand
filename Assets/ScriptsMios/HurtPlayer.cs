using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{
    private PlayerStats healthMan;
    private float waitToHurt = 1.5f;
    private bool isTouching = false;
    [SerializeField]
    public int dmg=20;
    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
       if(isTouching == true)
        {
           
            waitToHurt -= Time.deltaTime;
            if(waitToHurt <= 0)
            {
              healthMan.HurtPlayer(dmg);
                waitToHurt = 1.5f;
               
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().HurtPlayer(dmg);
            //SceneManager.LoadScene("BlankScene");

        }

    }
    private void OnCollisionStay2D(Collision2D other)
    {

        if (other.collider.tag == "Player")   
        isTouching = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        
        if (other.collider.tag == "Player")
        {
            
            isTouching = false;
            waitToHurt = 1.5f;
        }
    }
}
