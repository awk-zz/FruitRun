using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAMfollowplayer : MonoBehaviour
{
    public Transform player; //玩家角色的Transform
    public Vector3 offset;  //摄像头与玩家的偏移量
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x,player.position.y + offset.y,offset.z);
    }
}
