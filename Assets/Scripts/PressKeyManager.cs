using System;
using TMPro;
using UnityEngine;

public class PressKeyManager : MonoBehaviour
{
    public static Action<string, string> DisplayKeyEvent;
    public static Action DisableKeyEvent;

    [SerializeField] private TMP_Text _messageText;
    [SerializeField] private TMP_Text _messageKey;

    private Animator _animation;
    private int _activeKeys;

    private void Start()
    {
        _animation = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        DisplayKeyEvent += DisplayKey;
        DisableKeyEvent += DisableKey;
    }

    private void OnDisable()
    {
        DisplayKeyEvent -= DisplayKey;
        DisableKeyEvent -= DisableKey;
    }

    private void DisplayKey(string message, string keyMessage)
    {
        _messageText.text = message;
        _messageKey.text = keyMessage;
        _animation.SetInteger("State", ++_activeKeys);
    }

    private void DisableKey()
    {
        _animation.SetInteger("State", --_activeKeys);
    }
}
