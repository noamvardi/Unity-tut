using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController player;
    public Vector3 offset = new Vector3(0f, 3.5f, -10f);
    [Tooltip("Aim above the player so the view tilts upward (more sky / horizon lower).")]
    public Vector3 lookTargetOffset = new Vector3(0f, 2f, 0f);

    void LateUpdate()
    {
        if (player == null)
            return;

        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position + lookTargetOffset);
    }
}
