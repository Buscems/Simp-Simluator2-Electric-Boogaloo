using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppController : MonoBehaviour
{
    [System.Serializable]
    public class Tabs
    {
        [SerializeField] private string tabName;
        [SerializeField] private string messageLog;
    }

    [SerializeField] private Tabs[] contacts;

    [SerializeField] private GameObject tabToOpen;

    [Header ("For Bank")]
    [SerializeField] private bool isBank;
    [SerializeField] private Scrollbar scrollbar;

    public void OpenTab()
    {
        tabToOpen.SetActive(true);

        if (isBank)
        {
            scrollbar.value = 1;
        }
    }

    public void BackButton()
    {
        tabToOpen.SetActive(false);
    }
}
