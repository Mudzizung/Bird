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

public class Bird : MonoBehaviour
{

    public GameObject pointPos;
    public float maxDis = 1.3f;
    public SpringJoint2D spring;
    [HideInInspector]
    public Rigidbody2D rg;
    public LineRenderer right;
    public LineRenderer left;

    public Transform leftPoint;
    public Transform rightPoint;

    public GameObject boom;

    public TextMyTrial trial;

    private bool canMove=true;

    public AudioClip select;
    public AudioClip flyclip;

    public bool isFly = false;

    public Sprite hurt;

    protected SpriteRenderer render;
    private void Start()
    {
        spring = GetComponent<SpringJoint2D>();
        rg = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDrag()
    {
        if (canMove)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += new Vector3(0, 0, 10);
            if (Vector3.Distance(transform.position, pointPos.transform.position) >= maxDis)
            {
                Vector3 dir = (transform.position - pointPos.transform.position).normalized;
                dir *= maxDis;
                transform.position = dir + pointPos.transform.position;
            }
            Line();
        }
       
    }
    void Line()
    {
        right.enabled = true;
        left.enabled = true;

        //右边线条
        right.SetPosition(0, rightPoint.position);
        right.SetPosition(1, transform.position);
        //左边线条
        left.SetPosition(0, leftPoint.position);
        left.SetPosition(1, transform.position);
    }
    private void OnMouseDown()
    {
        if (canMove)
        {
            AudioPlay(select);
            rg.isKinematic = true;
        }

    }
    private void OnMouseUp()
    {
        rg.isKinematic = false;
        Invoke("Fly", 0.1f);
        trial.TrialStart();
        AudioPlay(flyclip);
        //禁用划线组件
        right.enabled = false;
        left.enabled = false;
        canMove = false;
    }
    void Fly()
    {
        spring.enabled = false;
        isFly = true;
        Invoke("Next", 5);

    }

    protected virtual void Next()
    {
        GameManager._instance.birds.Remove(this);
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
        GameManager._instance.NextBird();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isFly = false;
        trial.TrialEnd();
    }

    public void Hurt()
    {
        render.sprite = hurt;

    }
    public void AudioPlay(AudioClip clip)
    {
        AudioSource.PlayClipAtPoint( clip,transform.position);
    }

    private void Update()
    {
        if (isFly)
        {
            if (Input.GetMouseButton(0))
            {
                ShouSkill();
            }
        }
    }

    public virtual void ShouSkill()
    {
        isFly = false;
    }
}

