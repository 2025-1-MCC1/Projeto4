using UnityEngine;
using UnityEngine.SceneManagement;

public class Wifi : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            wifis.instance.AddPoint();
            Destroy(gameObject); // Faz o wifi sumir
        }
    }
}
