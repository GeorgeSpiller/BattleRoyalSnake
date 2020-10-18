using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 2f;
    private Vector3 pos;
    public Animator animator;
    public Transform tr;
    public Grid grid;
    public Rigidbody2D rb;
    Vector2 movement;

    void Start()
    {
        Grid grid = transform.parent.GetComponent<Grid>();
        Vector3Int cellPosition = grid.LocalToCell(transform.localPosition);
        transform.localPosition = grid.GetCellCenterLocal(cellPosition);
        pos = transform.position;
    }


    // Update is called once per frame
    void Update() // called a number of times based on the framrate (bad for physics)
    {
        // Input
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");

     if (Input.GetKeyDown(KeyCode.D) && tr.position == pos) {
         pos += Vector3.right;
         animator.SetFloat("animationState", 3);
     }
     else if (Input.GetKeyDown(KeyCode.A) && tr.position == pos) {
         pos += Vector3.left;
         animator.SetFloat("animationState", 2);
     }
     else if (Input.GetKeyDown(KeyCode.W) && tr.position == pos) {
         pos += Vector3.up;
         animator.SetFloat("animationState", 1);
     }
     else if (Input.GetKeyDown(KeyCode.S) && tr.position == pos) {
         pos += Vector3.down;
         animator.SetFloat("animationState", 0);
     }

    }

    void FixedUpdate() // called a flat 50 times a sec (good for physics)
    {
        // Physics/movement
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * moveSpeed);
    }
}
