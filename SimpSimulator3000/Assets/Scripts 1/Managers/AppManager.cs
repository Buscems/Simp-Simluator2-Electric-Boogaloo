using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    [SerializeField] private GameObject[] apps; 


    public void BackButton()
    {
        foreach(GameObject g in apps)
        {
            g.SetActive(false);
        }
    }
}
