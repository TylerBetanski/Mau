using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerInputController : MonoBehaviour
{
    private float _horizontalAxis;
    public float HorizontalAxis
    {
        get { return _horizontalAxis; }
        set { _horizontalAxis = value; }
    }

    private PlayerInputActions inputActions;
    private PlayerController controller;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        controller = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        inputActions.Locomotion.Enable();
        inputActions.Actions.Enable();
        inputActions.Locomotion.Movement.performed += ctx => _horizontalAxis = ctx.ReadValue<float>();
        inputActions.Locomotion.Jump.performed += ctx => controller.Jump();

        inputActions.Actions.Attack.performed += ctx => controller.Attack();
    }

    private void OnDisable()
    {
        inputActions.Locomotion.Disable();
        inputActions.Actions.Disable();
    }
}
