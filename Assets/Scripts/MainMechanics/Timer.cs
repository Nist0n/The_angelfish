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
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject babkaButton;

    private BabkaEnterteiment _babka;
    [SerializeField] private BabkaChallenge _babkaCh;

    private bool _isGoing = false;

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
        _babka = FindObjectOfType<BabkaEnterteiment>();
    }

    void Update()
    {
        if (_isGoing)
        {
            time -= Time.deltaTime;
            value.text = time.ToString("0.00");
        }
        if ((start == true ) && (hideObject.Count == 0))
        {
            _babka.StartTimer();
            _babka.DecreaseTime();
            _babkaCh.ShowUI();
            _babkaCh.IsStarted = false;
            babkaButton.SetActive(false);
            spawnPoints.Clear();
            StopTimer();
        }
        if (time <= 0)
        {
            loose.SetActive(true);
            StopTimer();
        }
    }

    public void SpawnHideObjects()
    {
        start = true;

        foreach (var point in GameObject.FindGameObjectsWithTag("Spawnpoint"))
        {
            spawnPoints.Add(point);
        }
        
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            int rand = Random.Range(0, spawnPoints.Count);
            Vector3 spawnElement = spawnPoints[rand].transform.position;
            GameObject prefab = prefabsVariations[UnityEngine.Random.Range(0, prefabsVariations.Length)];
            GameObject clone = Instantiate(prefab, spawnElement, Quaternion.identity);
            hideObject.Add(clone);
            spawnPoints.RemoveAt(rand);
        }
    }

    public void StartTimer(float time)
    {
        this.time = time;
        _isGoing = true;
    }

    public void StopTimer()
    {
        start = false;
        _isGoing = false;
    }
}
