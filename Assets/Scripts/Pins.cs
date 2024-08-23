using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour
{
    public float bounceForce = 5f;
    Vector3 minAngle = new Vector3(-2f, 0f, 0f);
    Vector3 maxAngle = new Vector3(2f, 0f, 0f);
    Vector3 randomSidewaysForce;
    float colorChangeTime = 0.5f;
    public Colors pinColor;
    Color color;

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Ball"){
            randomSidewaysForce = new Vector3(Random.Range(minAngle.x, maxAngle.x), Random.Range(minAngle.y, maxAngle.y), Random.Range(minAngle.z, maxAngle.z));
            collision.gameObject.GetComponent<Rigidbody>().AddForce(randomSidewaysForce * bounceForce, ForceMode.Impulse);

            StartCoroutine(colorPing());

            collision.gameObject.GetComponent<Renderer>().material.color = color;
        }
    }

    IEnumerator colorPing(){
        if(pinColor == Colors.red){
            color = Color.red;
        }else if(pinColor == Colors.yellow){
            color = Color.yellow;
        }else if(pinColor == Colors.green){
            color = Color.green;
        }else if(pinColor == Colors.blue){
            color = Color.blue;
        }else if(pinColor == Colors.magenta){
            color = Color.magenta;
        }else if(pinColor == Colors.cyan){
            color = Color.cyan;
        }
        
        gameObject.GetComponent<Renderer>().material.color = color;

        yield return new WaitForSeconds(colorChangeTime);

        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    public enum Colors{
        red,
        yellow,
        green,
        blue,
        magenta,
        cyan
    }
}
