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
    private CameraZoom cameraZoom;
    SnyderMode snyderMode;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        controller = GetComponent<PlayerController>();
        cameraZoom = GetComponent<CameraZoom>();
        snyderMode = GetComponent<SnyderMode>(); 
    }

    private void OnEnable()
    {
        inputActions.Locomotion.Enable();
        inputActions.Actions.Enable();
        inputActions.Locomotion.Movement.performed += ctx => _horizontalAxis = ctx.ReadValue<float>();
        inputActions.Locomotion.Jump.performed += ctx => controller.Jump();
        inputActions.Actions.Attack.performed += ctx => controller.Attack();
        inputActions.Actions.Hiss.performed += ctx => controller.Hiss();
        inputActions.Actions.Pause.performed += ctx => controller.Pause();
        inputActions.Actions.CameraZoom.performed += ctx => cameraZoom.changeZoom();
        inputActions.Actions.Enter.performed += ctx => controller.advanceDialog();
        inputActions.Actions.Reset.performed += ctx => FindObjectOfType<CheckpointManager>().ReloadWorld(gameObject);
        inputActions.Actions.SnyderMode.performed += ctx => controller.ToggleSnyderMode();
    }

    private void OnDisable()
    {
        inputActions.Locomotion.Disable();
        inputActions.Actions.Disable();
    }
}
