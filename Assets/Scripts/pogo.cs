using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pogo : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpforce = 5;
    public bool Isgrounded = false;
    Touch touch;    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Isgrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (Isgrounded == true)
            Isgrounded = false;
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            
            Touch extouch = touch;
            touch = Input.GetTouch(0);
            
            if(touch.phase == TouchPhase.Moved)
            {

                if (touch.position.x < extouch.position.x)
                {
                    transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y);
                }

                else if (touch.position.x > extouch.position.x)
                {
                    transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y);
                }


            }
        }

            if(Isgrounded == true)
        {
            rb.velocity = Vector3.up * jumpforce;
        }
    }
}
