using TMPro;
using UnityEngine;

public class InteractionPointUI : MonoBehaviour
{
    [SerializeField] private GameObject UIpanel;

    private void Start() =>
        UIpanel.SetActive(false);

    public void StartDialogue() =>
        UIpanel.SetActive(true);

    public void Close() =>
        UIpanel.SetActive(false);
}
