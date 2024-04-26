using UnityEngine;

public class LeanTweenMain : MonoBehaviour
{
    [SerializeField] LeanTweenType easeType;

    public float duration;
    public float cornerValue;
    public float originalCornerValue;

    public void Rotate()
    {
        LeanTween.rotateZ(gameObject, cornerValue, duration).setEase(easeType).setOnComplete(RotateBack);
    }

    private void RotateBack()
    {
        LeanTween.rotateZ(gameObject, originalCornerValue, 1).setDelay(1);
    }
}
