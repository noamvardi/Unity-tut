using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public CheckpointController next;
    public Material activeMaterial;
    public Material completedMaterial;
    MeshRenderer centerTrigger;

    void Awake()
    {
        centerTrigger = GetComponent<MeshRenderer>();
    }

    public void SetActiveVisual(bool isActive)
    {
        Material checkpointMaterial = isActive ? activeMaterial : completedMaterial;
        if (checkpointMaterial == null)
        {
            return;
        }

        if (centerTrigger != null)
        {
            centerTrigger.material = checkpointMaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController vehicle = other.gameObject.GetComponentInParent<PlayerController>();
        if (vehicle != null && vehicle.target == this)
        {
            // Update to next checkpoint
            vehicle.SetCheckpoint(this);
            vehicle.target = next;

            // Swap to completion and activate upcoming checkpoint
            SetActiveVisual(false);
            if (next != null)
            {
                next.SetActiveVisual(true);
            }
            else
            {
                vehicle.StopTimer();
            }
        }
    }
}