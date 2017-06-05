using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static float currentHealth = 100;
    public static int maxHealth = 100;
    public static int minHealth = 0;
    public static float regenHealth = 0;

    public static float currentMana = 100;
    public static int maxMana = 100;
    public static int minMana = 0;
    public static float regenMana = 0.02f;

    public static int xp = 0;
    public static int maxXp = 100;
    public static int addXp = 50;

    public static float default_damages = 10f;
    public static float damage = 10f;
    public static int Lvl = 1;
}
