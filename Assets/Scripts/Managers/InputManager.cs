
using MultiversalDungeons.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{

    private InputActions m_inputActions;
    private InputAction m_playerMovementInputAction;

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
        m_playerMovementInputAction = m_inputActions.Player.Movement;
        m_playerMovementInputAction.Enable();
    }

    private void InitializeInputEvents()
    {
        
    }

    public Vector3 GetWorldMousePosition()
    {
        Vector3 worldMousePosition = Utilities.GameCamera.ScreenToWorldPoint(Input.mousePosition);
        return worldMousePosition;
    }

    public Vector2 GetMovementVector2Normalized()
    {
        Vector2 movement = m_playerMovementInputAction.ReadValue<Vector2>();
        return movement;
    }
}
