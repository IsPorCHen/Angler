using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressKeyTrigger : MonoBehaviour
{
    [Header("����� ���������")]
    [TextArea(3, 10)]
    [SerializeField] private string message;

    [Header("����� ������")]
    [TextArea(3, 10)]
    [SerializeField] private string _keyMessage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PressKeyManager.DisplayKeyEvent?.Invoke(message, _keyMessage);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PressKeyManager.DisableKeyEvent?.Invoke();
        }
    }
}
