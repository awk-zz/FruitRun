using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isSmaller; //如果是变小道具则为true 否则是变大
    public float smallerScale = 0.5f; //变小后比例
    public float biggerScale =2f; // 变大后比例
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Transform playerTransform = other.transform;
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
           
            if(isSmaller)
            {
                playerTransform.localScale = new Vector3(smallerScale,smallerScale,playerTransform.localScale.z);
                if(playerMovement !=null)
                {
                    playerMovement.BecomeSmall();
                }
            }
            else
            {
                playerTransform.localScale = new Vector3(biggerScale,biggerScale,playerTransform.localScale.z);
                if(playerMovement !=null)
                {
                    playerMovement.BecomeBig();
                }
            }
            Destroy(gameObject);
        }
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
