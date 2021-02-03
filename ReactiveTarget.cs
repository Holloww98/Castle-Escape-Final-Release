using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public GameObject player;
    public float hpRestore = 1;
    public float health = 50f;
    public GameObject sourceDropCommon;//enemy drops
    public GameObject sourceDropUncommon;//enemy drops
    public GameObject sourceDropRare;//enemy drops
    private GameObject realDrop;
    private GameObject drop = null;
    private float rarityChance;
    private string rarity;
    public AudioClip damageSound;
    public AudioSource audio;
    private bool isKilled = false;

    public GameObject[] spawnees;
    int randomInt;

    public void ReactToHit(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {


            StartCoroutine(Die());

        }

    }
    private IEnumerator Die()
    {
        if (isKilled == false)
        {
            SpawnRandom();
            AudioSource audio = GetComponent<AudioSource>();
            if (audio == null)
            {
                audio = player.AddComponent<AudioSource>();
            }
            audio.PlayOneShot(damageSound, 1);
            isKilled = true;
        }

        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(1.5f);
        player.GetComponent<Health>().healDamage(hpRestore);
        Destroy(this.gameObject);
    }

 
    void SpawnRandom()
    {
        randomInt = Random.Range(0, spawnees.Length);
        Instantiate(spawnees[randomInt], transform.position, transform.rotation);
    }




}


