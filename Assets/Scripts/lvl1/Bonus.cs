using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            SnakeAteBonus();
        }
    }

       private void SnakeAteBonus()
    {
        gameObject.SetActive(false);
               
        StartCoroutine(RespawnBonus());
    }

    private System.Collections.IEnumerator RespawnBonus()
    {
     yield return new WaitForSeconds(5f);

     gameObject.SetActive(true);

   
    }

}



