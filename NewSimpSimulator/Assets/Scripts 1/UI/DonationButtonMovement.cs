using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonationButtonMovement : MonoBehaviour
{
    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SpreadOut(bool _spreadIn)
    {
        if (_spreadIn)
        {
            anim.SetTrigger("Forward");
        }
        else
        {
            anim.SetTrigger("Back");
        }
    }

}
