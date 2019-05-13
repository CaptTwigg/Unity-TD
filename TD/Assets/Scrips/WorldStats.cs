using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldStats : MonoBehaviour
{
    public static int HP = 10;
    public static int gold = 300;
    public static int level = 1;

    public Text hptext;
    public Text goldText;
    public Text levelText;


    private void Update()
    {
        hptext.text = "HP: " + HP;
        goldText.text = "Gold: " + gold;
        levelText.text = "Level: " + level;
    }

}
