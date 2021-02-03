using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SpeedBoost : MonoBehaviour
{
    public int pointWorth;
    private bool isCollected = false;
    public AudioClip pickupSound;
    public AudioSource pickupAudio;
    public int speedBoostAmt;
    void OnTriggerEnter(Collider other)
    {
        if (isCollected == false)
        {
            PlayAudio();
            Movement.speed += speedBoostAmt;
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
