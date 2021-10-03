using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
   public Transform player;
   public Vector3 offset;
   public Vector3 moveCamVec;

   public void Awake(){
       offset = new Vector3(0,10,0);
   }
   public void Update(){
       transform.position = (player.position + offset);
       MoveCamera();
   }

   public void MoveCamera(){
       if(Input.GetKey(KeyCode.W)) moveCamVec = new Vector3 (1,0,0);
       if(Input.GetKey(KeyCode.S)) moveCamVec = new Vector3 (-1,0,0);
       if(Input.GetKey(KeyCode.A)) moveCamVec = new Vector3 (0,0,1);
       if(Input.GetKey(KeyCode.D)) moveCamVec = new Vector3 (0,0,-1);

   }
}
