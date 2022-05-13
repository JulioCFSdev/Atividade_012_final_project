using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thwomp : MonoBehaviour
{
    public GameObject Block;
    public GameObject hit;
    private bool isMoving;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if(isMoving == true){
            Block.transform.position = Vector2.MoveTowards(Block.transform.position, hit.transform.position, speed * Time.deltaTime);
        }
    }


    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.CompareTag("Player")){
            Block.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Block.GetComponent<Rigidbody2D>().gravityScale = 7;
            Block.GetComponent<Rigidbody2D>().mass = 400;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Ground")){
            Block.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            Block.GetComponent<Rigidbody2D>().gravityScale = 0;
            Block.GetComponent<Rigidbody2D>().mass = 0;

            isMoving = true;
        }

    }


}
