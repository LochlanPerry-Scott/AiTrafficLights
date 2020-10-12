using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    GameObject stopper;

    private void Start()
    {
        if(stopper = null)
        {
            stopper = GameObject.FindGameObjectWithTag("Counter");
        }
    }

    private void Update()
    {
        move();
    }

    void move()
    {
        if(stopper.GetComponent<Counter>().horizontalCount >= stopper.GetComponent<Counter>().verticalCount)
        {
            
        }
        
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
