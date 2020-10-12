using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    GameObject stopper;

    [SerializeField] private bool stopCar = true;
    //private void Start()
    //{
    //    if(stopper = null)
    //    {
    //        stopper = GameObject.FindGameObjectWithTag("Counter");
    //    }
    //}

    private void Update()
    {
        move();
    }

    void move()
    {
        //if(stopper.GetComponent<Counter>().horizontalCount >= stopper.GetComponent<Counter>().verticalCount)
        //{
            
        //}
        
        if(!stopCar)
            transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    public void TriggerStopCar(bool value)
    {
        stopCar = value;
    }
}
