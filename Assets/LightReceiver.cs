using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReceiver : MonoBehaviour
{
    [SerializeField] private LightManager lightManager;
    [SerializeField] private GameObject pathChecker;

    public void ReceiveMessage(LightManager.TravelDirection direction)
    {
        // Car is at lights now
        lightManager.ChangeLights(direction);
        //pathChecker.SetActive(true);
    }
}
