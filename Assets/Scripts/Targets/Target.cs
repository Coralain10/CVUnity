using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System.IO;

public class Target : MonoBehaviour
{
    protected SpriteAtlas spriteAtlas;
    
    protected bool _obtained = false;
    public bool obtained {
        get => _obtained;
        set
        {
            _obtained = value;
            OnObtainedChange();
        }
    }

    protected virtual void OnObtainedChange(){}

    // protected virtual void Start()
    // {
    //     // image.sprite.name
    // }

    protected Sprite LoadSprite(string spriteName)
    {
        spriteAtlas = Resources.Load<SpriteAtlas>("Logos/logos");
        return spriteAtlas.GetSprite(spriteName);
    }
}
