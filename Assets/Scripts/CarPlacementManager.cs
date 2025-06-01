// CarPlacementManager.cs
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

public class CarPlacementManager : MonoBehaviour
{
    public GameObject carPrefab;
    private GameObject spawnedCar;
    public ARRaycastManager raycastManager;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (Input.touchCount == 0 || spawnedCar != null)
            return;

        Touch touch = Input.GetTouch(0);

        if (raycastManager.Raycast(touch.position, hits))
        {
            Pose hitPose = hits[0].pose;
            spawnedCar = Instantiate(carPrefab, hitPose.position, hitPose.rotation);
        }
    }
}
