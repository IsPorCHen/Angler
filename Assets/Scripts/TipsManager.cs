using System;
using TMPro;
using UnityEngine;

public class TipsManager : MonoBehaviour
{
    public static Action<string> DisplayTipEvent;
    public static Action DisableTipEvent;

    [SerializeField] private TMP_Text _messageText;

    private Animator _animation;
    private int _activeTips;

    private void Start()
    {
        _animation = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        DisplayTipEvent += DisplayTip;
        DisableTipEvent += DisableTip;
    }

    private void OnDisable()
    {
        DisplayTipEvent -= DisplayTip;
        DisableTipEvent -= DisableTip;
    }

    private void DisplayTip(string message)
    {
        _messageText.text = message;
        _animation.SetInteger("State", ++_activeTips);
    }

    private void DisableTip()
    {
        _animation.SetInteger("State", --_activeTips);
    }
}
