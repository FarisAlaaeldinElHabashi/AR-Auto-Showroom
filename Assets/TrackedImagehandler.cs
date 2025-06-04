using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TrackedImageHandler : MonoBehaviour
{
    public GameObject Lamborghini;
    public GameObject McLarenP1;
    public GameObject McLarenW1;

    private Dictionary<string, GameObject> spawnedCars = new Dictionary<string, GameObject>();

    void OnEnable()
    {
        ARTrackedImageManager manager = FindObjectOfType<ARTrackedImageManager>();
        manager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        ARTrackedImageManager manager = FindObjectOfType<ARTrackedImageManager>();
        manager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage image in eventArgs.added)
        {
            SpawnCar(image);
        }

        foreach (ARTrackedImage image in eventArgs.updated)
        {
            UpdateCarPosition(image);
        }
    }

    void SpawnCar(ARTrackedImage image)
    {
        string name = image.referenceImage.name;
        GameObject prefab = null;

        if (name == "Lamborghini") prefab = Lamborghini;
        else if (name == "McLarenP1") prefab = McLarenP1;
        else if (name == "McLarenW1") prefab = McLarenW1;

        if (prefab != null && !spawnedCars.ContainsKey(name))
        {
            GameObject car = Instantiate(prefab, image.transform.position, image.transform.rotation);
            car.transform.parent = image.transform;
            spawnedCars[name] = car;
        }
    }

    void UpdateCarPosition(ARTrackedImage image)
    {
        string name = image.referenceImage.name;
        if (spawnedCars.ContainsKey(name))
        {
            GameObject car = spawnedCars[name];
            car.transform.position = image.transform.position;
            car.transform.rotation = image.transform.rotation;
        }
    }
}
