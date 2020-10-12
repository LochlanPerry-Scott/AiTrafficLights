using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Counter c;
    public bool horizontal;

    private void OnTriggerEnter(Collider other)
    {
        if(horizontal == true)
        {
            c.horizontalCount++;            
        }
        else
        {
            c.verticalCount++; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(MinusTime());
    }

    IEnumerator MinusTime()
    {
        yield return new WaitForSeconds(3f);
        if (horizontal == true)
        {
            c.horizontalCount--;
        }
        else
        {
            c.verticalCount--;
        }
    }


}
