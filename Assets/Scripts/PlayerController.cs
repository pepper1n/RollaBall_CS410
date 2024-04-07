using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public float jumpHeight = 0;
    public TextMeshProUGUI scoreText;
    public GameObject winTextObject;
    public GameObject RestartButton;
    private Rigidbody rb;
    private float moveX;
    private float moveY;
    private int jump_ct;

    private int score;


    // Start is called before the first frame update
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent <Rigidbody>();   
                
        score = 0;
        SetScoreText();
        winTextObject.SetActive(false);
        RestartButton.SetActive(false);
    }

    // This function is called when a move input is detected.
    void OnMove (InputValue moveVal)
    {
        // input value into 2-d vector
        Vector2 moveVector = moveVal.Get<Vector2>();
        moveX = moveVector.x;
        moveY = moveVector.y;
    }

    void SetScoreText()
    { 
        scoreText.text = "Score: " + score.ToString();
        
        if (score >= 8)
        {
           winTextObject.SetActive(true);
           RestartButton.SetActive(true);
        }
    }

    void OnCollisionStay()
    {
        jump_ct = 0;
    }


    private void FixedUpdate()
    {
        // 3-d movement vctor based on 2-d vector
        Vector3 movement = new Vector3(moveX, 0.0f, moveY);
        
        // apply force to player
        rb.AddForce(movement * speed);
    }

    void Update() 
    {
        // this seems inefficient but it couldn't find the variable in Start. why?
        Vector3 jump = new Vector3(0.0f, jumpHeight, 0.0f);

        // check for jump_Ct less than 1 gave me triple jump? dont understand why
        if (Input.GetKeyDown(KeyCode.Space) && jump_ct == 0)
        {
            jump_ct += 1;
            rb.AddForce(jump, ForceMode.Impulse);  
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            score += 1;
            SetScoreText();
        }
    }

}
