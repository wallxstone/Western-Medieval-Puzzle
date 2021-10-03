using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanonBallScript : MonoBehaviour
{
   public Rigidbody rb;
    public float canonBallDuration = 2f;
    public AudioSource explosion;
    public AudioClip explode;

 
    public void OnEnable(){
        rb = this.GetComponent<Rigidbody>();
    }

    
    void Update(){
        rb.AddForce(Vector3.forward * 2,ForceMode.Impulse);
        canonBallDuration -= Time.deltaTime;
        if(canonBallDuration <= 0) Destroy(this.gameObject);
        //Play Explosion
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Walls")){
            explosion.PlayOneShot(explode);
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        } else {
            if(other.gameObject.CompareTag("Player")) Destroy(other.gameObject);
        }
    }
    
}
