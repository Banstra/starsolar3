using UnityEngine;

public class Interactor : MonoBehaviour
{
    public static Interactor Instance { get; private set; }

    [SerializeField] private PlayerMovement _movement;
    [SerializeField] InkTestingScript _ink;
    public bool IsDealing { get; private set; } = false;
    private void Start()
    {
        Instance = this;
        _ink.EndDialogue.AddListener(CloseDialogueMenu);
    }

    public void StartDialogue(TextAsset dialogue)
    {
        InkTestingScript.Instance.SetDialogue(dialogue);
        IsDealing = true;
        _movement.enabled = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    private void CloseDialogueMenu()
    {
        IsDealing = false;
        _movement.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}

