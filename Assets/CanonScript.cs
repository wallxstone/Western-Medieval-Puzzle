using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonScript : MonoBehaviour
{
    public Transform barrel;
    public GameObject canonBall;
    public float shotTime = 3f;
    public bool isShooting;
    public AudioSource shotCanon;
    public AudioClip onShoot;
    public Camera main;
    public Camera secondary;
    void Awake(){
        isShooting = false;
    }
    public void Shoot(){
        StartCoroutine(StartCanon());
       StopCoroutine(StartCanon());
    }

    IEnumerator StartCanon(){
        yield return new WaitForSeconds(shotTime);
        shotCanon.PlayOneShot(onShoot);
         Instantiate(canonBall,barrel.position,transform.rotation);
         StartCoroutine(ChangeCamera());
         isShooting = false;
    }
     IEnumerator ChangeCamera(){
        main.enabled = false;
        secondary.enabled = true;
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        yield return new WaitForSeconds(3f);
         main.enabled = true;
        secondary.enabled = false;
        Time.timeScale = 1;
        Time.fixedDeltaTime =  0.02f;
    }
}
