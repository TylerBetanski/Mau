// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Locomotion"",
            ""id"": ""ace108f4-0788-427c-8082-99c384b1854f"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""146e866b-813b-4e08-bddd-ab636990f5b4"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""9234578d-cf89-44bc-be9c-dcf5dd267303"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""47759c3f-22b5-402b-bb63-30cb8235550f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""d9cb3325-6cfa-4e0e-a863-8c6fa8516101"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""38944a6a-a69d-401b-b77e-fc9519fdee88"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""e4b4c631-b2f3-4a85-ad9c-a48f9d772bf0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5069ef8f-2bca-4ca7-b489-07f4f7063191"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e4694635-b224-457c-adf6-7a7f1f749f59"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f1c9dbb5-4a02-4c32-a36b-68a66355ea94"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f27eacf-8777-41c6-84b6-a0185e719f3d"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Actions"",
            ""id"": ""28be8ceb-1f77-42d4-b817-c39e7a51f0e6"",
            ""actions"": [
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""e493c63a-616d-4389-a3d9-9aca3b519fa1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraZoom"",
                    ""type"": ""Button"",
                    ""id"": ""564e68c4-de3d-46b4-bc08-8956bca20ab3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Hiss"",
                    ""type"": ""Button"",
                    ""id"": ""5ed205de-ef7b-4da3-ae12-547f618a301b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""c0b95f06-205b-42ea-b528-763b017f2854"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Enter"",
                    ""type"": ""Button"",
                    ""id"": ""025c55d7-531b-4158-b9e9-cf63d4ade16f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reset"",
                    ""type"": ""Button"",
                    ""id"": ""29655d02-769b-4668-8991-467872d83a4d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e0bbb7bc-288a-4c7c-97d7-1f83b0ebf4b9"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d7b606e0-1b1b-427c-b1ee-96bbb3b59a70"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CameraZoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10f1a643-cdf8-4e49-9244-6383f18c9a87"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hiss"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7fa9f4bf-a9ad-4b8f-a486-cde475320f79"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2917f39c-04fb-4f52-8787-07c89d58174f"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Enter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""874b9210-95ba-4c3f-87e7-84527b8c6ae4"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reset"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Locomotion
        m_Locomotion = asset.FindActionMap("Locomotion", throwIfNotFound: true);
        m_Locomotion_Movement = m_Locomotion.FindAction("Movement", throwIfNotFound: true);
        m_Locomotion_Jump = m_Locomotion.FindAction("Jump", throwIfNotFound: true);
        // Actions
        m_Actions = asset.FindActionMap("Actions", throwIfNotFound: true);
        m_Actions_Attack = m_Actions.FindAction("Attack", throwIfNotFound: true);
        m_Actions_CameraZoom = m_Actions.FindAction("CameraZoom", throwIfNotFound: true);
        m_Actions_Hiss = m_Actions.FindAction("Hiss", throwIfNotFound: true);
        m_Actions_Pause = m_Actions.FindAction("Pause", throwIfNotFound: true);
        m_Actions_Enter = m_Actions.FindAction("Enter", throwIfNotFound: true);
        m_Actions_Reset = m_Actions.FindAction("Reset", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Locomotion
    private readonly InputActionMap m_Locomotion;
    private ILocomotionActions m_LocomotionActionsCallbackInterface;
    private readonly InputAction m_Locomotion_Movement;
    private readonly InputAction m_Locomotion_Jump;
    public struct LocomotionActions
    {
        private @PlayerInputActions m_Wrapper;
        public LocomotionActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Locomotion_Movement;
        public InputAction @Jump => m_Wrapper.m_Locomotion_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Locomotion; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LocomotionActions set) { return set.Get(); }
        public void SetCallbacks(ILocomotionActions instance)
        {
            if (m_Wrapper.m_LocomotionActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_LocomotionActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_LocomotionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public LocomotionActions @Locomotion => new LocomotionActions(this);

    // Actions
    private readonly InputActionMap m_Actions;
    private IActionsActions m_ActionsActionsCallbackInterface;
    private readonly InputAction m_Actions_Attack;
    private readonly InputAction m_Actions_CameraZoom;
    private readonly InputAction m_Actions_Hiss;
    private readonly InputAction m_Actions_Pause;
    private readonly InputAction m_Actions_Enter;
    private readonly InputAction m_Actions_Reset;
    public struct ActionsActions
    {
        private @PlayerInputActions m_Wrapper;
        public ActionsActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Attack => m_Wrapper.m_Actions_Attack;
        public InputAction @CameraZoom => m_Wrapper.m_Actions_CameraZoom;
        public InputAction @Hiss => m_Wrapper.m_Actions_Hiss;
        public InputAction @Pause => m_Wrapper.m_Actions_Pause;
        public InputAction @Enter => m_Wrapper.m_Actions_Enter;
        public InputAction @Reset => m_Wrapper.m_Actions_Reset;
        public InputActionMap Get() { return m_Wrapper.m_Actions; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ActionsActions set) { return set.Get(); }
        public void SetCallbacks(IActionsActions instance)
        {
            if (m_Wrapper.m_ActionsActionsCallbackInterface != null)
            {
                @Attack.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnAttack;
                @CameraZoom.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnCameraZoom;
                @CameraZoom.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnCameraZoom;
                @CameraZoom.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnCameraZoom;
                @Hiss.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnHiss;
                @Hiss.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnHiss;
                @Hiss.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnHiss;
                @Pause.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnPause;
                @Enter.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnEnter;
                @Enter.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnEnter;
                @Enter.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnEnter;
                @Reset.started -= m_Wrapper.m_ActionsActionsCallbackInterface.OnReset;
                @Reset.performed -= m_Wrapper.m_ActionsActionsCallbackInterface.OnReset;
                @Reset.canceled -= m_Wrapper.m_ActionsActionsCallbackInterface.OnReset;
            }
            m_Wrapper.m_ActionsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @CameraZoom.started += instance.OnCameraZoom;
                @CameraZoom.performed += instance.OnCameraZoom;
                @CameraZoom.canceled += instance.OnCameraZoom;
                @Hiss.started += instance.OnHiss;
                @Hiss.performed += instance.OnHiss;
                @Hiss.canceled += instance.OnHiss;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @Enter.started += instance.OnEnter;
                @Enter.performed += instance.OnEnter;
                @Enter.canceled += instance.OnEnter;
                @Reset.started += instance.OnReset;
                @Reset.performed += instance.OnReset;
                @Reset.canceled += instance.OnReset;
            }
        }
    }
    public ActionsActions @Actions => new ActionsActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface ILocomotionActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IActionsActions
    {
        void OnAttack(InputAction.CallbackContext context);
        void OnCameraZoom(InputAction.CallbackContext context);
        void OnHiss(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnEnter(InputAction.CallbackContext context);
        void OnReset(InputAction.CallbackContext context);
    }
}
