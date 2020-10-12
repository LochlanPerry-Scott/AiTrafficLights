using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject[] cars;
    public Transform[] spawnPoints;
    int index;
    int index2;
    GameObject car;
    Transform spawn;
    public float spawnrate;

    public List<CarDetection> VerticalCars;
    public List<CarDetection> HorizontalCars;

    private void Start()
    {
        InvokeRepeating("Spawn", 2.0f, spawnrate);
    }

    void Spawn()
    {
        index = UnityEngine.Random.Range(0, cars.Length);
        car = cars[index];

        index2 = UnityEngine.Random.Range(0, spawnPoints.Length);
        spawn = spawnPoints[index2];

        GameObject carSpawn = Instantiate(car, spawn.position, spawn.rotation, null);
        CarDetection carScript = carSpawn.GetComponent<CarDetection>();


        if(index2 == 0 || index2 == 2)
        {
            Debug.Log("Vertical");
            VerticalCars.Add(carScript);
            return;
        }

        if (index2 == 1 || index2 == 2)
        {
            Debug.Log("Horizontal");
            HorizontalCars.Add(carScript);
            return;
        }

        //carScript.TriggerStopCar(false);
        //Debug.Log("The car is " + car + "The Spawn is" + spawn.position);
    }

    private void SetLane()
    {

    }
}
