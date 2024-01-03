using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // add or remove an interaction event
    public bool useEvents;
    [SerializeField]
    public string promptMessage;

    public virtual string OnLook()
    {
        return promptMessage;
    }
    public void BaseInteract()
    {
        if (useEvents)
            GetComponent<Interactionevent>().OnInInteract.Invoke();
        Interact();
    }
    protected virtual void Interact()
    {

    }
}
