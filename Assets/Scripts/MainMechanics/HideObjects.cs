using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class HideObjects : MonoBehaviour
{
    public float duration;
    public Vector3 scale;
    public Color color;
    public Vector3 downScale;


    public void OnMouseDown()
    {
        LeanTween.scale(gameObject, scale, duration);
        LeanTween.color(gameObject, color, duration).setOnComplete(HideObject);
    }

    public void HideObject()
    {
        LeanTween.scale(gameObject, downScale, duration);
        gameObject.IsDestroyed();
    }

}
