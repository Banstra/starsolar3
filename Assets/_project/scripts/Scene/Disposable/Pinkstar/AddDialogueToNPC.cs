using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddDialogueToNPC : MonoBehaviour
{
    [SerializeField] NPC _npc;
    [SerializeField] TextAsset _inkFile;

    public void AddNewDialogueToNPC() => _npc.AddDialogue(_inkFile);
}
