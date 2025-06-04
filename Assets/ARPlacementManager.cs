using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.AR; // ✅ Add this!

public class ARCarSelector : MonoBehaviour
{
    public List<GameObject> carPrefabs; // Assign 3 cars in Inspector
    public ARPlacementInteractable placementInteractable;

    public void SelectCar(int index)
    {
        if (index >= 0 && index < carPrefabs.Count)
        {
            placementInteractable.placementPrefab = carPrefabs[index];
        }
    }
}
