using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController : MonoBehaviour
{
    private float currentTime = 0;

    // Update is called once per frame
    void Update()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
    }

    public bool CanBeInteractedWith()
    {
        if (currentTime > 0)
        {
            return false;
        }
        else
        {
            currentTime = 1;
            return true;
        }
    }
}
