using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toadman_FB : MonoBehaviour
{
    private Rigidbody2D rig;

    public GameObject player;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        
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
        }
    }
}
