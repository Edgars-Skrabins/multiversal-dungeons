using UnityEngine;

public class Player_InteractControls : MonoBehaviour
{
    [SerializeField] private Transform m_interactOriginTF;
    [SerializeField] private float m_interactRange;
    [SerializeField] private LayerMask m_interactLayer;

    private float m_distanceBetweenPlayerAndInteractObj;
    private Transform m_currentInteractTF;
    private IInteractable m_currentInteractable;

    private void Start()
    {
        InitializeInputs();
    }

    private void InitializeInputs()
    {
        InputManager.I.OnInteractPerformed += Interact;
    }

    private void Update()
    {
        HandleInteract();
    }

    private void HandleInteract()
    {
        // TODO: Convert to non alloc version of OverlapCircleAll
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_interactOriginTF.position, m_interactRange, m_interactLayer);

        float closestDistance = Mathf.Infinity;
        Transform nearestTF = null;

        if (colliders.Length > 0)
        {
            foreach (Collider2D col in colliders)
            {
                float distance = Vector2.Distance(transform.position, col.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    nearestTF = col.transform;
                }
            }

            if (nearestTF.TryGetComponent(out IInteractable interactable))
            {
                SetInteractable(nearestTF, interactable);
            }
        }
        if(m_currentInteractTF && ObjectOutOfRange(m_currentInteractTF))
        {
            ClearInteractable();
        }
    }

    private void SetInteractable(Transform _interactableTF, IInteractable _interactableI)
    {
        if(m_currentInteractable != _interactableI) m_currentInteractable?.InteractGFXOff();

        m_currentInteractable?.InteractGFXOn();

        m_currentInteractTF = _interactableTF;
        m_currentInteractable = _interactableI;
    }

    private void ClearInteractable()
    {
        m_currentInteractable?.InteractGFXOff();

        m_currentInteractTF = null;
        m_currentInteractable = null;
    }

    private void Interact()
    {
        m_currentInteractable?.Interact();
    }

    private bool ObjectOutOfRange(Transform _objectToCheck)
    {
        float distance = Vector2.Distance(transform.position, _objectToCheck.position);
        if (distance > m_interactRange)
        {
            return true;
        }

        return false;
    }
}