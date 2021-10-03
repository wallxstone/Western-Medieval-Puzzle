using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
{
   public NavMeshAgent player;
   public Camera main;
   public Camera secondary;
   public float interactDistance = 5f;
   public float currDistance;
   public void Awake(){
       player = transform.GetComponent<NavMeshAgent>();
   }
   public void Update(){
       if(Input.GetMouseButtonDown(0))MovePlayer();
       if(Input.GetMouseButtonDown(1))InteractWithObject();
       
   }
   void MovePlayer(){
       RaycastHit moveTo;
       if(Physics.Raycast(main.ScreenPointToRay(Input.mousePosition),out moveTo,Mathf.Infinity)){
           player.SetDestination(moveTo.point);
          player.stoppingDistance = 2f;
       }
   }
    public void InteractWithObject(){
       RaycastHit hit;
       if(Physics.Raycast(main.ScreenPointToRay(Input.mousePosition),out hit,Mathf.Infinity)){
           //Interact with Object
           if(hit.transform.CompareTag("Interactable") && InteractDistanceCalculator(hit.transform.position, transform.position) <= interactDistance){

               if(hit.transform.GetComponent<CanonScript>() != null)
               {
                hit.transform.GetComponent<CanonScript>().Shoot();
               }
               else return;
           }
       }
    }

    float InteractDistanceCalculator(Vector3 a, Vector3 b){
        currDistance = Vector3.Distance(a,b);
        return currDistance;
    }

   
}
