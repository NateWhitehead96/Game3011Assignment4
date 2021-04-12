using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 1 * Time.deltaTime, 0);

        if(transform.position.y <= -13)
        {
            transform.position = new Vector3(transform.position.x, 18.5f, 0);
        }
    }
}
