using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool isSmaller; // 如果是变小道具则为true，否则是变大
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

            if (playerMovement != null)
            {
                if (isSmaller)
                {
                    playerMovement.BecomeSmall();  // 直接调用变小方法
                }
                else
                {
                    playerMovement.BecomeBig();  // 直接调用变大方法
                }
            }
            Destroy(gameObject);
        }
    }
}
