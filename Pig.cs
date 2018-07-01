/***
  *Title:""��Ŀ
  *Description:
  *		����:
  *Author:D
  *Data:2018.03.18
  *
  *
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    public float minSpeed = 5;
    public float maxSpeed = 8;
    private SpriteRenderer sprite;
    public Sprite hertSprite;
    public GameObject boom;
    public GameObject score;
    public bool isPig = false;

    public AudioClip hit;
    public AudioClip dead;
    public AudioClip birdCloolision;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioPlay(birdCloolision);
            collision.transform.gameObject.GetComponent<Bird>().Hurt();
        }
        if (collision.relativeVelocity.magnitude > maxSpeed)
        {
            Dead();


        }
        else if (collision.relativeVelocity.magnitude < minSpeed)
        {

        }
        else
        {
            //改变图片
            sprite.sprite = hertSprite;
            AudioPlay(hit);
        }
       
    }
   public  void Dead()
    {
        if (isPig)
        {
            GameManager._instance.pigs.Remove(this);
        }
        AudioPlay(dead);
        Destroy(transform.gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameObject go = Instantiate(score, transform.position+new Vector3(0,0.5f,0), Quaternion.identity);
        Destroy(go, 1.5f);
    }
    public void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
    }
}

