using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rigibody2d;
    public bool vertical;
    Animator animator;
    public int direction = 1;
    public float changeTime = 3.0f;
    float timer;


    // Start is called before the first frame update
    void Start()
    {
        rigibody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = changeTime;
    }

    void Update()
   {
        timer -= Time.deltaTime;


            if (timer < 0)
            {
                direction = -direction;
                timer = changeTime;
            }
   }

    // FixedUpdate has the same call rate as the physics system
    void FixedUpdate()
    {
        Vector2 position = rigibody2d.position;
        
        

        if (vertical)
       {
           position.y = position.y + speed * direction * Time.deltaTime;
           animator.SetFloat("Move X", 0);
           animator.SetFloat("Move Y", direction);
       }
       else
       {
           position.x = position.x + speed * direction * Time.deltaTime;
           animator.SetFloat("Move X", direction);
           animator.SetFloat("Move Y", 0);
       }

        rigibody2d.MovePosition(position);
    }

    void OnTriggerEnter2D(Collider2D other)
   {
       PlayerController player = other.gameObject.GetComponent<PlayerController>();


       if (player != null)
       {
           player.ChangeHealth(-1);
       }
   }
}
