using UnityEngine;

public class Portal : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Debug.Log("interact with portal");
    }

    public void InteractGFXOn()
    {
        Debug.Log("interact portal GFX On");
    }

    public void InteractGFXOff()
    {
        Debug.Log("interact portal GFX Off");
    }

}
