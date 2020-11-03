using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenApp : MonoBehaviour
{
    [SerializeField] private Image appButton;
    [SerializeField] private Color clickedColor;
    [SerializeField] private Color highlightColor;

    [SerializeField] private float idleTime;

    private float currentIdleTime = 0;
    private bool highlight = false;

    [SerializeField] private GameObject appToOpen;

    [SerializeField] private bool isMobileDevice;

    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        if (isMobileDevice)
        {
            originalColor = appButton.color;
            return;
        }

        appButton.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        currentIdleTime -= Time.deltaTime;

        if (currentIdleTime < 0 && highlight == false)
        {
            if (isMobileDevice)
            {
                appButton.color = originalColor;
                return;
            }             

            appButton.color = new Color(0, 0, 0, 0);
        }
       
    }

    public void OnHighlight()
    {
        highlight = true;
        appButton.color = highlightColor;
    }

    public void OnHighlightExit()
    {
        highlight = false;
    }

    public void OnClick()
    {
        if(currentIdleTime < 0)
        {
            currentIdleTime = idleTime;
            appButton.color = clickedColor;
            return;
        }

        if (appToOpen.activeSelf == false)
        {
            currentIdleTime = 0;
            appButton.color = new Color(0, 0, 0, 0);
            appToOpen.SetActive(true);
        }
    }
}
