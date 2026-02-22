using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Zombie"))

            GameManager.instance.GameOver();


    }
}