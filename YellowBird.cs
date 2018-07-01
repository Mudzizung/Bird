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

public class YellowBird : Bird
{
    public override void ShouSkill()
    {
        base.ShouSkill();
        rg.velocity *= 2;
    }
    protected override void Next()
    {
        base.Next();
    }
}

