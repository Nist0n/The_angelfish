using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishManager : MonoBehaviour
{
    [SerializeField] private List<GameObject[]> fishes;
    [SerializeField] private Button fishButton;

    public IEnumerator StartFishing()
    {
        int time = Random.Range(3, 6);
        yield return new WaitForSeconds(time);
        //anim
        int fish = Random.Range(0, 100);
        if (fish <= 49)
        {
            int randLoot = Random.Range(0, fishes[0].Length - 1);
            FishingGamePlay(fishes[0][randLoot]);
        }
        else if (fish > 49 && fish <= 74)
        {
            int randLoot = Random.Range(0, fishes[1].Length - 1);
            FishingGamePlay(fishes[1][randLoot]);
        }
        else if (fish > 74 && fish <= 94)
        {
            int randLoot = Random.Range(0, fishes[2].Length - 1);
            FishingGamePlay(fishes[2][randLoot]);
        }
        else if (fish > 94 && fish <= 100)
        {
            int randLoot = Random.Range(0, fishes[1].Length - 1);
            FishingGamePlay(fishes[3][randLoot]);
        }
        //setactive Button
        yield return new WaitForSeconds(2f);
        //deactive butt
    }

    public void FishingGamePlay(GameObject fish)
    {
        //anim
        
    }
}
