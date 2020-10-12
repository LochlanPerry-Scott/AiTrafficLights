using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CarDetection : MonoBehaviour
{
    public Vector3 raycastOffset;
    public LayerMask layerToHit;
    public float dist;
    private RaycastHit hit;
    private bool STOP_MOVING = false;

    private float speed = 15;
    [SerializeField] private float speedMultiplier = 1;

    private void Awake()
    {
        DOTween.Init();
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime * (speed * speedMultiplier);

        if (Physics.Raycast(transform.position + raycastOffset, transform.forward, out hit, dist, layerToHit))
        {
            if (STOP_MOVING)
                return;

            int hitLayer = hit.transform.gameObject.layer;

            if (hitLayer == LayerMask.NameToLayer("Vehicle"))
            {
                STOP_MOVING = true;
                SlowDownCar();
                Debug.Log(hit.collider.gameObject);

                return;
            }

            if (hitLayer == LayerMask.NameToLayer("TrafficLights"))
            {
                STOP_MOVING = true;
                SlowDownCar();

                // 1 = North
                // 2 = East
                // 3 = South
                // 4 = West
                // Potentiallity to add turning here
                LightManager.TravelDirection directionToTravel = PickNextDirection(Random.Range(1, 2));
                hit.transform.GetComponent<LightReceiver>().ReceiveMessage(directionToTravel);
                Debug.Log(hit.collider.gameObject);

                return;
            }
        }
    }

    private void SlowDownCar ()
    {
        float to = (STOP_MOVING) ? 0 : 1;
        DOTween.To(() => speedMultiplier, x => speedMultiplier = x, to, 2);
    }

    public void SpeedUpCar()
    {
        float to = 1;
        DOTween.To(() => speedMultiplier, x => speedMultiplier = x, to, 2);
    }

    private LightManager.TravelDirection PickNextDirection(int Direction)
    {
        switch (Direction)
        {
            case 1:
                return LightManager.TravelDirection.North;

            case 2:
                return LightManager.TravelDirection.East;

            case 3:
                return LightManager.TravelDirection.South;

            case 4:
                return LightManager.TravelDirection.West;
        }

        return 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(transform.position + raycastOffset, transform.forward * dist);
    }
}
