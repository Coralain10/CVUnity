using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using System.IO;

public class Target : MonoBehaviour
{
    protected Image image;
    protected string imageChildPath = "Canvas/Mask/Image";
    protected SpriteAtlas spriteAtlas;
    
    private bool _obtained;
    public bool obtained {
        get => _obtained;
        set
        {
            _obtained = value;
            if(_obtained) setImageAlpha(1f);
            else setImageAlpha(0f);
        }
    }


    // protected virtual void Start()
    // {
    //     // image.sprite.name
    // }

    private void setImageAlpha(float a)
    {
        var tempColor = image.color;
        tempColor.a = a;
        image.color = tempColor;
    }

    protected void RestoreImage(string spriteName)
    {
        spriteAtlas = Resources.Load<SpriteAtlas>("Logos/logos");
        image = transform.Find(imageChildPath).gameObject.GetComponent<Image>();
        image.sprite = spriteAtlas.GetSprite(spriteName);
    }
}
