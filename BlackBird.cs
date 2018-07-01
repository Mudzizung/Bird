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

public class BlackBird : Bird
{
    private List<Pig> block = new List<Pig>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "Enemy")
        {
            block.Add(collision.GetComponent<Pig>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "Enemy")
        {
            block.Remove(collision.GetComponent<Pig>());
        }
    }
    public override void ShouSkill()
    {
        base.ShouSkill();
        if (block.Count > 0 && block != null)
        {
            for (int i = 0; i < block.Count; i++)
            {
                block[i].Dead();
            }
        }
        OnClear();
    }

    void OnClear()
    {
        rg.velocity = Vector3.zero;
        Instantiate(boom, transform.position, Quaternion.identity);
        render.enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        trial.TrialEnd();
    }

    protected override void Next()
    {
        GameManager._instance.birds.Remove(this);
        Destroy(gameObject);
        GameManager._instance.NextBird();
    }
}

