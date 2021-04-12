using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int HorizontalMovement = 0;
    private int VerticalMovement = 0;
    private bool inMotion = false;

    private int speed = 1;

    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inMotion)
        {
            speed = 1;
            transform.position = new Vector3(transform.position.x + HorizontalMovement * speed * Time.deltaTime, transform.position.y + VerticalMovement * speed * Time.deltaTime, 0);

        }
        else
            speed = 0;
        Move();
    }

    public void Move()
    {
        if (!inMotion)
        {
            if (Input.GetKey("w"))
            {
                //transform.position += transform.up * Time.deltaTime;
                VerticalMovement = 1;
                inMotion = true;
            }
            if (Input.GetKey("s"))
            {
                //transform.position -= transform.up * Time.deltaTime;
                VerticalMovement = -1;
                inMotion = true;
            }
            if (Input.GetKey("d"))
            {
                //transform.position += transform.right * Time.deltaTime;
                HorizontalMovement = 1;
                inMotion = true;
            }
            if (Input.GetKey("a"))
            {
                //transform.position -= transform.right * Time.deltaTime;
                HorizontalMovement = -1;
                inMotion = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("ass");
        if (collision.gameObject.CompareTag("wall"))
        {
            print("tits");
            inMotion = false;
            VerticalMovement = 0;
            HorizontalMovement = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tile"))
        {
            other.gameObject.GetComponent<MeshRenderer>().material = material;
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.CompareTag("wall"))
    //    {
    //        inMotion = false;
    //        VerticalMovement = 0;
    //        HorizontalMovement = 0;
    //    }
    //    if(collision.gameObject.CompareTag("Tile"))
    //    {
    //        //collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    //    }
    //}
}
