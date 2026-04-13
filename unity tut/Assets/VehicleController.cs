using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    float desired_acceleration = 0;
    public float impulse = 10;
    public float turnrate = 200;
    public CheckpointController target;


    void Start()
    {
        target.left.materials[0].color = Color.red;
        target.right.materials[0].color = Color.red;
    }

    void Update()
    {
        GetComponent<Rigidbody>().AddRelativeForce(desired_acceleration * impulse, 0, 0);
        
        float dx = (Mouse.current.position.x.value - Screen.width / 2) / turnrate;
        if (Mathf.Abs(dx) > 0.01f)
        {
            transform.Rotate(0, dx, 0);
        }
    }

    void OnMove(InputValue action)
    {
        var movement = action.Get<Vector2>();
        desired_acceleration = movement.y;
    }
}