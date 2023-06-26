using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D m_rb;
    public float speed;
    public float time_to_destroy;
    GameController m_gc;
    AudioSource aus;
    public AudioClip hitSound;
    public GameObject vfx;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>(); 
        aus = FindObjectOfType<AudioSource>();
        Destroy(gameObject, time_to_destroy);
    }

    // Update is called once per frame
    void Update()
    {
        //velocity la vantoc, 1 vector.
        //vector2.up = (0,1)
        m_rb.velocity = Vector2.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D col){
        if(col.CompareTag("Enemy")){
            Debug.Log("vien da da va cham");
            if(aus && hitSound){
                aus.PlayOneShot(hitSound);
            }
            if(vfx){
                GameObject new_vfx = Instantiate(vfx, col.transform.position,Quaternion.identity);
                Destroy(new_vfx,2f); // Xóa đối tượng sau 2 giây
            }
            // tang diem so
            m_gc.scoreIncrement();
            // destroy bullet
            Destroy(gameObject);
            //destroy enemy
            Destroy(col.gameObject);
        }
        else if(col.CompareTag("Safe")){
            //neu dung vao khu vuc Safe -> destroy bullet
            Destroy(gameObject);
        }
    }
}
