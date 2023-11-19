using MultiversalDungeons.Utilities;
using Unity.Plastic.Newtonsoft.Json.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    public event Action OnShootPerformed;

    private InputActions m_inputActions;
    private InputAction m_playerMovementIA;
    private InputAction m_playerShootIA;

    protected override void Awake()
    {
        base.Awake();
        InitializeInputActions();
        InitializeInputEvents();
        HideMouse();
    }

    public void HideMouse()
    {
        Cursor.visible = false;
    }

    public void ShowMouse()
    {
        Cursor.visible = true;
    }

    private void InitializeInputActions()
    {
        m_inputActions = new InputActions();

        m_playerMovementIA = m_inputActions.Player.Movement;
        m_playerMovementIA.Enable();

        m_playerShootIA = m_inputActions.Player.Shoot;
        m_playerShootIA.Enable();
    }

    private void InitializeInputEvents()
    {
        m_playerShootIA.performed += Interact_Action;
    }

    private void Interact_Action(InputAction.CallbackContext _inputObj)
    {
        switch(_inputObj.phase)
        {
            case InputActionPhase.Performed:
                OnShootPerformed?.Invoke();
                break;
            default: return;
        }
    }

    public Vector3 GetWorldMousePosition()
    {
        Vector3 worldMousePosition = Utilities.GameCamera.ScreenToWorldPoint(Input.mousePosition);
        return worldMousePosition;
    }

    public Vector2 GetMovementVector2Normalized()
    {
        Vector2 movement = m_playerMovementIA.ReadValue<Vector2>();
        return movement;
    }
}