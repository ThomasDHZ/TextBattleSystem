using System;
using System.Collections.Generic;

namespace Battle
{
 public static class Menus
  {
    public static void ChooseFromObjectList(List<BaseObject> ObjList)
    {
      int num = 1; //Since most people don't count starting with 0, the count starts at 1.
      foreach(BaseObject Obj in ObjList)
      {
        Console.WriteLine(num + ": " + Obj.GetName());
        num++;
      }
      Console.WriteLine("\n");
    }
    public static void ChooseFromObjectList(List<PlayerObject> ObjList)
    {
      int num = 1; //Since most people don't count starting with 0, the count starts at 1.
      foreach(PlayerObject Obj in ObjList)
      {
        Console.WriteLine(num + ": " + Obj.GetName());
        num++;
      }
      Console.WriteLine("\n");
    }
     public static void ChooseFromObjectList(List<EnemyObject> ObjList)
    {
      int num = 1; //Since most people don't count starting with 0, the count starts at 1.
      foreach(EnemyObject Obj in ObjList)
      {
        Console.WriteLine(num + ": " + Obj.GetName());
        num++;
      }
      Console.WriteLine("\n");
    }
    
    public static void NextLine()
    {
      Console.WriteLine("\nPress Enter\n");
      Console.ReadLine();
    }
    public static void EnemyAppears(BaseObject EnemyObj)
    {
      Console.WriteLine("A wild " + EnemyObj.GetName() + " appears!");
    }
    public static void PlayerMenu()
    {
        Console.WriteLine("1. Fight");
        Console.WriteLine("2. Magic");
        Console.WriteLine("3. Item");
        Console.WriteLine("4. Run");
        Console.WriteLine("5. Debug Menus");
    }
    public static int MagicMenu(PlayerObject Obj)
    {
      int count = 1; //Since most people don't count starting with 0, the count starts at 1.
      int ChoseSpell = 0;

      Console.WriteLine("\n" + Obj.GetName() + "'s Spells:\n");
      foreach(SpellsAndSkills skills in Obj.GetSpellsAndSkillsList())
      {
        Console.WriteLine(count + ": " + skills.GetName());
        count++;
      }

      ChoseSpell = Int32.Parse(Console.ReadLine()); 
      ChoseSpell--;
      try
      {
        if(Obj.GetSpellsAndSkills(ChoseSpell) != null)
        {
          return ChoseSpell;
        }
      }
      catch(FormatException)
      { 
        Console.WriteLine("Choice a spell from the menu.");
        MagicMenu(Obj);
      }
      catch(ArgumentOutOfRangeException)
      { 
        Console.WriteLine("Choice a spell from the menu.");
        MagicMenu(Obj);
      }
      return 0;
    }
    public static void DebugMenu()
    {
        Console.WriteLine("1. Check Object Stats");
        Console.WriteLine("2. Check Enemy Stats");
        Console.WriteLine("3. Check Player Objects");
        Console.WriteLine("4. Run");
        Console.WriteLine("5. NextTurn()");
        Console.WriteLine("6. Debug Menus");
    }
    public static void FightMenu(List<EnemyObject> ObjList)
    {
      Console.WriteLine("\n");
      ChooseFromObjectList(ObjList);
      Console.WriteLine("Attack which creature?\n");
    }
    public static void GetHPStats(List<EnemyObject> Obj)
    {
       foreach(EnemyObject obj in Obj)
      {
        Console.WriteLine(obj.GetName() + ": HP " + obj.GetHP());
      }
    }
  }
}