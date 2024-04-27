using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChooseAWish : MonoBehaviour
{
    [SerializeField] GameObject firstOption;
    [SerializeField] GameObject secondOption;
    [SerializeField] GameObject thirdOption;

    public List<string> good;
    public List<string> bad;

    public void CreateAWish()
    {
        firstOption.GetComponent<TMP_Text>().text = good[UnityEngine.Random.Range(0, good.Count)];
        secondOption.GetComponent<TMP_Text>().text = bad[UnityEngine.Random.Range(0, bad.Count)];
        thirdOption.GetComponent<TMP_Text>().text = bad[UnityEngine.Random.Range(0, bad.Count)];
    }
}
