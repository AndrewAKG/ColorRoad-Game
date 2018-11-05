using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour {

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highestScoreText;
    public CollectablesManager collectableManager;
    public bool isDead = false;
    public GameObject gameoverMenu;
    public AudioSource matchingHit;
    public AudioSource nonmatchingHit;
    public AudioSource colorChange;
    public AudioSource background;
    public AudioSource menusMusic;

    private Animator animator;
    private CharacterController controller;
    private float forwardSpeed = 5.0f;
    private float horizontalSpeed = 5.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    private GameObject playerSphere;
    private Color playerColor;
    private int speedCounter = 0;
    private int score = 0;
    private int highestScoreSoFar = 0;
    private bool androidPlatform;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        scoreText.SetText("Score: " + score);
        playerSphere = GameObject.FindGameObjectWithTag("PlayerColor");
        playerColor = playerSphere.GetComponent<Renderer>().material.color;

        if (Application.platform == RuntimePlatform.Android)
        {
            androidPlatform = true;
        }
        else
        {
            androidPlatform = false;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (isDead)
            return;

        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //X
        if (!androidPlatform)
        {
            moveVector.x = Input.GetAxisRaw("Horizontal") * horizontalSpeed;
        }
        else
        {
            moveVector.x = Input.acceleration.x * horizontalSpeed * 5;
        }

        //Y
        moveVector.y = verticalVelocity;

        //Z
        moveVector.z = forwardSpeed;

        controller.Move(moveVector * Time.deltaTime);

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Light"))
        {
            Color collisionColor = other.gameObject.GetComponent<Light>().color;
            playerSphere.gameObject.GetComponent<Renderer>().material.color = collisionColor;
            playerColor = collisionColor;
            colorChange.Play();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Collectable"))
        {
            Color collisionColor = hit.gameObject.GetComponent<Renderer>().material.color;
            if (collisionColor == playerColor)
            {
                matchingHit.Play();
                score += 10;
                scoreText.SetText("Score: " + score);
                speedCounter++;

                if (speedCounter == 5)
                {
                    forwardSpeed += 5;
                    horizontalSpeed += 0.5f;
                    animator.speed += 0.5f;
                    speedCounter = 0;
                }

                if (highestScoreSoFar < score)
                {
                    highestScoreSoFar = score;
                }
            }
            else
            {
                nonmatchingHit.Play();
                score /= 2;
                scoreText.SetText("Score: " + score);

                if(score == 0)
                {
                    isDead = true;
                    highestScoreText.SetText("Score: " + highestScoreSoFar);
                    gameoverMenu.SetActive(true);
                    Time.timeScale = 0f;
                    background.Stop();
                    menusMusic.Play();
                }
            }

            Destroy(hit.gameObject);
            collectableManager.collectablesSoFar--;
        }
    }
}
