using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatNIg : MonoBehaviour
{
    [SerializeField] private GameObject goldFish;
    [SerializeField] private GameObject canvas;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            Instantiate(goldFish, canvas.transform);
        }
    }
}
