using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protal : Collidable
{
    public string sceneNames;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "player_0")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNames);
        }
    }
}
