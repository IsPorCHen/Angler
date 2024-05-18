using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateActivation : MonoBehaviour
{
    // Private boolean to track the activation state
    private bool _isActive = false;

    // Public property to get the activation state
    public bool GetActive
    {
        get { return _isActive; }
    }

    // This method is called when another collider enters the trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other collider has the tag "ActivationPlate" or "Player"
        if (other.gameObject.CompareTag("ActivationPlate") || other.gameObject.CompareTag("Player"))
        {
            // Set _isActive to true
            _isActive = true;
            Debug.Log("Activated by: " + other.gameObject.name); // For debugging
        }
    }

    // This method is called when another collider exits the trigger collider
    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the other collider has the tag "ActivationPlate" or "Player"
        if (other.gameObject.CompareTag("ActivationPlate") && other.gameObject.CompareTag("Player"))
        {
            // Set _isActive to false
            _isActive = false;
            Debug.Log("Deactivated by: " + other.gameObject.name); // For debugging
        }
    }
}
