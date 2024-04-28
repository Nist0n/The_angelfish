using System;
using System.Collections;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [SerializeField] private GameObject baitPrefab;
    [SerializeField] private GameObject startOfRope;
    [SerializeField] private Transform point;
    [SerializeField] private LineRenderer lr;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject catchButton;
    
    public bool isCasted;
    public bool isPulling;

    private bool isCatching;
    
    private GameObject _poplavok;
    private FishManager _fishManager;

    private void Start()
    {
        _fishManager = FindObjectOfType<FishManager>();
    }

    void Update()
    {
    }
    
    private void LateUpdate()
    {
        if (isCasted && isCatching)
        {
            lr.SetPosition(1, point.position);
            lr.SetPosition(0, startOfRope.transform.position);
        }
    }

    public void CastRod()
    {
        if (!isCatching)
        {
            AudioManager.instance.PlaySFX("throw");
            catchButton.SetActive(false);
            isCatching = true;
            _poplavok = Instantiate(baitPrefab, point.position, Quaternion.identity, point);
            lr.positionCount = 2;
            isCasted = true;
            animator.SetTrigger("startCatch");
            AudioManager.instance.PlaySFX("fish");
            StartCoroutine(_fishManager.StartFishing());
        }
    }
    
    public void PullRod()
    {
        //animator.SetTrigger("Pull");
        isPulling = true;
    }

    public void GetOutRod()
    {
        isPulling = false;
        isCatching = false;
        isCasted = false;
        lr.positionCount = 0;
        Destroy(_poplavok);
        catchButton.SetActive(true);
        animator.SetTrigger("isStaying");
    }
}
