using UnityEngine;
using UnityEngine.InputSystem;



public class Player : MonoBehaviour
{
    
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;

    [SerializeField] float moveSpeed = 16f;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight; 

    private void Start()
    {
        Camera cam;
        cam = Camera.main;
        minBounds = cam.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = cam.ViewportToWorldPoint(new Vector2(1, 1));
    }
    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);

        transform.position = newPos;
    }

    private void OnMove(InputValue value)
    {
        //get the InputValue
        rawInput = value.Get<Vector2>();
    }

}
