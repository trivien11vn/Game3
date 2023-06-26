using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public GameObject bullet;
    public Transform shootingPoint;
    GameController m_gc;
    public AudioSource aus;
    public AudioClip shootingSource;
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_gc.isGameover()) return;
        float xDirection = Input.GetAxisRaw("Horizontal");
        if((xDirection<0 && transform.position.x <= -8.2)||(xDirection>0 && transform.position.x>11.5)) return;
        //Vector3.right tuong duong (1,0,0)
        transform.position += Vector3.right * moveSpeed * Time.deltaTime * xDirection;
        if (Input.GetKeyDown(KeyCode.Space)){
            shoot();
        }
    }

    public void shoot(){
        if(bullet && shootingPoint){
            //tao ra bullet 
            if(aus && shootingSource){
                aus.PlayOneShot(shootingSource);
            }
            Instantiate(bullet, shootingPoint.position, Quaternion.identity);
        }
    }
    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Enemy")){
            Debug.Log("enemy va cham player");
            m_gc.setGameover(true);
            Destroy(col.gameObject);
        }
    }
}
