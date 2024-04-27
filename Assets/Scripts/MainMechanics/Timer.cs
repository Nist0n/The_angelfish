using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer instance;
    
    [SerializeField] GameObject victory;
    [SerializeField] GameObject loose;

    public float time;
    public bool start;
    public TextMeshProUGUI value;

    public List<GameObject> hideObject;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        hideObject.AddRange(GameObject.FindGameObjectsWithTag("HideObject"));
    }

    void Update()
    {
        if (start == true)
        {
            time -= Time.deltaTime;
            value.text = time.ToString("0.00");
        }
        if (time <= 0)
        {
            StopTimer();
        }
        if (hideObject.Count == 0)
        {
            victory.SetActive(true);
            StopTimer();
        }
        if ((time <= 0) && (hideObject.Count > 0))
        {
            loose.SetActive(true);
        }
    }

    public void StartTimer()
    {
        start = true;
    }

    public void PauseTimer()
    {
        start = false;
    }

    public void StopTimer()
    {
        start = false;
        time = 0;
        value.text = time.ToString("0.00");
    }
}
