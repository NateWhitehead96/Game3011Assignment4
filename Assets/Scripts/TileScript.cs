using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    UP,
    RIGHT,
    DOWN,
    LEFT
}

public class TileScript : MonoBehaviour
{
    public Direction direction;

    private float rotationAmount = 90;
    // Start is called before the first frame update
    void Start()
    {
        
        int randomDirection = Random.Range(0, 4);
        if (randomDirection == 0)
        {
            direction = Direction.UP;
            transform.rotation = Quaternion.Euler(0, 0, -180);
        }
        else if (randomDirection == 1)
        {
           direction = Direction.RIGHT;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (randomDirection == 2)
        {
           direction = Direction.DOWN;
           transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (randomDirection == 3)
        {
            direction = Direction.LEFT;
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
        //if (direction == Direction.UP)
        //{
        //    transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.eulerAngles.z - rotationAmount);
        //}
        //else if (direction == Direction.RIGHT)
        //{
        //    transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.eulerAngles.z - rotationAmount);
        //}
        //else if (direction == Direction.DOWN)
        //{
        //    transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.eulerAngles.z - rotationAmount);
        //}
        //else if (direction == Direction.LEFT)
        //{
        //    transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.eulerAngles.z - rotationAmount);
        //}


        //Turn();
    }

   

    private void OnMouseDown()
    {
        //print("yo");
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePosition2D = new Vector2(mousePosition.x, mousePosition.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePosition2D, Vector2.zero);

        //if (hit.collider != null)
        //{
        //}
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.eulerAngles.z - rotationAmount);
            if (direction == Direction.UP)
            {
                direction = Direction.RIGHT;
            }
            else if (direction == Direction.RIGHT)
            {
                direction = Direction.DOWN;
            }
            else if (direction == Direction.DOWN)
            {
                direction = Direction.LEFT;
            }
            else if (direction == Direction.LEFT)
            {
                direction = Direction.UP;
            }
    }
}
