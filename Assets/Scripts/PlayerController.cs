using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody player;
    public float speed = 5f;
    private int score = 0;
    public int health = 5;
    public Text scoreText;


    void Start(){
        player = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Pickup"){
            score++;
            SetScoreText();
            //Debug.Log("Score: " + score);
        }
        if(other.tag == "Trap"){
            health--;
            Debug.Log("Health: " + health);
        }
        if(other.tag == "Goal"){
            Debug.Log("You win!");
        }
    }
    void Update(){
        if(health == 0){
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SetScoreText(){
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey("w")){
            player.AddForce(0, 0, speed * Time.deltaTime);
        }
        if(Input.GetKey("s")){
            player.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if(Input.GetKey("a")){
            player.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey("d")){
            player.AddForce(speed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            player.AddForce(0, 0, speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            player.AddForce(0, 0, -speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            player.AddForce(-speed * Time.deltaTime, 0, 0);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            player.AddForce(speed * Time.deltaTime, 0, 0);
        } 
    }
}
