using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] public static LightManager instance;
    private void Awake()
    {
        instance = this;
    }

    [SerializeField]
    public enum TravelDirection
    {
        Null,
        North,
        East,
        South,
        West
    }

    [SerializeField] private Transform NorthLights;
    [SerializeField] private Transform SouthLights;

    [SerializeField] private Transform EastLights;
    [SerializeField] private Transform WestLights;

    private bool IS_CHANGING = false;

    public void ChangeLights (TravelDirection direction)
    {
        if (direction == TravelDirection.North || direction == TravelDirection.South)
        {
            foreach (var car in Spawner.instance.VerticalCars)
            {
                car.GetComponent<CarDetection>().SpeedUpCar();
            }

            Spawner.instance.VerticalCars.Clear();
        }

        if (direction == TravelDirection.East || direction == TravelDirection.West)
        {
            foreach (var car in Spawner.instance.HorizontalCars)
            {
                car.GetComponent<CarDetection>().SpeedUpCar();
            }

            Spawner.instance.HorizontalCars.Clear();
        }

        if (IS_CHANGING)
        {
            WaitLonger(direction);
            return;
        }

        Debug.LogWarning("Changing Lights for " + direction);
        switch (direction)
        {
            case TravelDirection.North:
                StartCoroutine(LightTimer(10, 1, NorthLights, SouthLights));
                break;

            case TravelDirection.East:
                StartCoroutine(LightTimer(10, 2, EastLights, WestLights));
                break;


            case TravelDirection.South:
                StartCoroutine(LightTimer(10, 1, NorthLights, SouthLights));
                break;

            case TravelDirection.West:
                StartCoroutine(LightTimer(10, 2, EastLights, WestLights));
                break;
        }
    }

    IEnumerator WaitLonger (TravelDirection travelDirection)
    {
        yield return new WaitForSeconds(5);
        ChangeLights(travelDirection);
    }

    IEnumerator LightTimer(float lightTime, int travelDirection, Transform direction1, Transform direction2 = null)
    {
        IS_CHANGING = true;

        direction1.gameObject.SetActive(false);
        direction2.gameObject.SetActive(false);

        yield return new WaitForSeconds(lightTime);

        direction1.gameObject.SetActive(true);
        direction2.gameObject.SetActive(true);

        IS_CHANGING = false;

        ChangeLights((travelDirection == 1) ? TravelDirection.East : TravelDirection.North);
    }
}
