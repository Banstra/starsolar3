using UnityEngine;

public class dialogManager : MonoBehaviour
{ /*
    public Image actorImage;
    public Text actorName;
    public Text messageText;
    public RectTransform backgroundBox;
    public static bool isActive = false;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    [SerializeField] Image DialogueBox;
    public void OpenDialog(Message[] messages, Actor[] actors)
    {
        currentActors = actors;
        currentMessages = messages;
        activeMessage = 0;
        isActive = true;
        Debug.Log("Loaded messages:" + messages.Length);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f).setEaseInOutExpo();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;
        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Convo is over");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
        }
    }
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isActive == true)
        {
            NextMessage();
        }
    }
    */

}
