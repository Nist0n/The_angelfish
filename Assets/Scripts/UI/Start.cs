using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject game;
    private void Start()
    {
        StartCoroutine(FadeOut());
    }

    private void Update()
    {
        game.SetActive(false);
    }

    IEnumerator FadeOut()
    {
        AudioManager.instance.PlayMusic("NACHALO");
        yield return new WaitForSeconds(10f);
        gameObject.GetComponent<Animator>().SetTrigger("fadeOut");
        yield return new WaitForSeconds(4f);
        game.SetActive(true);
        AudioManager.instance.PlayMusic("inGameMusic");
        Destroy(gameObject);
    }
}
