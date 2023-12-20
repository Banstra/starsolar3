using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : KDTimer
{
    [SerializeField] private List<TextAsset> _dialogue;
    [SerializeField] private UnityEvent[] _endDialogueEvents;
    private int _needDialogueIndex = 0;

    private bool _isUsed;

    private void Start() =>
        InkTestingScript.Instance.EndDialogue.AddListener(CloseDialogue);

    public void Interact()
    {
        if (_isUsed || !_isReady) return;

        if (_needDialogueIndex >= _dialogue.Count)
            _needDialogueIndex = _dialogue.Count - 1;

        Interactor.Instance.StartDialogue(_dialogue[_needDialogueIndex]);
        _isUsed = true;
    }

    public void CloseDialogue()
    {
        _isUsed = false;
        if (_endDialogueEvents.Length > _needDialogueIndex)
            _endDialogueEvents[_needDialogueIndex].Invoke();
        _needDialogueIndex++;
        StartCoroutine(CheckKD());
    }

    public void AddDialogue(TextAsset dialogue) => _dialogue.Add(dialogue);
}
