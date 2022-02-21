using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D characterRB;
    public float moveSpeed = 0.5f;

    public bool frozen = false;

    public Animator characterAnimator;
    private bool isMoving;

    // Use this for initialization
    void Start()
    {
        characterAnimator = GetComponent<Animator>();
        characterRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!frozen)
        {
            Vector3 move = transform.position;

            float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }

            characterAnimator.SetFloat("VelocityX", moveX);
            characterAnimator.SetFloat("VelocityZ", moveY);
            characterAnimator.SetBool("bMoving", isMoving);

            move += new Vector3(moveX, moveY);

            if (characterRB != null)
            {
                characterRB.MovePosition(move);
            }

        }
        else
        {
        }

    }


}
