using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    private Animator animator;
    private Rigidbody rigidBody;
    [SerializeField] private Vector3 flapDirection = new Vector3(0, 3, 0.3f);
    [SerializeField] private const float JUMP_AMOUNT = 5.0f;
    private const float FORWARD_AMOUNT = 3.0f; 
    private bool gameOver;
    private int score;
    private float heightBound;
    private GameObject canvas;
    [SerializeField] private Text inGameScoreText;
    [SerializeField] private Text scoreText;

    public Text InGameScoreText 
    {
        get 
        {
            return inGameScoreText;
        }
        set 
        {
            this.inGameScoreText = value;
        }
    }
    public int Score 
    {
        get 
        {
            return score;
        }
        set 
        {
            this.score = value;
        }
    }
    void Start()
    {
        heightBound = 12.0f;
        score = 0;
        rigidBody = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        canvas = GameObject.Find("GameOverPOPUP").transform.GetChild(0).gameObject;
        gameOver = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !gameOver) 
        {
            rigidBody.velocity = Vector3.up * JUMP_AMOUNT + Vector3.forward * FORWARD_AMOUNT;
            animator.Play("WingsDown");
            particleSystem.Play();
            
        }
        if (gameObject.transform.position.y >= heightBound) 
        {
            gameObject.transform.position = new Vector3(
                gameObject.transform.position.x, heightBound, gameObject.transform.position.z);
        }
        inGameScoreText.text = "Score: " + score;

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameOver();
    }

    private void GameOver() 
    {
        gameOver = true;
        canvas.SetActive(true);
        scoreText.text = score.ToString();

    }
}
