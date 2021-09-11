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
        if (coll.tag == "Fighter" && coll.name == "Player")
        {
            Damage dmg = new Damage
            {
                damageAmount = damage,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("RecevieDamage",dmg);
        }
    }
}
