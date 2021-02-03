using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CollectItem : MonoBehaviour
{
    public int pointWorth;
    private bool isCollected = false;
    public AudioClip pickupSound;
    public AudioSource pickupAudio;
    void OnTriggerEnter(Collider other)
    {
        if(isCollected == false) {
            PlayAudio();
            ScoreSystem.theScore += pointWorth;
            isCollected = true;
        }
        StartCoroutine(Die());
    }


    private IEnumerator Die()
    {
        yield return new WaitForSeconds(.9f);
        Destroy(this.gameObject);
    }

    private void PlayAudio()
    {
        pickupAudio = GetComponent<AudioSource>();
        pickupAudio.PlayOneShot(pickupSound, .6f);
    }
}


