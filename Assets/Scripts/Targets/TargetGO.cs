using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Target Game Object on Platform
public class TargetGO : Target
{
    public virtual SaveTarget Tokenize(TargetInfo info)
    {
        SaveTarget target = new SaveTarget();
        target.gameIndex  = info.id;
        target.infoIndex  = info.idByType;
        target.obtained   = obtained;
        target.parentName = transform.parent.name;
        target.position   = transform.position;
        return target;
    }
    
    public virtual void RestoreObj(SaveTarget target)
    {
        if(target == null) throw new System.ArgumentNullException("target");
        obtained           = target.obtained;
        // transform.SetParent( GameObject.Find(target.parentName).transform ); //, false
        transform.position = target.position;
    }

    public virtual void RestoreInfo(TargetInfo info)
    {
        RestoreImage(info.spriteName);
    } 
    
    [System.Serializable]
    public class SaveTarget
    {
        public bool obtained;
        public int gameIndex;
        public int infoIndex;
        public string parentName;
        public Vector3 position;
    }
}
