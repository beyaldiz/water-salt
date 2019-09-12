using UnityEngine;

public class Cleaner : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    { 
        Destroy(other.gameObject);
    }
}