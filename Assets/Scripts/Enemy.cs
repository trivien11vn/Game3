using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float move_speed;
    Rigidbody2D m_rb;
    GameController m_gc;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        // velocity vector van toc
        // vector2.down = (0,-1)
        m_rb.velocity = Vector2.down * move_speed;
    }
    private void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("DeathZone")){
            m_gc.setGameover(true);
            Destroy(gameObject);
            Debug.Log("vien da da cham vao vung chet");
        }
    }
}
