using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DragMouseMove : MonoBehaviour
{
    private Vector3 touchPosition;
    private Rigidbody2D rigid;
    private Vector2 direction;
    [SerializeField]
    private float movementSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Move()
    {
        Touch touch = Input.GetTouch(0);
        touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        touchPosition.z = 0;
        direction = (touchPosition - transform.position);
        rigid.velocity = new Vector2(direction.x, direction.y) * movementSpeed;


    }
}
