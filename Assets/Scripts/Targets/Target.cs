using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Target : MonoBehaviour
{
    Image image;
    public int targetIndex;
    private bool _obtained;
    public bool obtained {
        get => _obtained;
        set {
            _obtained = value;
            if(_obtained) setImageAlpha(1f);
            else setImageAlpha(0f);
        }
    }

    protected virtual void Awake()
    {
        image = transform.Find("Canvas/Mask/Image").gameObject.GetComponent<Image>();
        // image.sprite.name
    }

    private void setImageAlpha(float a)
    {
        var tempColor = image.color;
        tempColor.a = a;
        image.color = tempColor;
    }

    public virtual SaveTarget Tokenize()
    {
        SaveTarget target = new SaveTarget();
        target.index      = targetIndex;
        target.obtained   = obtained;
        target.parentName = transform.parent.name;
        target.position   = transform.position;
        return target;
    }

    public virtual void Restore(SaveTarget target)
    {
        if(target == null) throw new System.ArgumentNullException("target");
        targetIndex     = target.index;
        obtained        = target.obtained;
    }

    protected void RestoreImage(string spriteName)
    {
        image.sprite = Resources.Load<Sprite>(spriteName);
    }

    protected virtual void RestoreObject(SaveTarget target)
    {
        // transform.SetParent( GameObject.Find(target.parentName).transform ); //, false
        transform.position = target.position;
    }
    
    [System.Serializable]
    public class SaveTarget
    {
        public int index;
        public bool obtained;
        public string parentName;
        public Vector3 position;
    }
}
