using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player_InteractControls : MonoBehaviour
{
    [SerializeField] private Transform m_interactOriginTF;
    [SerializeField] private float m_interactRange;
    [SerializeField] private LayerMask m_interactLayer;

    private Transform m_currentInteractTF;
    private IInteractable m_currentInteractable;
    private Player_Stats m_playerStatsCS;

    private void Start()
    {
        m_playerStatsCS = GetComponent<Player_Stats>();
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
        Collider2D[] colliders = new Collider2D[10];
        int colliderCount =  Physics2D.OverlapCircleNonAlloc(m_interactOriginTF.position, m_interactRange, colliders,m_interactLayer);

        float closestDistance = Mathf.Infinity;

        for (int i = 0; i < colliderCount; i++)
        {
            float distance = Vector2.Distance(transform.position, colliders[i].transform.position);

            bool isColliderClosest = distance < closestDistance;

            if(!isColliderClosest) continue;
            closestDistance = distance;
            Transform nearestTF = colliders[i].transform;

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
        m_currentInteractable?.Interact(m_playerStatsCS);
    }

    private bool ObjectOutOfRange(Transform _objectToCheck)
    {
        float distance = Vector2.Distance(transform.position, _objectToCheck.position);

        bool isOutOfRange = distance > m_interactRange;

        if (isOutOfRange)
        {
            return true;
        }

        return false;
    }
}