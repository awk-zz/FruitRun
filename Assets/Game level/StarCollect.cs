using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollect : MonoBehaviour
{
    public bool isCorruptStar = false; //标记为腐蚀星星
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerMovement player=other.GetComponent<PlayerMovement>();
            if(player!= null)
            {
                if(isCorruptStar)
                {
                    player.TakeDamage(); //腐蚀伤害
                }
                else
                {
                    player.AddStar(); //增加分数
                }
            }
        }
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
