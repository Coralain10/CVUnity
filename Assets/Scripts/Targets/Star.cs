using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Star : Target
{
  StarInfo starInfo;
  //STAR ROW
  // void Awake()
  // {
  // }
  // UpdateObtained()

  public override void Restore(SaveTarget target)
  {
    base.Restore(target);
    starInfo = TargetsInfo.StarsInfo[targetIndex];
    RestoreImage(starInfo.spriteName);
  }


  // RestoreObject(SaveTarget target)
}