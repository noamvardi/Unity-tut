using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 40f;

    public float maxHorizontalSpeed = 18f;

    public CheckpointController target;
    public float respawnLift = 1f;

    Rigidbody rb;
    Vector2 moveInput;
    CheckpointController lastCheckpoint;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        lastCheckpoint = target;
        target.SetActiveVisual(true);
    }

    void FixedUpdate()
    {
        Vector3 force = new Vector3(moveInput.x, 0f, moveInput.y) * moveForce;
        rb.AddForce(force, ForceMode.Force);

        Vector3 horizontal = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (horizontal.magnitude > maxHorizontalSpeed)
        {
            horizontal = horizontal.normalized * maxHorizontalSpeed;
            rb.linearVelocity = new Vector3(horizontal.x, rb.linearVelocity.y, horizontal.z);
        }
    }

    void OnMove(InputValue action)
    {
        moveInput = action.Get<Vector2>();
    }

    public void SetCheckpoint(CheckpointController checkpoint)
    {
        if (checkpoint != null)
        {
            lastCheckpoint = checkpoint;
        }
    }

    public void RespawnAtLastCheckpoint()
    {
        if (lastCheckpoint == null)
        {
            return;
        }

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = lastCheckpoint.transform.position + Vector3.up * respawnLift;
        transform.rotation = lastCheckpoint.transform.rotation;
    }
}
