using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody player;
    public float speed = 30f;
    // Start is called before the first frame update
    void Start()
    {

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
