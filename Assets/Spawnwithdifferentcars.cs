using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracker : MonoBehaviour
{
    public GameObject McLarenP1;
    public GameObject McLarenW1;
    public GameObject Lamborghini;

    private ARTrackedImageManager trackedImageManager;

    void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            SpawnCar(trackedImage);
        }
    }

    void SpawnCar(ARTrackedImage trackedImage)
    {
        GameObject prefabToSpawn = null;

        switch (trackedImage.referenceImage.name)
        {
            case "McLarenP1":
                prefabToSpawn = McLarenP1;
                break;
            case "McLarenW1":
                prefabToSpawn = McLarenW1;
                break;
            case "Lamborghini":
                prefabToSpawn = Lamborghini;
                break;
        }

        if (prefabToSpawn != null)
        {
            Instantiate(prefabToSpawn, trackedImage.transform.position, trackedImage.transform.rotation, trackedImage.transform);
        }
    }
}
