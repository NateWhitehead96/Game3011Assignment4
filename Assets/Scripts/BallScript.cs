using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public int HorizontalDirection = 1; // start it going to the right
    public int VerticalDirection = 1; //start it going up
    public int Direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Direction == 1)
        {
            MoveBallUp();
        }
        else if(Direction == 2)
        {
            MoveBallRight();
        }
        else if(Direction == 3)
        {
            MoveBallLeft();
        }
        else if(Direction == 4)
        {
            MoveBallDown();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("things");
        if(collision.gameObject.CompareTag("Tile"))
        {
            //Direction = collision.gameObject.GetComponent<TileScript>().direction;
            if(collision.gameObject.GetComponent<TileScript>().direction == global::Direction.DOWN)
            {
                print("lets try this");
                Direction = 4;
                
            }
            if (collision.gameObject.GetComponent<TileScript>().direction == global::Direction.UP)
            {
                
                Direction = 1;
            }
            if (collision.gameObject.GetComponent<TileScript>().direction == global::Direction.RIGHT)
            {
                
                Direction = 2;
            }
            if (collision.gameObject.GetComponent<TileScript>().direction == global::Direction.LEFT)
            {
               
                Direction = 3;
            }
        }
    }

    private void MoveBallUp()
    {
        transform.position += transform.up * Time.deltaTime;
    }
    private void MoveBallDown()
    {
        transform.position -= transform.up * Time.deltaTime;
    }
    private void MoveBallLeft()
    {
        print("in here");
        transform.position -= transform.right * Time.deltaTime;
    }
    private void MoveBallRight()
    {
        print("in here");
        transform.position += transform.right * Time.deltaTime;
    }
}
