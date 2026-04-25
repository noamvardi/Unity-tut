using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public Transform targetToMove;
    public Vector3 moveDirection = Vector3.right;
    public float moveDistance = 4f;
    public float moveSpeed = 2f;

    Vector3 startPosition;

    void Awake()
    {
        if (targetToMove == null)
        {
            targetToMove = transform;
        }
    }

    void Start()
    {
        startPosition = targetToMove.position;
    }

    void Update()
    {
        if (moveDistance <= 0f || moveSpeed <= 0f)
        {
            return;
        }

        Vector3 direction = moveDirection.sqrMagnitude > 0f ? moveDirection.normalized : Vector3.right;
        float offset = Mathf.PingPong(Time.time * moveSpeed, moveDistance * 2f) - moveDistance;
        targetToMove.position = startPosition + direction * offset;
    }
}
