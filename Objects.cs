using System;
using System.Collections.Generic;

namespace Battle
{
  public class BaseObject
  {
    string Name;
    int Level;
    int MaxHP;
    int MaxMP;
    int HP;
    int MP;
    int ATK;
    int DEF;
    int SPD;
    int INT;
    int RES;
    int EVD;
    int EXP;
    int Gold;
    List<SpellsAndSkills> SpellsAndSkillsList = new List<SpellsAndSkills>(); 

    public BaseObject()
    {
      
    }
    public BaseObject(string name, int lvl, int maxHP, int maxMP, int atk, int def, int spd, int intel, int res, int evd, int exp, int gold)
    {
       Random random = new Random();  
      Name = name;
      Level = lvl;
      MaxHP = maxHP;
      MaxMP = maxMP;
      HP = maxHP;
      MP = maxMP;
      ATK = atk;
      DEF = def;
      SPD = random.Next((int)(spd/2), spd);
      INT = intel;
      RES = res;
      EVD = evd;
      EXP = exp;
      Gold = gold;

      //Console.WriteLine("Player: " + name + "- Speed: " + SPD);
    }
    public string GetName()
    {
      return Name;
    }
    public void SetName(string name)
    {
      Name = name;
    }
    public int GetLevel()
    {
      return Level;
    }
    public int GetMaxHP()
    {
      return MaxHP;
    }
    public int GetMaxMP()
    {
      return MaxMP;
    }
    public int GetHP()
    {
      return HP;
    }
    public void SetHP(int hp)
    {
       HP = hp;
    }
        public int GetMP()
    {
      return MP;
    }
    public int GetATK()
    {
      return ATK;
    }
    public int GetDEF()
    {
      return DEF;
    }
    public int GetSPD()
    {
      return SPD;
    }
    public int GetINT()
    {
      return INT;
    }
    public int GetRES()
    {
      return RES;
    }
    public int GetEVD()
    {
      return EVD;
    }
    public int GetEXP()
    {
      return EXP;
    }
    public int GetGold()
    {
      return Gold;
    }
    public List<SpellsAndSkills> GetSpellsAndSkillsList()
    {
      return SpellsAndSkillsList;
    }
    public SpellsAndSkills GetSpellsAndSkills(int Choice)
    {
    
      return SpellsAndSkillsList[Choice];
    }
    protected void AddSpellandSkill(SpellsAndSkills SpellAndSkill)
    {
      SpellsAndSkillsList.Add(SpellAndSkill);
    }
  }
  public class EnemyObject : BaseObject
  {
    public int ID = 0;
    public EnemyObject(string name, int lvl, int maxHP, int maxMP, int atk, int def, int spd, int intel, int res, int evd, int exp, int gold, int id = 0) : base(name, lvl, maxHP, maxMP, atk, def, spd, intel, res, evd, exp, gold)
    {
    }
    public EnemyObject() : base()
    {

    }
    public int GetID()
    {
      return ID;
    }
    public void SetID(int id)
    {
      ID = id;
    }
  }

  public class PlayerObject : BaseObject
  {
    public PlayerObject(string name, int lvl, int maxHP, int maxMP, int atk, int def, int spd, int intel, int res, int evd, int exp, int gold) : base(name, lvl, maxHP, maxMP, atk, def, spd, intel, res, evd, exp, gold)
    {
      
    }
    public PlayerObject() : base()
    {

    }
  }
  
  public class Player1 : PlayerObject
  {
    public Player1(string name, int lvl, int maxHP, int maxMP, int atk, int def, int spd, int intel, int res, int evd, int exp, int gold) : base(name, lvl, maxHP, maxMP, atk, def, spd, intel, res, evd, exp, gold)
    {
      base.AddSpellandSkill(new FireBall());
      base.AddSpellandSkill(new Icebolt());
      base.AddSpellandSkill(new Lightningbolt());
    }
  }
   public class Player2 : PlayerObject
  {
    public Player2(string name, int lvl, int maxHP, int maxMP, int atk, int def, int spd, int intel, int res, int evd, int exp, int gold) : base(name, lvl, maxHP, maxMP, atk, def, spd, intel, res, evd, exp, gold)
    {
      base.AddSpellandSkill(new FireBall());

    }
  }
   public class Player3 : PlayerObject
  {
    public Player3(string name, int lvl, int maxHP, int maxMP, int atk, int def, int spd, int intel, int res, int evd, int exp, int gold) : base(name, lvl, maxHP, maxMP, atk, def, spd, intel, res, evd, exp, gold)
    {

      base.AddSpellandSkill(new Icebolt());
     
    }
  }
   public class Player4 : PlayerObject
  {
    public Player4(string name, int lvl, int maxHP, int maxMP, int atk, int def, int spd, int intel, int res, int evd, int exp, int gold) : base(name, lvl, maxHP, maxMP, atk, def, spd, intel, res, evd, exp, gold)
    {

      base.AddSpellandSkill(new Lightningbolt());
    }
  }

    public class SlimeObject : EnemyObject
  {
    public SlimeObject() : base("Slime", 1, 3, 4, 4, 3, 32, 1, 2, 1, 3, 4)
    {
    }
  }
   public class RedSlimeObject : EnemyObject
  {
    public RedSlimeObject() : base("Red Slime", 1, 4, 4, 4, 3, 2, 1, 2, 1, 3, 4)
    {
    }
  }
    public class DrakeeObject : EnemyObject
  {
    public DrakeeObject() : base("Drakee", 1, 9, 4, 6, 3, 33, 1, 2, 1, 3, 4)
    {
    }
  }
      public class GhostObject : EnemyObject
  {
    public GhostObject() : base("Ghost", 1, 11, 4, 6, 3, 2, 1, 2, 1, 3, 4)
    {
    }
  }
}