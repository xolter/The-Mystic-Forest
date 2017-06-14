using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsPanel : MonoBehaviour {

    PlayerStats playerstats;
    public Text SkillPoint;
    public Text Skill1Points;
    public Text Skill2Points;
    public Text Skill3Points;
    public Text Skill4Points;

    public Text Skill1Effect;
    public Text Skill2Effect;
    public Text Skill3Effect;
    public Text Skill4Effect;

    void Start()
    {
        playerstats = PlayerStats.localPlayer;

        SkillPoint.text = playerstats.SkillPoint.ToString();

        Skill1Points.text = playerstats.Skill1Points + "/3";
        Skill1Effect.text = "Health regeneration + " + playerstats.Skill1Points * 0.2;

        Skill2Points.text = playerstats.Skill2Points + "/3";
        Skill2Effect.text = "Attack + " + (playerstats.Skill1Points * 15);

        Skill3Points.text = playerstats.Skill3Points + "/3";
        Skill3Effect.text = "Dash";

        Skill4Points.text = playerstats.Skill4Points + "/1";
        Skill4Effect.text = "Health regeneration + " + playerstats.Skill1Points * 0.2;
    }
    void Update ()
    {
        playerstats = PlayerStats.localPlayer;
        SkillPoint.text = playerstats.SkillPoint.ToString();

        Skill1Points.text = playerstats.Skill1Points + "/3";
        Skill1Effect.text = "Health regeneration + " + playerstats.Skill1Points * 0.2;

        Skill2Points.text = playerstats.Skill2Points + "/3";
        Skill2Effect.text = "Attack + " + (playerstats.Skill2Points * 15);

        Skill3Points.text = playerstats.Skill3Points + "/3";
        Skill3Effect.text = "Dash";

        Skill4Points.text = playerstats.Skill4Points + "/1";
        Skill4Effect.text = "Summun clones";
    }
    public void UpSkill1()
    {
        if (playerstats.SkillPoint > 0 && playerstats.Skill1Points < 4)
        {
            playerstats.SkillPoint -= 1;
            playerstats.Skill1Points += 1;
        }
    }
    public void UpSkill2()
    {
        if (playerstats.SkillPoint > 0 && playerstats.Skill2Points < 4)
        {
            playerstats.SkillPoint -= 1;
            playerstats.Skill2Points += 1;
        }
    }
    public void UpSkill3()
    {
        if (playerstats.SkillPoint > 0 && playerstats.Skill3Points < 4)
        {
            //FIX
            playerstats.SkillPoint -= 1;
            playerstats.Skill3Points += 1;
        }
    }
    public void UpSkill4()
    {
        if (playerstats.SkillPoint > 0 && playerstats.Skill4Points < 2 && playerstats.Skill1Points == 3 && playerstats.Skill2Points == 3 && playerstats.Skill3Points == 3)
        {
            playerstats.SkillPoint -= 1;
            playerstats.Skill4Points += 1;
        }
    }
}
