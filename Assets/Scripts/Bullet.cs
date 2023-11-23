using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum EBullets
    {
        Red = 0, Green = 1, Blue = 2
    }

    public EBullets bulletType;

    public void Start()
    {
        Manager.Init2(this);
    }

    public void setRed()
    {
        Debug.Log("red bullet active");
        bulletType = EBullets.Red;
    }
    public void setGreen()
    {
        Debug.Log("green bullet active");
        bulletType = EBullets.Green;
    }
    
    public void setBlue()
    {
        Debug.Log("blue bullet active");
        bulletType = EBullets.Blue;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (bulletType == EBullets.Red && collision.tag == "Red")
        { 

            Destroy(collision.gameObject);
        } else if (bulletType == EBullets.Green && collision.tag == "Green")
        {
            Destroy(collision.gameObject);
        } else if (bulletType == EBullets.Blue && collision.tag == "Blue")
        {
            Destroy(collision.gameObject);
        }
    }
}
