using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//B1: tao enemy ,random vi tri
//B2: tang score
//B3: check gameover
public class GameController : MonoBehaviour
{
    public GameObject enemy;
    public float spawntime; // tgian tao enemy
    float m_spawntime; 
    int m_score;
    bool m_isgameover;
    UI_Manager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        m_spawntime = 0;
        m_ui = FindObjectOfType<UI_Manager>();
        m_ui.SetScoreText("SCORE: "+m_score);
    }

    // Update is called once per frame
    void Update()
    {
        if(m_isgameover){
            m_spawntime = 0;
            m_ui.ShowGameoverPanel(true);
            return;
        }
        m_spawntime -= Time.deltaTime;
        if(m_spawntime <=0){
            spawnEnemy();
            m_spawntime = spawntime;
        }
    }
    public void Replay(){
        SceneManager.LoadScene("SampleScene");
    }
    public void spawnEnemy(){
        float range_x = Random.Range(-11f,11f);
        Vector2 pos = new Vector2(range_x, 7);
        if(enemy){
            Instantiate(enemy, pos, Quaternion.identity);
        }
    }
    public void setScore(int value){
        m_score = value;
    } 
    public int getScore(){
        return m_score;
    }
    public void scoreIncrement(){
        if(m_isgameover) return;
        m_score ++;
        m_ui.SetScoreText("SCORE: "+m_score);
    }
    public void setGameover(bool state){
        m_isgameover = state;
    }
    public bool isGameover(){
        return m_isgameover;
    }
}
