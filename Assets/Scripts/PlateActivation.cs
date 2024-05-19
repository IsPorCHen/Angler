using UnityEngine;

public class PlateActivation : MonoBehaviour
{
    private bool _isActive = false;

    public bool GetActive
    {
        get { return _isActive; }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ActivationPlate") || other.gameObject.CompareTag("Player"))
        {
            _isActive = true;
            Debug.Log("Activated by: " + other.gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("ActivationPlate") && other.gameObject.CompareTag("Player"))
        {
            _isActive = false;
            Debug.Log("Deactivated by: " + other.gameObject.name);
        }
    }
}
