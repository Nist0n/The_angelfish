using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Rendering;

public class HideObjects : MonoBehaviour
{
    [SerializeField] GameObject gameObject;

    public float duration;
    public Vector3 scale;
    public Color color;
    public Vector3 downScale;

    Timer _timer;

    public void OnMouseDown()
    {
        AudioManager.instance.PlaySFX("click");
        LeanTween.scale(gameObject, scale, duration);
        LeanTween.color(gameObject, color, duration).setOnComplete(HideObject);
    }

    public void HideObject()
    {
        LeanTween.scale(gameObject, downScale, duration).setOnComplete(DestroyObject);
    }

    public void DestroyObject()
    {
       if (gameObject.CompareTag("HideObject"))
        {
            Timer.instance.hideObject.Remove(gameObject);
        }
        Destroy(gameObject);
    }
}
