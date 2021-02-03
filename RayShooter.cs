using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RayShooter : MonoBehaviour
{
    private Camera _camera;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public AudioSource mAudioSrc;

    public static float damage = 10f;
    public float range = 100f;

    void Start()
    {
        mAudioSrc = GetComponent<AudioSource>();
        _camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            muzzleFlash.Play();
            mAudioSrc.Play();
            Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            if(Physics.Raycast(ray, out hit))
            {
                GameObject hitObjec = hit.transform.gameObject;
                FinalBoss targe = hitObjec.GetComponent<FinalBoss>();
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                if (targe != null)
                {
                    targe.ReactToHit(damage);
                }
            }
            if (Physics.Raycast(ray, out hit))
                {
                    GameObject hitObject = hit.transform.gameObject;
                    ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                    Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    if (target != null)
                    {
                        target.ReactToHit(damage);
                    }
                }
        }
    }
    void OnGUI()
    {
        int size = 12;
        float posX = _camera.pixelWidth / 2 - size / 4;
        float posY = _camera.pixelHeight / 2 - size / 2;
        GUI.Label(new Rect(posX, posY, size, size), "0");
    }


}