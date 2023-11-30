using JetBrains.Annotations;
using UnityEngine;

public class Player_InteractControls : MonoBehaviour
{
    [SerializeField] private Transform m_interactOriginTF;
    [SerializeField] private float m_interactRange;
    [SerializeField] private LayerMask m_interactLayer;

    [CanBeNull] private Transform m_currentInteractTF;
    [CanBeNull] private IInteractable m_currentInteractable;

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
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_interactOriginTF.position, m_interactRange, m_interactLayer);
        Debug.Log("colliders:: " + colliders);
       
        // save lowest distance object
        float _distance = m_interactRange;
        foreach (Collider2D col in colliders)
        {
            if(!col.TryGetComponent(out IInteractable interactable)) continue;

            if(m_currentInteractable == null)
            {
                SetInteractable(col.GetComponent<Transform>(),interactable);
            }
            else
            {

                // TODO: Check distances between interactables and set the closest one to be the interacted object
                float _currentDistance = Vector2.Distance (transform.position, m_currentInteractTF.position);
                if (_currentDistance < _distance)
                {
                    _distance = _currentDistance;
                    m_currentInteractable.Interact();
                }
            }
        }

        //TODO: Clear interact obj if it gets out of distance
    }

    private void SetInteractable(Transform _interactableTF, IInteractable _interactableI)
    {
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
}