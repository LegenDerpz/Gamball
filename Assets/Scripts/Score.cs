using System;
using System.Collections;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshPro pointLabel;
    public TextMeshProUGUI totalScoreGUI;
    public TotalScore totalScore;
    public Ball ballPos;
    public GameObject ball;
    public CinemachineVirtualCamera cam;
    public TotalScore gamehandler;
    public GameObject ballControlsUI;


    void Start(){
        ChangeCamTarget();
    }

    void OnTriggerEnter(Collider collider){
        if(collider.CompareTag("Ball")){
            totalScore.AddTotalBallDrops();
            if(gamehandler.GetSelectedColor() == pointLabel.text){
                totalScore.AddTotalScore(100);
                StartCoroutine(labelGlowCorrect());
            }else{
                Debug.Log("You guessed wrong!");
                StartCoroutine(labelGlowWrong());
            }
            totalScoreGUI.text = "Score: " + totalScore.GetTotalScore().ToString();

            //Destroy(collider.gameObject, 2f);

            StartCoroutine(ResetBall());
        }
    }

    IEnumerator labelGlowCorrect(){
        pointLabel.color = Color.green;
        pointLabel.outlineColor = Color.green;
        pointLabel.outlineWidth = 2;

        totalScoreGUI.color = Color.green;
        totalScoreGUI.outlineColor = Color.green;
        totalScoreGUI.outlineWidth = 2;

        yield return new WaitForSeconds(1f);

        pointLabel.color = Color.white;
        pointLabel.outlineColor = Color.white;
        pointLabel.outlineWidth = 0;

        totalScoreGUI.color = Color.white;
        totalScoreGUI.outlineColor = Color.white;
        totalScoreGUI.outlineWidth = 0;
    }

    IEnumerator labelGlowWrong(){
        pointLabel.color = Color.red;
        pointLabel.outlineColor = Color.red;
        pointLabel.outlineWidth = 2;

        yield return new WaitForSeconds(1f);

        pointLabel.color = Color.white;
        pointLabel.outlineColor = Color.white;
        pointLabel.outlineWidth = 0;
    }

    void ChangeCamTarget(){
        cam.m_Follow = FindObjectOfType<Ball>().transform;
        cam.m_LookAt = FindObjectOfType<Ball>().transform;
    }

    IEnumerator ResetBall(){
        yield return new WaitForSeconds(2.1f);

        if(gamehandler.GetSelectedColor() == pointLabel.text){
            ballPos.rb.velocity = Vector3.zero;
            ballPos.transform.position = new Vector3(0.05f, 19.96f, 4.43f);
            ballPos.transform.rotation = Quaternion.identity;
            ballPos.GetComponent<PlayerInput>().enabled = true;
            ballPos.rb.useGravity = false;
            ChangeCamTarget();
            gamehandler.ShowColorSelectGUI();
            ballControlsUI.SetActive(true);
        }else{
            Debug.Log("You guessed wrong!");
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("MainMenu");
        }
    }
}
