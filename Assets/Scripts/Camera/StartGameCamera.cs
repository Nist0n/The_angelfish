using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameCamera : MonoBehaviour
{
    [SerializeField] private GameObject point;
    [SerializeField] private GameObject gameUI;

    private void Update()
    {
        Vector3 newPos = Vector3.MoveTowards(transform.position, point.transform.position, 20 * Time.deltaTime);
        transform.position = newPos;

        if (Vector3.Distance(transform.position, point.transform.position) <= 2f)
        {
            gameUI.SetActive(true);
            gameObject.GetComponent<StartGameCamera>().enabled = false;
        }
    }
}
