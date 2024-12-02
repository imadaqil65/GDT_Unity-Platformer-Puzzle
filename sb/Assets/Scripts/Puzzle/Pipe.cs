using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Pipe : MonoBehaviour
{
    float[] rotations = { 0, 90, 180, 270 };
    [SerializeField] int[] correctAngle; // Array of correct angles for alignment
    int rotationAngle = 90; // Angle to rotate by each time
    private int currentRotation = 0; // Tracks current rotation

    // Randomize rotation at start
    private void Start()
    {
        int rand = Random.Range(0, rotations.Length);
        currentRotation = (int)rotations[rand];  // Set current rotation to the randomized value
        transform.eulerAngles = new Vector3(0, 0, currentRotation); // Apply the rotation
    }

    // Rotates the pipe by the defined angle
    public void RotatePipe()
    {
        currentRotation = (currentRotation + rotationAngle) % 360;
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);
    }

    // Checks if the pipe is correctly aligned
    public bool IsCorrectlyAligned()
    {
        if (correctAngle.Contains(currentRotation))
        {
            return true;
        }
        else if (CompareTag("ExtraPipes")) // Extra pipes that do not need alignment
        {
            return true;
        }

        return false;
    }
}
