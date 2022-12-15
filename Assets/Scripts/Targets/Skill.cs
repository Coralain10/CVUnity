using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Skill : TargetGO
{
    public float xMin; 
    public float xMax;
    bool isPlayerClose;

    public override void RestoreObj(SaveTarget target)
    {
        base.RestoreObj(target);
    }
    public void RestoreInfo(SkillInfo skillInfo)
    {
        RestoreInfo((TargetInfo)skillInfo);
    }

    //TODO  Move | Physics2D raycast:
    // 1 a cada lado + offset de 0.25f aprox. si no toca suelo, girar.
    // 1 al frente. Si player cerca, perseguirlo, sino, retornar mov normal.
}