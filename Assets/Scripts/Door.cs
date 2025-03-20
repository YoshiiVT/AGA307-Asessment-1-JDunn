using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject gateDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gateDoor.SetActive(false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gateDoor.SetActive(true);
        }
    }
}

