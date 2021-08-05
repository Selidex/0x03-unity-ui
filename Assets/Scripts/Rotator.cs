using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(45 * Time.deltaTime, 0, 0);
    }
}
