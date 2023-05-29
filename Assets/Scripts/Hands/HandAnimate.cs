using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class HandAnimate : MonoBehaviour
{
    [SerializeField] private InputActionProperty _pinchAction;
    [SerializeField] private InputActionProperty _gripAction;
    private Animator _handAnimator = null;

    private void Init()
    {
        _handAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        AnimateHand(_pinchAction, "Trigger");
        AnimateHand(_gripAction, "Grip");
    }

    private void AnimateHand(InputActionProperty actionProperty, string animationName)
    {
        float value = actionProperty.action.ReadValue<float>();
        _handAnimator.SetFloat(animationName, value);
    }
}
