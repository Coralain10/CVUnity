using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillRow : TargetRow
{
    Transform progress;

    public void Restore(SkillInfo info)
    {
        progress = transform.Find("ProgressBar/Progress");
        progress.localScale = Vector3.right * (info.progress / 100);
        base.Restore(info);
    }
}
