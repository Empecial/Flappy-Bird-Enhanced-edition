using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class PlayerControls : MonoBehaviour
{
    private PlayerInputActions _playinput;

    public Rigidbody2D rb;

    public TextMeshProUGUI Scoretext;

    public float JumpHeight = 9f;
    public float DiveHeight;

    private int FlapScore;

    void Awake()
    {
        _playinput = new PlayerInputActions();
        _playinput.Flap.Enable();

        _playinput.Flap.FlapJump.performed += Jump;

        _playinput.Flap.FlapDive.performed += Dive;
    }

    private void OnEnable()
    {
        _playinput.Enable();
    }

    private void OnDisable()
    {
        _playinput.Disable();
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        rb.velocity = new Vector2(0, JumpHeight);
        print("Player jumped");
    }

    public void Dive(InputAction.CallbackContext ctx)
    {
        rb.velocity = new Vector2(0,DiveHeight);
        print("Player Dove");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Score"))
        {
            FlapScore++;

            Scoretext.text = FlapScore.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Death"))
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

    }
}
