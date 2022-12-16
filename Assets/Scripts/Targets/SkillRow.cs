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
        progress.localScale = new Vector3 (info.progress / 100f, 1, 1);
        base.Restore(info);
    }
}
