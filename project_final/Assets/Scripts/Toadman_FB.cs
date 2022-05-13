using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toadman_FB : MonoBehaviour
{
    private Rigidbody2D rig;

    public GameObject player;

    public float speed;

    public Transform headPoint;

    private Animator anim;

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (player.GetComponent<player>().step_area == true)
        {
           rig.velocity = new Vector2(speed, rig.velocity.y);
           anim.SetBool("walk", true);
        }
    }

     bool playerDestroyed = false;
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "static_trap")
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Player")
        {
            
            float height = collision.contacts[0].point.y - headPoint.position.y;
            Debug.Log(height);

            if(height > 0 && !playerDestroyed)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                speed = 0;
                anim.SetTrigger("die");
                Debug.Log("foi");
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
                rig.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 0.33f);
            }
            else
            {
                anim.SetBool("attack", true);
                anim.SetBool("attack", false);
                playerDestroyed = true;
                GameController.instance.ShowGameOver();
                Destroy(collision.gameObject);
            }
        }
    }
}
