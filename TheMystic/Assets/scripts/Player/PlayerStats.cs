using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class PlayerStats
{
    public static float CurrentHealth = 100;
    public static int MaxHealth = 100;
    public static int minHealth = 0;
    public static float RegenHealth = 0.1f;

    public static float CurrentMana = 100;
    public static int MaxMana = 100;
    public static int minMana = 0;
    public static float RegenMana = 0.02f;

    public static int Xp = 0;
    public static int MaxXp = 100;
    public static int addXp = 50;

    public static int Lvl = 1;
}
