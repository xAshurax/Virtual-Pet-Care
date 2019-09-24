using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class DragMouseMove : MonoBehaviour
{
    private Vector3 touchPosition;
    private Rigidbody2D rigid;
    private Collider2D myCollider;
    private Vector2 direction;
    private bool beingHeld=false;
    [SerializeField]
    private float movementSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            MovePC();
        } else
        {
            beingHeld = false;
        }
#else
        if (Input.touchCount>0)
        {
            MoveAndroid();
        } 
#endif
        
    }

    private void MoveAndroid()
    {

        Touch touch = Input.GetTouch(0);
        touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        touchPosition.z = 0;
        if (myCollider == Physics2D.OverlapPoint(touchPosition)) {
            direction = (touchPosition - transform.position);
            rigid.velocity = new Vector2(direction.x, direction.y) * movementSpeed;

        }


    }

    private void MovePC()
    {
        touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (beingHeld)
        {
            direction = (touchPosition - transform.position).normalized;
            rigid.velocity = new Vector2(direction.x, direction.y) * movementSpeed;

        } else if (myCollider == Physics2D.OverlapPoint(touchPosition))
        {
            beingHeld = true;
        }
        
    }
}
