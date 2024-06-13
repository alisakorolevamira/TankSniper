//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Sources/InputMap.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputMap: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMap()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMap"",
    ""maps"": [
        {
            ""name"": ""Touchscreen"",
            ""id"": ""07103ce4-1e93-4524-b47f-aac1653cb117"",
            ""actions"": [
                {
                    ""name"": ""TouchDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9993a9dd-4df2-44a5-ae4f-459675064a3e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""0c6045f1-11f5-40e6-adcb-aee23c877edd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""PassThrough"",
                    ""id"": ""4690e889-b9a3-410f-92f0-d0854bbeeb4b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c317725f-43fa-4831-bfd4-58f65b850d3e"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f3a8c6b-0a10-4104-8921-fdb36ecbff0f"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b06a23cd-2af9-45a7-8129-ccb6d030aed2"",
                    ""path"": ""<Touchscreen>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touchscreen
        m_Touchscreen = asset.FindActionMap("Touchscreen", throwIfNotFound: true);
        m_Touchscreen_TouchDelta = m_Touchscreen.FindAction("TouchDelta", throwIfNotFound: true);
        m_Touchscreen_TouchPress = m_Touchscreen.FindAction("TouchPress", throwIfNotFound: true);
        m_Touchscreen_TouchPosition = m_Touchscreen.FindAction("TouchPosition", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Touchscreen
    private readonly InputActionMap m_Touchscreen;
    private List<ITouchscreenActions> m_TouchscreenActionsCallbackInterfaces = new List<ITouchscreenActions>();
    private readonly InputAction m_Touchscreen_TouchDelta;
    private readonly InputAction m_Touchscreen_TouchPress;
    private readonly InputAction m_Touchscreen_TouchPosition;
    public struct TouchscreenActions
    {
        private @InputMap m_Wrapper;
        public TouchscreenActions(@InputMap wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchDelta => m_Wrapper.m_Touchscreen_TouchDelta;
        public InputAction @TouchPress => m_Wrapper.m_Touchscreen_TouchPress;
        public InputAction @TouchPosition => m_Wrapper.m_Touchscreen_TouchPosition;
        public InputActionMap Get() { return m_Wrapper.m_Touchscreen; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchscreenActions set) { return set.Get(); }
        public void AddCallbacks(ITouchscreenActions instance)
        {
            if (instance == null || m_Wrapper.m_TouchscreenActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_TouchscreenActionsCallbackInterfaces.Add(instance);
            @TouchDelta.started += instance.OnTouchDelta;
            @TouchDelta.performed += instance.OnTouchDelta;
            @TouchDelta.canceled += instance.OnTouchDelta;
            @TouchPress.started += instance.OnTouchPress;
            @TouchPress.performed += instance.OnTouchPress;
            @TouchPress.canceled += instance.OnTouchPress;
            @TouchPosition.started += instance.OnTouchPosition;
            @TouchPosition.performed += instance.OnTouchPosition;
            @TouchPosition.canceled += instance.OnTouchPosition;
        }

        private void UnregisterCallbacks(ITouchscreenActions instance)
        {
            @TouchDelta.started -= instance.OnTouchDelta;
            @TouchDelta.performed -= instance.OnTouchDelta;
            @TouchDelta.canceled -= instance.OnTouchDelta;
            @TouchPress.started -= instance.OnTouchPress;
            @TouchPress.performed -= instance.OnTouchPress;
            @TouchPress.canceled -= instance.OnTouchPress;
            @TouchPosition.started -= instance.OnTouchPosition;
            @TouchPosition.performed -= instance.OnTouchPosition;
            @TouchPosition.canceled -= instance.OnTouchPosition;
        }

        public void RemoveCallbacks(ITouchscreenActions instance)
        {
            if (m_Wrapper.m_TouchscreenActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ITouchscreenActions instance)
        {
            foreach (var item in m_Wrapper.m_TouchscreenActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_TouchscreenActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public TouchscreenActions @Touchscreen => new TouchscreenActions(this);
    public interface ITouchscreenActions
    {
        void OnTouchDelta(InputAction.CallbackContext context);
        void OnTouchPress(InputAction.CallbackContext context);
        void OnTouchPosition(InputAction.CallbackContext context);
    }
}