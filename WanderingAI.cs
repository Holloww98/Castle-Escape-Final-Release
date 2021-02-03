using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 1.5f;
    public float obstacleRange = 3.0f;
    private bool alive;
    public float damage = -5f;
    public GameObject player;
    public GameObject enemy;

    private void Start()
    {
        //alive() = true;
    }
    void Update()
    {
        var distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 100) { 
            transform.Translate(0, 0, speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                if (hit.distance < obstacleRange)
                {
                    GameObject hitObject = hit.transform.gameObject;
                    Health target = hitObject.GetComponent<Health>();
                    if (hitObject == player)
                    {
                        target.takeDamage(damage);
                    }
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
        }
    }
}


}