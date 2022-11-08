using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Transform _transform;

    [SerializeField] private float speed = 20f;
    //[SerializeField] private SerialHandler serialHandler;
    [SerializeField] private Rigidbody2D ledArea;
    [SerializeField, Range(1, 2)] public int playerID;
    private float targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction =Vector3.zero;
        //_transform.position += direction.normalized * speed * Time.deltaTime;
        if (transform.position.y < targetPosition-0.2f)
        {
             direction = new Vector3(Input.GetAxisRaw("Horizontal"), 1, 0);
            
        }
        else if(transform.position.y > targetPosition + 0.2f)
        {
             direction = new Vector3(Input.GetAxisRaw("Horizontal"), -1, 0);
        }
        else
        {
            direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        }
        _transform.position += direction.normalized * speed * Time.deltaTime;

    }

    public void setVertical(float vertical)
    {
        targetPosition = vertical;
    } 

/*    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody == ledArea)
        {
            serialHandler.SetLed(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.attachedRigidbody == ledArea)
        {
            serialHandler.SetLed(false);
        }
    }*/
}
