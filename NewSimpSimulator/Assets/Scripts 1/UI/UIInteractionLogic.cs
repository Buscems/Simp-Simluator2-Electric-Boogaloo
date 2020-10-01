using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteractionLogic : MonoBehaviour
{
    public void CloseApp(GameObject _mainApp)
    {
        _mainApp.SetActive(false);
    }
}
