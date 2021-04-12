using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeBehaviour : MonoBehaviour
{
    public Transform myTransform;
    private float shakeDuration = 0;
    private float shakeMagnitude = 0.7f;
    private float damping = 1f;
    Vector3 initalPosition;
    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        initalPosition = myTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(shakeDuration > 0)
        {
            myTransform.localPosition = initalPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeDuration -= Time.deltaTime * damping;
        }
        else
        {
            shakeDuration = 0f;
            myTransform.localPosition = initalPosition;
        }
    }

    public void Shake()
    {
        shakeDuration = 2f;
    }
}
