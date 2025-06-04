using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class CarImageTracker : MonoBehaviour
{
    public GameObject car1Prefab;
    public GameObject car2Prefab;
    public GameObject car3Prefab;

    private Dictionary<string, GameObject> spawnedCars = new Dictionary<string, GameObject>();

    void OnEnable()
    {
        GetComponent<ARTrackedImageManager>().trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        GetComponent<ARTrackedImageManager>().trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            SpawnOrUpdateCar(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            SpawnOrUpdateCar(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            if (spawnedCars.TryGetValue(trackedImage.referenceImage.name, out GameObject obj))
            {
                Destroy(obj);
                spawnedCars.Remove(trackedImage.referenceImage.name);
            }
        }
    }

    void SpawnOrUpdateCar(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;

        if (!spawnedCars.ContainsKey(name))
        {
            GameObject prefab = null;

            switch (name)
            {
                case "lambo":
                    prefab = Instantiate(car1Prefab, trackedImage.transform);
                    break;
                case "MclarenP1":
                    prefab = Instantiate(car2Prefab, trackedImage.transform);
                    break;
                case "MclarenW1":
                    prefab = Instantiate(car3Prefab, trackedImage.transform);
                    break;
            }

            if (prefab != null)
                spawnedCars[name] = prefab;
        }
        else
        {
            spawnedCars[name].transform.position = trackedImage.transform.position;
            spawnedCars[name].transform.rotation = trackedImage.transform.rotation;
        }
    }
}
