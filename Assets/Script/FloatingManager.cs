using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        foreach (var txt in floatingTexts)
        {
            txt.UpdateFloatomgText();
        }
    }

    public void Show(string msg , int fonSize ,Color color ,Vector3 position,Vector3 motion, float duration)
    {
        FloatingText floatingTxt = GetFloatingText();

        floatingTxt.txt.text = msg;
        floatingTxt.txt.fontSize = fonSize;
        floatingTxt.txt.color = color;
        floatingTxt.go.transform.position = Camera.main.WorldToScreenPoint(position);
        floatingTxt.motion = motion;
        floatingTxt.duration = duration;

        Debug.Log("true1");

        floatingTxt.Show();
    }

    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);

        if(txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);
        }

        return txt;
    }
}
