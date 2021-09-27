using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{

    public Sprite emptyChest;
    public int maxCoin = 0;
    public int minCoin = 0;
    protected override void OnCollide(Collider2D coll)
    {
        if (!collected)
        {
            var coin = Random.Range(minCoin, maxCoin);
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;

            GameManager.instance.ShowText("+ " + coin + " Coin", 15, Color.yellow, transform.position, Vector3.up * 25, 3);
            GameManager.instance.coin += coin;
            GameManager.instance.SaveState();

        }
    }
}
