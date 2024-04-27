using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    [SerializeField] GameObject victory;
    [SerializeField] GameObject loose;

    [Header("----------------------Timer---------------------")]
    public float time;
    public bool start;
    public TextMeshProUGUI value;

    [Header("----------------------Random Spawn---------------------")]
    public List<GameObject> spawnPoints;
    public GameObject[] prefabsVariations;


    [Header("----------------------Hide Objects---------------------")]
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
        if ((start == true ) && (hideObject.Count == 0))
        {
            victory.SetActive(true);
            StopTimer();
        }
        if ((time <= 0) && (hideObject.Count > 0))
        {
            loose.SetActive(true);
            StopTimer();
        }
    }

    public void SpawnHideObjects()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            Vector3 spawnElement = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)].transform.position;
            GameObject prefab = prefabsVariations[UnityEngine.Random.Range(0, prefabsVariations.Length)];
            GameObject clone = Instantiate(prefab, spawnElement, Quaternion.identity);
            hideObject.Add(clone);
            spawnPoints.RemoveAt(i);
        }
    }

    public void StartTimer()
    {
        start = true;
        SpawnHideObjects();
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
