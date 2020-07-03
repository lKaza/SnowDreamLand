using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator myAnim;
    //private Transform Target;
    public GameObject Target;
    public Transform homePos;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Target.transform.position,transform.position)<= maxRange && Vector3.Distance(Target.transform.position,transform.position) >= minRange)
        {
            FollowPlayer();
        }
        else if(Vector3.Distance(Target.transform.position,transform.position) >=maxRange )
        {
            GoHome();        
        }

    }

    public void FollowPlayer()
    {
        myAnim.SetBool("isMoving",true);
        myAnim.SetFloat("moveX", (Target.transform.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (Target.transform.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position,Target.transform.position,speed*Time.deltaTime);
        
    }

    public void GoHome()
    {
       
        myAnim.SetFloat("moveX", (homePos.transform.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (homePos.transform.position.y - transform.position.y));       
        transform.position = Vector3.MoveTowards(transform.position,homePos.position,speed*Time.deltaTime);
        if(transform.position == homePos.position)
        {
        myAnim.SetBool("isMoving", false);
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetSpeed()
    {
        return this.speed;
    }
  

}
