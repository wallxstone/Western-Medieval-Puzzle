using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public Transform player;
    public Transform endPoint;

    public float distance;
    public TextMeshProUGUI obj;
    void Update(){
        if(CalculateDistance(player.position,endPoint.position) <= 0){
        obj.text = "Game has ended, congratulations on reaching the end";
        obj.color = new Color(255,0,0);
        }
    }
    float CalculateDistance(Vector3 a,Vector3 b){
        a = player.position;
        b = endPoint.position;

        distance = Vector3.Distance(a,b);
        return distance;
    }
}
