using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.InputSystem.Switch;
using UnityEngine.InputSystem.XInput;

public class InputSystemManager : MonoBehaviour
{
    public static InputSystemManager Instance { get; private set; }

    [SerializeField] private bool testInUpdateNames = false;
    public PlayerInput pInput;

    private void Awake()
    {
        Instance = this;
    }

    public void DeviceLost(PlayerInput _)
    {
        /// Saltar pantalla diciendo que presione cualquier boton de algun control
        Debug.LogWarning("<b>DeviceLost</b>");
    }

    public void ControlsChanged(PlayerInput playerInput)
    {
        Debug.LogWarning("<b>-- ControlsChanged to: --</b>");

        switch (playerInput.currentControlScheme)
        {
            case "Keyboard&Mouse":
                Debug.LogWarning("<b>Keyboard & Mouse</b>");
                break;

            case "Gamepad":
                Debug.LogWarning("<b>Gamepad:</b>");

                switch (playerInput.devices[0])
                {
                    case DualSenseGamepadHID:
                        Debug.LogWarning("<b>° PS5 - DualSenseGamepadHID °</b>");
                        break;

                    case DualShock4GamepadHID:
                        Debug.LogWarning("<b>° PS4 - DualShock4GamepadHID °</b>");
                        break;

                    case DualShock3GamepadHID:
                        Debug.LogWarning("<b>° PS3 - DualShock3GamepadHID °</b>");
                        break;

                    case DualShockGamepad:
                        Debug.LogWarning("<b>° PSx - DualShockGamepad °</b>");
                        break;

                    case SwitchProControllerHID:
                        // Falta por testear
                        Debug.LogWarning("<b>° Switch - Pro Controller °</b>");
                        break;

                    case XInputController:
                        Debug.LogWarning("<b>° Xbox Controller - XInputController °</b>");
                        break;

                    default:
                        Debug.LogWarning("<b>Gamepad no listado</b>");
                        Debug.LogWarning(playerInput.devices[0].name);
                        Debug.LogWarning(playerInput.devices[0].displayName);
                        break;
                }
                break;

            case "Joystick":
                Debug.LogWarning("<b>Joystick:</b>");
                Debug.LogWarning(playerInput.devices[0].displayName);
                /// Joysticks genericos, los botones seran numeros con colores en vez de las letras
                break;

            default:
                break;
        }
    }

    private void Update()
    {
        if (!testInUpdateNames)
            return;

        switch (pInput.currentControlScheme)
        {
            case "Keyboard&Mouse":
                if (Keyboard.current.anyKey.wasPressedThisFrame)
                {
                    for (int i = 0; i < Keyboard.current.allKeys.Count; i++)
                    {
                        if (Keyboard.current.allKeys[i].IsActuated())
                        {
                            Debug.LogWarning(Keyboard.current.allKeys[i].name);
                        }
                    }
                }
                //for (int i = 0; i < Mouse.current.allControls.Count; i++)
                //{
                //    if (Mouse.current.allControls[i].tr())
                //    {
                //        Debug.LogWarning(Mouse.current.allControls[i].displayName);
                //    }
                //}
                break;

            case "Gamepad":
                for (int i = 0; i < Gamepad.current.allControls.Count; i++)
                {
                    if (Gamepad.current.allControls[i].IsActuated())
                    {
                        Debug.LogWarning(Gamepad.current.allControls[i].name);
                    }
                }
                break;

            case "Joystick":
                for (int i = 0; i < Joystick.current.allControls.Count; i++)
                {
                    if (Joystick.current.allControls[i].IsActuated())
                    {
                        Debug.LogWarning(Joystick.current.allControls[i].name);
                    }
                }
                break;
        }
    }
}