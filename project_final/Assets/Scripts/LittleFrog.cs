using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleFrog : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;

    public LayerMask playerLayer;
    private Animator anim;
    public float radious;

    private DialogControl dc;
    bool onRadious, started = false;

    void Start()
    {
        dc = FindObjectOfType<DialogControl>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Interact();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z) && onRadious && !started)
        {
            started = true;
            dc.Speech(profile, speechTxt, actorName);
        }
        else if(onRadious)
        {
            anim.SetBool("player_hit", true);
        }
        else{
            anim.SetBool("player_hit", false);
        }
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);

        // Se colidir
        if(hit != null)
        {
            onRadious = true;
        }
        else
        {
            onRadious = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}
