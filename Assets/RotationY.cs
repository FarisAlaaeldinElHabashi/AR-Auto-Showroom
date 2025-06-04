using UnityEngine;

public class CarRotation : MonoBehaviour
{
    [Header("Rotation Speed in degrees per second")]
    public float rotationSpeed = 50f;

    void Update()
    {
        // Rotate around Y-axis
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}
