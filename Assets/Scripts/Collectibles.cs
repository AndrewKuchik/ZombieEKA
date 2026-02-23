using System;
using UnityEngine;
using TMPro;
public class Collectibles : MonoBehaviour
{
   public float speed = 100f;
 
   public AudioClip collectSound;
   public int points = 1;
   private void Update()
   {
      transform.Rotate(Vector3.up * Time.deltaTime * speed);
   }

   void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Zombie")) ;
      {
         SoundManager.instance.PlaySound(collectSound, transform.position);
         GameManager.instance.AddScore(points);
         Destroy(gameObject);
      }
   }

}
