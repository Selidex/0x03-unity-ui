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
    public Text healthText;
    public Image wL;


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
            SetHealthText();
            //Debug.Log("Health: " + health);
        }
        if(other.tag == "Goal"){
            Text wlt = wL.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
            wL.color = Color.green;
            wlt.color = Color.black;
            wlt.text = "You Win!";
            wL.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
        }
    }
    void Update(){
        if(health == 0){
            Text wlt = wL.gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
            wL.color = Color.red;
            wlt.color = Color.white;
            wlt.text = "Game Over!";
            wL.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
        }

        if (Input.GetKey(KeyCode.Escape)){
            SceneManager.LoadScene(0);
        }
    }

    IEnumerator LoadScene(float seconds){
         yield return new WaitForSeconds(seconds);
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SetScoreText(){
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText(){
        healthText.text = "Health: " + health.ToString();
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
