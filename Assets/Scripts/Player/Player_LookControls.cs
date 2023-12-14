using UnityEngine;

public class Player_LookControls : MonoBehaviour
{
    [SerializeField] private Transform m_virtualCameraTF;
    [SerializeField] private Transform m_mainCameraTF;
    [SerializeField] private Transform m_cameraTargetTF;
    [SerializeField] private float m_threshold;

    private void Awake()
    {
        UnparentCamerasAndTarget();
    }

    private void UnparentCamerasAndTarget()
    {
        m_virtualCameraTF.SetParent(null);
        m_mainCameraTF.SetParent(null);
    }

    private void Update()
    {
        MoveCameraTarget();
    }

    private void MoveCameraTarget()
    {
        Vector3 mousePos = InputManager.I.GetWorldMousePosition();
        Vector3 targetPosition = (transform.position + mousePos) / 2;

        targetPosition.x = Mathf.Clamp(targetPosition.x, -m_threshold + transform.position.x, m_threshold + transform.position.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, -m_threshold + transform.position.y, m_threshold + transform.position.y);

        m_cameraTargetTF.position = targetPosition;
    }
}