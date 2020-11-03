using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TwitchChat : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private string playerUsername;
    [SerializeField] private Color playerColor;

    [SerializeField] private TextMeshProUGUI twitchChat;
    [SerializeField] private TMP_InputField playerChat;

    [SerializeField] private TextAsset usernameMaster;
    [SerializeField] private TextAsset chatReplyMaster;

    private string[] usernames;
    private string[] chatReplies;

    [SerializeField] private Vector2 minMaxRandomChatSendTime;


    // Start is called before the first frame update
    void Start()
    {
        if (usernameMaster != null)
        {
            usernames = usernameMaster.text.Split('\n');

            for(int i = 0; i < usernames.Length; i++)
            {
                usernames[i] = usernames[i].Substring(0, usernames[i].Length - 1);
            }
        }

        if (chatReplyMaster != null)
        {
            chatReplies = chatReplyMaster.text.Split('\n');
        }

        StartCoroutine(SendNewMessage());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(playerChat.text != "")
            {
                twitchChat.text += "\n" + "<color=#" + ColorUtility.ToHtmlStringRGB(playerColor) + ">" + playerUsername + ": " + playerChat.text + "</color>";
                playerChat.text = "";
            }
        }
    }

    private IEnumerator SendNewMessage()
    {
        yield return new WaitForSeconds(Random.Range(minMaxRandomChatSendTime.x, minMaxRandomChatSendTime.y));
        twitchChat.text += "\n" + usernames[Random.Range(0, usernames.Length)].ToString() + ": " + chatReplies[Random.Range(0, chatReplies.Length)].ToString();
        StartCoroutine(SendNewMessage());
    }
}
