using UnityEngine;
using UnityEngine.Rendering;

public class MainMechanics : MonoBehaviour
{
    [SerializeField] GameObject gameObjectL;

    public float duration;
    public Vector3 scale;
    public Color color;
    public Vector3 downScale;

    Timer _timer;

    public void OnMouseDown()
    {
        AudioManager.instance.PlaySFX("click");
        LeanTween.scale(gameObjectL, scale, duration);
        LeanTween.color(gameObjectL, color, duration).setOnComplete(HideObject);
    }

    public void HideObject()
    {
        LeanTween.scale(gameObjectL, downScale, duration).setOnComplete(DestroyObject);
    }

    public void DestroyObject()
    {
       if (gameObjectL.CompareTag("HideObject"))
       {
            Timer.instance.hideObject.Remove(gameObjectL);
       }
       Destroy(gameObjectL);
    }
}
