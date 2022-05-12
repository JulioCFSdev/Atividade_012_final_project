using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toadman_FB : MonoBehaviour
{
    private Rigidbody2D rig;

    public GameObject player;

    public float speed;

    private Animator anim;


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

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "static_trap")
        {
            Destroy(gameObject);
        }
    }
}
