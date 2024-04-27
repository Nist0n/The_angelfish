using System.Collections;
using UnityEngine;

public class Fishing : MonoBehaviour
{
    public bool isCasted;
    public bool isPulling;
 
    private Animator _animator;
    [SerializeField] private GameObject baitPrefab;
    [SerializeField] private GameObject startOfRope;
    [SerializeField] private Transform point;
    [SerializeField] private LineRenderer lr;

    private GameObject _poplavok;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isCasted)
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
        if (isCasted)
        {
            lr.SetPosition(1, point.position);
            lr.SetPosition(0, startOfRope.transform.position);
        }
    }

    public IEnumerator CastRod()
    {
        
        //animator.SetTrigger("Cast");
        
        yield return new WaitForSeconds(0.5f);
 
        _poplavok = Instantiate(baitPrefab, point.position, Quaternion.identity, point);

        lr.positionCount = 2;
        isCasted = true;
    }
    
    public void PullRod()
    {
        //animator.SetTrigger("Pull");
        isCasted = false;
        isPulling = true;
    }

    public void GetOutRod()
    {
        isPulling = false;
        lr.positionCount = 0;
        Destroy(_poplavok);
    }
}
