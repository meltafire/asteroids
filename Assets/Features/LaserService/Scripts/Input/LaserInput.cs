//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Features/LaserService/Scripts/Input/LaserInput.inputactions
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

public partial class @LaserInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @LaserInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""LaserInput"",
    ""maps"": [
        {
            ""name"": ""Laser"",
            ""id"": ""d6f4a716-e134-4e01-9f48-d5b7640694fd"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""e415876d-c189-455e-aec1-30735a982242"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a0c162e3-1420-4902-9862-835a5f8a975e"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
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
        // Laser
        m_Laser = asset.FindActionMap("Laser", throwIfNotFound: true);
        m_Laser_Fire = m_Laser.FindAction("Fire", throwIfNotFound: true);
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

    // Laser
    private readonly InputActionMap m_Laser;
    private ILaserActions m_LaserActionsCallbackInterface;
    private readonly InputAction m_Laser_Fire;
    public struct LaserActions
    {
        private @LaserInput m_Wrapper;
        public LaserActions(@LaserInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_Laser_Fire;
        public InputActionMap Get() { return m_Wrapper.m_Laser; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LaserActions set) { return set.Get(); }
        public void SetCallbacks(ILaserActions instance)
        {
            if (m_Wrapper.m_LaserActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_LaserActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_LaserActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_LaserActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_LaserActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public LaserActions @Laser => new LaserActions(this);
    private int m_PCSchemeIndex = -1;
    public InputControlScheme PCScheme
    {
        get
        {
            if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
            return asset.controlSchemes[m_PCSchemeIndex];
        }
    }
    public interface ILaserActions
    {
        void OnFire(InputAction.CallbackContext context);
    }
}