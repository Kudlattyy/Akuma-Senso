using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    Rigidbody rb;

    public float walkSpeed = 10f;
    public float accelerationRate = 15f;
    private Vector2 walkInput;
    private Vector3 walkDirection;

    Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
       move();
    }

    // najpierw muszę odczytać wartości vectora2 a potem przeształcić go na vectora 3
    public void OnWalk(InputValue value){
        walkInput = value.Get<Vector2>();
        walkDirection = new Vector3(walkInput.x, 0, walkInput.y).normalized;

    }

    public void move(){
        Vector3 force = walkDirection * walkSpeed * accelerationRate * Time.fixedDeltaTime;
        rb.AddForce(force, ForceMode.Force); 
        if (walkInput == Vector2.zero)
        {
           rb.linearDamping = 2;
        }
    }
    public void OnDash()
    {
        Debug.Log("Dasz jest użyty");
    }

    public void dash(){
        
    }

}
