using UnityEngine;
using System;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject[] cars;
    public Transform[] spawnPoints;
    int index;
    int index2;
    GameObject car;
    Transform spawn;
    public float spawnrate;

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

        Instantiate(car, spawn);
        Debug.Log("The car is " + car + "The Spawn is" + spawn.position);
    }
}
