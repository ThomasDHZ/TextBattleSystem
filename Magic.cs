using System;
using System.Collections.Generic;

namespace Battle
{
  public class SpellsAndSkills
  {
    string Name;
    public SpellsAndSkills(string name)
    {
      Name = name;
    }
    public string GetName()
    {
      return Name;
    }
  }
  public class MagicSpells : SpellsAndSkills
  {
    public MagicSpells(string name) : base(name)
    {

    }
    public void MagicDamage(float MagicModifier, BaseObject Attacker, BaseObject Defender)
    {
        float AttakerMagicPower = Attacker.GetINT() * MagicModifier;
        int DefenderResistance = Defender.GetRES();
        int Damage = 0;
        
        Damage = (int)Math.Round(AttakerMagicPower - DefenderResistance);
        Console.WriteLine(Defender.GetName() + " has taken " + Damage + " damage!\n");
        Defender.SetHP(Defender.GetHP() - Damage);
        Console.WriteLine(Defender.GetName() + " has " + Defender.GetHP() + " left");
    }
  }
  public class FireBall : MagicSpells
  {
    public FireBall() : base("FireBall")
    {}

    public void UseFireBall(BaseObject Attacker, BaseObject Defender)
    {
      Console.WriteLine(Attacker.GetName() + " used FireBall.");
      base.MagicDamage(1.3f,Attacker,Defender);
    }
  }
  public class Icebolt : MagicSpells
  {
    public Icebolt() : base("Icebolt")
    {}

    public void UseIcebolt(BaseObject Attacker, BaseObject Defender)
    {
      Console.WriteLine(Attacker.GetName() + " used Icebolt.");
      base.MagicDamage(1.2f,Attacker,Defender);
    }
  }
  public class Lightningbolt : MagicSpells
  {
    public Lightningbolt() : base("Lightningbolt")
    {}

    public void UseLightningbolt(BaseObject Attacker, BaseObject Defender)
    {
      Console.WriteLine(Attacker.GetName() + " used Lightningbolt.");
      base.MagicDamage(1.2f,Attacker,Defender);
    }
  }
}