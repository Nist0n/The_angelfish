using System;
using System.Collections;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    [SerializeField] private GameObject baitPrefab;
    [SerializeField] private GameObject startOfRope;
    [SerializeField] private Transform point;
    [SerializeField] private LineRenderer lr;
    
    public bool isCasted;
    public bool isPulling;

    private bool isCatching;
 
    private Animator _animator;
    private GameObject _poplavok;
    private FishManager _fishManager;

    private void Start()
    {
        _fishManager = FindObjectOfType<FishManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isCatching)
        {
            StartCoroutine(CastRod());
        }
        
        if (isCasted && Input.GetMouseButtonDown(1))
        {
            GetOutRod();
        }
    }
    
    private void LateUpdate()
    {
        if (isCasted && isCatching)
        {
            lr.SetPosition(1, point.position);
            lr.SetPosition(0, startOfRope.transform.position);
        }
    }

    public IEnumerator CastRod()
    {
        //animator.SetTrigger("Cast");
        isCatching = true;

        yield return new WaitForSeconds(0.5f);
 
        _poplavok = Instantiate(baitPrefab, point.position, Quaternion.identity, point);

        lr.positionCount = 2;
        isCasted = true;

        StartCoroutine(_fishManager.StartFishing());
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
    }
}
