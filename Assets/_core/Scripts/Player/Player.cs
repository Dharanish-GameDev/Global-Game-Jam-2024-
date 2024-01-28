using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 5;

    private Vector2 direction;
    private Vector2 temp;
    [SerializeField] private bool isFaceRight;

    private Interactable selectedInteractible;

    private void Start()
    {
        direction = new(0, 0);
    }

    private void Update()
    {
        CheckInput();
        HandleFlip();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void SetSelectedInteractible(Interactable interactable)
    {
        selectedInteractible = interactable;
    }

    private void CheckInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        anim.SetBool("IsWalk", direction.x != 0);

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    private void MovePlayer()
    {
        rb.velocity = speed * direction;
    }

    private void HandleFlip()
    {
        //if (direction.x == 0) return;

        if ((direction.x < 0 && !isFaceRight) || (direction.x > 0 && isFaceRight) || direction.x == 0) return;

        isFaceRight = direction.x > 0;
        temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;
    }

    private void Interact()
    {
        if(selectedInteractible != null)
        {
            selectedInteractible.Interact();
        }
    }
}