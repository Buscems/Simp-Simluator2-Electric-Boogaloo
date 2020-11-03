using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using JetBrains.Annotations;

public class MessengerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI name;
    [SerializeField] private TextMeshProUGUI messageField;
    [SerializeField] private TMP_InputField playerChat;
    [SerializeField] private Color playerColor;

    [System.Serializable]
    public class Contacts 
    {
        [SerializeField] private string contactName;
        [SerializeField] private string messageLog;    
    }

    [SerializeField] private Contacts[] contacts;

    [SerializeField] private GameObject messageSender;

    public void OpenMessageLog(int _contactIndex)
    {
        messageSender.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SendMessage();
        }
    }

    public void SendMessage()
    {
        if (playerChat.text != "")
        {
            messageField.text += "\n\n" + "<margin-left=3em>" + "<align=right>" + " <color=#" + ColorUtility.ToHtmlStringRGB(playerColor) + ">" + playerChat.text + "</color>" + "</align>" + "</margin>";
            playerChat.text = "";
        }
    }

    public void BackButton()
    {
        messageSender.SetActive(false);
    }
}
