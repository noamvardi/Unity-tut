using UnityEngine;

public class RespawnPlane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponentInParent<PlayerController>();
        if (player != null)
        {
            player.RespawnAtLastCheckpoint();
        }
    }
}
