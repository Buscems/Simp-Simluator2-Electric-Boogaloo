using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObjectsOnOff : MonoBehaviour
{
    [SerializeField] private GameObject[] _turnItemsOn;
    [SerializeField] private GameObject[] _turnItemsOff;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _turnItemsOn.Length; i++)
        {
            _turnItemsOn[i].SetActive(true);
        }


        for (int i = 0; i < _turnItemsOff.Length; i++)
        {
            _turnItemsOff[i].SetActive(false);
        }

    }

}
