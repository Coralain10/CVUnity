using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveArray : MonoBehaviour
{
    public Live[] lives;
    [SerializeField] public bool lostAllLives {get; private set;}
    int lastLiveIdx;

    void Awake()
    {
        lostAllLives = false;
        lastLiveIdx = lives.Length-1;
        // lives = new Live[] {new Live(), new Live(), new Live()};
    }

    public void SetDamage() 
    {
        if (lives[lastLiveIdx].health > 0)
        {
            lives[lastLiveIdx].SetDamage();
        }
        else
        {
            lastLiveIdx--;
        }
        if (lastLiveIdx < 0) lostAllLives = true;
    }

    public void Recover() //IEnumerator
    {
        while (lastLiveIdx < lives.Length-1 && !lostAllLives)
        {
            // float timeToRecover = lives[lastLiveIdx].getTimeToRecover();
            StartCoroutine( lives[lastLiveIdx].Recover() );
            // yield return new WaitForSeconds( timeToRecover );
            lastLiveIdx++;
        }
    }

    public void FillAll()
    {
        lostAllLives = false;
        lastLiveIdx = lives.Length-1;
        foreach(Live live in lives) live.ToFull();
    }
}
