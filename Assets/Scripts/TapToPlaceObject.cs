using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class TapToPlaceObject : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject placementUI;

    private ARRaycastManager arRaycastManager;
    private bool isObjectPlaced = false;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public static GameObject spawnedObject; // So other scripts can access it

    void Start()
    {
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    void Update()
    {
        if (isObjectPlaced || Input.touchCount == 0)
            return;

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 touchPos = Input.GetTouch(0).position;

            if (arRaycastManager.Raycast(touchPos, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                spawnedObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
                isObjectPlaced = true;

                if (placementUI != null)
                    placementUI.SetActive(false);
            }
        }
    }
}
