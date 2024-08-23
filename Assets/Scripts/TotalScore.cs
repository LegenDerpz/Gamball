using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TotalScore : MonoBehaviour
{
    int totalScore;
    int tries = 0;

    public GameObject colorSelectGUI;
    public GameObject ballControlsUI;
    String selectedColor;

    void Start(){
        FindObjectOfType<Ball>().GetComponent<PlayerInput>().enabled = false;
        ballControlsUI.SetActive(false);
    }

    public void AddTotalScore(int score){
        totalScore += score;
    }

    public int GetTotalScore(){
        return totalScore;
    }
    public void AddTotalBallDrops(){
        tries++;
    }
    public int GetTries(){
        return tries;
    }

    public void SetSelectedColor(TextMeshProUGUI color){
        selectedColor = color.text;
    }
    public String GetSelectedColor(){
        return selectedColor;
    }

    public void HideColorSelectGUI(){
        colorSelectGUI.SetActive(false);
        FindObjectOfType<Ball>().GetComponent<PlayerInput>().enabled = true;
        ballControlsUI.SetActive(true);
    }

    public void ShowColorSelectGUI(){
        colorSelectGUI.SetActive(true);
        FindObjectOfType<Ball>().GetComponent<PlayerInput>().enabled = false;
        ballControlsUI.SetActive(false);
    }
}
