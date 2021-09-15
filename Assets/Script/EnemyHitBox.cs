using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDataModel;

public class EnemyHitBox : Collidable
{
    //Damage
    public int damage;
    public float pushForce;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter" && coll.name == "player_0")
        {
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };
            //Fighter
            coll.SendMessage("ReceiveDamage",dmg);
        }
    }
}
