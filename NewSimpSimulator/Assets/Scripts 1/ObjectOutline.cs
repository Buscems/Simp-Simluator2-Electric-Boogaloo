using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOutline : MonoBehaviour
{

    private MeshRenderer renderer;
    public float maxOutlineWidth;
    public Color outlineColor;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }

    public void ShowOutline()
    {
        renderer.material.SetFloat("_Outline", maxOutlineWidth);
        renderer.material.SetColor("_OultineColor", outlineColor);
    }

    public void HideOutline()
    {
        renderer.material.SetFloat("_Outline", 0f);
    }

}
