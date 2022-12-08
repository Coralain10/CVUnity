using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Live : MonoBehaviour
{
    [SerializeField] public byte health { get; private set; }
    public RectMask2D healthMask;
    float maskTopMin = 8f;
    float maskTopMax = 40f;
    float maskStep;
    byte timePerStep = 4;
    byte step = 10;
    // public bool isFull { get; private set; }
    
    void Awake()
    {
        maskStep = (maskTopMax - maskTopMin)/(100/step);
        ToFull();
    }

    void editTopMask(float newTop) {
        healthMask.padding = new Vector4(
            healthMask.padding.x, healthMask.padding.y,
            healthMask.padding.z, newTop
        );
    }
    
    public void ToFull()
    {
        health = 100; //Each live is a Heatlh bar
        editTopMask(maskTopMin);
        // isFull = true;
    }
    
    public void SetDamage()
    {
        health -= step;
        editTopMask(healthMask.padding.w + maskStep);
        // if(health == 0) isFull = false;
    }

    public IEnumerator Recover()
    {
        while (health < 100)
        {
            yield return new WaitForSeconds(timePerStep);
            health += step;
            editTopMask(healthMask.padding.w - maskStep);
            // healthMask.padding.z += maskStep;
        }
        // isFull = true;
    }

    public int getTimeToRecover()
    {
        return ((100 - health)/step) * timePerStep;
    }
    
}
