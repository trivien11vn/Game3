using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//B1: Hien thi score
//B2: Hien thi thong bao
public class UI_Manager : MonoBehaviour
{
    // Text trong thu vien UnityEngine.UI
    public Text scoreText;
    public GameObject gameoverPanel;
    // Start is called before the first frame update
    public void SetScoreText(string txt){
        if(scoreText){
            scoreText.text = txt;
        }
    }
    public void ShowGameoverPanel(bool isShow){
        if(gameoverPanel){
            gameoverPanel.SetActive(isShow);
        }
    }
}
