using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDataModel;

public class Fighter : MonoBehaviour
{
    //Public fields
    public int hitPoint;
    public int maxHitPoint = 10;
    public float pushRecoverySpead = 0.2f;
    //Immunity
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    //Push
    protected Vector3 pushDirection;

    //All fighters can ReceiveDamage Die
    protected virtual void ReceiveDamage(Damage dmg)
    {
        if (Time.time - lastImmune > immuneTime)
        {
            lastImmune = Time.time;
            hitPoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 15, Color.red, transform.position, Vector3.up * 25, 0.5f);

            if (hitPoint <= 0)
            {
                hitPoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death()
    {
        
    }
}
