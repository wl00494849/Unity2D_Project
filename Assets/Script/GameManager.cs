using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameDataModel;
using Newtonsoft;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    // ressources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrice;
    public List<int> xpTable;
    //Logic
     public int coin;
    public int experience;
    //references
    public Player player;
    public Weapon weapon;
    public FloatingManager floatingManager;
    //Floating text
    public void ShowText(string msg, int fontSize,Color color,Vector3 position,Vector3 motion,float duration)
    {
        floatingManager.Show(msg,fontSize,color,position,motion,duration);
    }
   
    public void SaveState()
    {
        Debug.Log("SaveState");

        var saveModel = new SaveModel();
        saveModel.preferedSkin = 0;
        saveModel.coin = coin;
        saveModel.xp = experience;
        saveModel.weaponLevel = weapon.weaponLevel;

        var jsonStr = JsonUtility.ToJson(saveModel);
        PlayerPrefs.SetString("SaveState",jsonStr);

    }
    public void LoadState(Scene s, LoadSceneMode mod)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {
            return;
        }

        var loadData = JsonUtility.FromJson<SaveModel>(PlayerPrefs.GetString("SaveState"));
        coin = loadData.coin;
        experience = loadData.xp;
        weapon.SetWeaponLevel(loadData.weaponLevel);

    }
    //Upgrade Weapon
    public bool TryUpgradeWeapon()
    {
        // is the weapon max level?
        if (weaponPrice.Count <= weapon.weaponLevel)
        {
            return false;
        }

        if (coin >= weaponPrice[weapon.weaponLevel])
        {
            coin -= weaponPrice[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }

        return false;
    }
    //Experience System
    public int GetCurrentLevel()
    {
        int r = 0;
        int add = 0;

        while (experience >= add)
        {
             add += xpTable[r];
             r++;

             if (r == xpTable.Count)
             {
                 return r;
             }
        }

        return r;
    }
    public int GetXpToLevel(int level)
    {
        int r = 0;
        int xp = 0;
        while (r < level)
        {
             xp += xpTable[r];
             r++;
        }

        return xp;
    }
    public void GrantXp(int xp)
    {
        int currLevel = GetCurrentLevel();
        experience += xp;
        if(currLevel < GetCurrentLevel())
        {
            OnLevelUp();
        }
    }
    public void OnLevelUp()
    {
        Debug.Log("Level UP");
    }
}
