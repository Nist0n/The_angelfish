using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class FishManager : MonoBehaviour
{
    [System.Serializable]
    public class Fishes
    {
        public List<GameObject> fishes;
    }
    
    [System.Serializable]
    public class FishesList
    {
        public List<Fishes> fishesList;
    }

    public FishesList listFishesList;
    public int Score = 0;
    public GameObject Wish;
    
    [SerializeField] private Button fishButton;
    [SerializeField] private GameObject canvas;

    private Fishing _fishing;
    private GameObject _currentFish;

    private void Start()
    {
        _fishing = FindObjectOfType<Fishing>();
    }

    public IEnumerator StartFishing()
    {
        Debug.Log("Started");
        int time = Random.Range(3, 6);
        yield return new WaitForSeconds(time);
        AudioManager.instance.PlaySFX("fish");
        int fish = Random.Range(0, 100);
        if (fish <= 49)
        {
            int randLoot = Random.Range(0, listFishesList.fishesList[0].fishes.Count);
            StartCoroutine(FishingGamePlay(listFishesList.fishesList[0].fishes[randLoot]));
        }
        else if (fish > 49 && fish <= 74)
        {
            int randLoot = Random.Range(0, listFishesList.fishesList[1].fishes.Count);
            StartCoroutine(FishingGamePlay(listFishesList.fishesList[1].fishes[randLoot]));
        }
        else if (fish > 74 && fish <= 94)
        {
            int randLoot = Random.Range(0, listFishesList.fishesList[2].fishes.Count);
            StartCoroutine(FishingGamePlay(listFishesList.fishesList[2].fishes[randLoot]));
        }
        else if (fish > 94 && fish <= 100)
        {
            int randLoot = Random.Range(0, listFishesList.fishesList[3].fishes.Count);
            StartCoroutine(FishingGamePlay(listFishesList.fishesList[3].fishes[randLoot]));
        }
    }

    IEnumerator FishingGamePlay(GameObject fish)
    {
        _currentFish = fish;
        Debug.Log("Catch");
        fishButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f);
        fishButton.gameObject.SetActive(false);

        if (!_fishing.isPulling)
        {
            AudioManager.instance.PlaySFX("fishOut");
            _fishing.GetOutRod();
        }
    }

    public void StartCatching()
    {
        _fishing.PullRod();
        Instantiate(_currentFish, canvas.transform);
        fishButton.gameObject.SetActive(false);
    }
}
