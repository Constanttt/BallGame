using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;
    public int livesTotal;
    public Text timerText;
    public float timeLeft;
    public int sceneIndex;

    private Rigidbody rb;
    private int lives;
    private int count;
    private float timer;
    private const int PICKUPS = 12;

    void Start(){
      Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
        count = 0;
        lives = livesTotal;
        SetCountText();
        SetLivesText();
        winText.text = "";
        timerText.text = "";
        timer = timeLeft;
    }

    void FixedUpdate(){
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other){
      if (other.gameObject.CompareTag("Pick Up")){
        other.gameObject.SetActive(false);
        count = count + 1;
        SetCountText();
      }
      if (other.gameObject.CompareTag("Add Time")){
        other.gameObject.SetActive(false);
        timer = timer + 5;
        SetCountText();
      }
    }

    void OnCollisionEnter(Collision col){
      if (col.gameObject.CompareTag("Enemy")){
        lives = lives - 1;
        SetLivesText();
      }
    }

    void SetLivesText(){
      livesText.text = lives.ToString() + " lives left";
      if(lives <= 0){
        winText.text = "You Lose!";
        Time.timeScale = 0;
      }
    }

    void SetCountText(){
      countText.text = "Count:" + count.ToString() + "/" + PICKUPS;
      if(count >= PICKUPS){
        winText.text = "You Win!";
        Time.timeScale = 0;
      }
    }

    void Update(){
      float t = timer - Time.timeSinceLevelLoad;
      timerText.text = "Time: " + t;
      if(t<=0){
        winText.text = "You Lose!";
        Time.timeScale = 0;
      }
    }

    public void GoToMenu(){
         SceneManager.LoadScene(sceneIndex);
     }
}
