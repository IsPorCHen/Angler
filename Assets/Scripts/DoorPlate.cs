using UnityEngine;

public class DoorPlate : MonoBehaviour
{
    [SerializeField] private PlateActivation panel1;
    [SerializeField] private PlateActivation panel2;
    private bool isOpen = false;

    private void Update()
    {
        if (panel1 != null && panel2 != null)
        {
            if (panel1.GetActive && panel2.GetActive && !isOpen)
            {
                OpenDoor();
            }
        }
        else
        {
            Debug.LogError("Panel references are not set in the Inspector");
        }
    }

    private void OpenDoor()
    {
        Debug.Log("Door is opening");
        gameObject.SetActive(false);
        isOpen = true;
    }
}
