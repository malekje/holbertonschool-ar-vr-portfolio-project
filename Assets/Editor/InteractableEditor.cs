using UnityEditor;

[CustomEditor(typeof(Interactable),true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target;
        if(target.GetType() == typeof(EventOnlyInteractable))
        {
            interactable.promptMessage = EditorGUILayout.TextField("Prompt Message", interactable.promptMessage);
            EditorGUILayout.HelpBox("EventOnlyInteract can ONLY use UnityEvents.", MessageType.Info);
            if(interactable.GetComponent<Interactionevent>() == null)
            {
                interactable.useEvents = true;
            }
        }
        base.OnInspectorGUI();
        if (interactable.useEvents)
        {
            if (interactable.GetComponent<Interactionevent>() == null)
                interactable.gameObject.AddComponent<Interactionevent>();
        }
        else
        //
        if (interactable.GetComponent<Interactionevent>() != null)
            DestroyImmediate(interactable.GetComponent<Interactionevent>());

    }
}
