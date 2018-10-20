using System;
using System.Collections.Generic;
namespace Battle
{
  public static class Debug
  {
    public static void CheckPlayerObjects(List<PlayerObject> PlayerObjectList)
    {
      Console.WriteLine("\nActivated Debug.CheckPlayerObjects: \n"); 
      foreach(PlayerObject Obj in PlayerObjectList)
      {
          Console.WriteLine(Obj.GetName()); 
      }
      Console.WriteLine("\n");
    }
    public static void CheckEnemyObjects(List<EnemyObject> EnemyObjectList)
    {
      Console.WriteLine("\nActivated Debug.CheckEnemiesObjects: \n"); 
      foreach(EnemyObject Obj in EnemyObjectList)
      {
          Console.WriteLine(Obj.GetName()); 
      }
      Console.WriteLine("\n");
    }
    public static void CheckBaseObjects(List<BaseObject> BaseObjectList)
    {
      Console.WriteLine("\nActivated Debug.CheckBaseObjects: \n"); 
      foreach(BaseObject Obj in BaseObjectList)
      {
          Console.WriteLine(Obj.GetName()); 
      }
      Console.WriteLine("\n");
    }
    public static void CheckObjectType(List<BaseObject> FullObjectList)
    {
      Console.WriteLine("\n Activated Debug.CheckObjectType: \n"); 
      foreach(BaseObject Obj in FullObjectList)
      {
        if(Obj is PlayerObject)
        {
          Console.WriteLine("PLayer Object: " + Obj.GetName()); 
        }
        else if(Obj is EnemyObject)
        {
          Console.WriteLine("Enemy Object: " + Obj.GetName());
        }
      }

      Console.WriteLine("\n");
    }
    public static void SelectObject(List<BaseObject> FullObjectList)
    {
      Console.WriteLine("\nActivated Debug.SelectObject: \n"); 
      int choices = 1; //Since most people don't count starting with 0, the count starts at 1.
      foreach(BaseObject Obj in FullObjectList)
      {
        if(Obj is PlayerObject)
        {
          Console.WriteLine(choices + ": " + Obj.GetName() + " - PlayerObject");
        }
        else
        {
          Console.WriteLine(choices + ": " + Obj.GetName() + " - EnemyObject");
        }
        choices += 1;
      }
      try
      {
        GetStatsBaseObject(FullObjectList[Int32.Parse(Console.ReadLine())-1]); 
      }
      catch(ArgumentOutOfRangeException)
      {
        Console.WriteLine("\nSelct a object that exists\n");
        Debug.SelectObject(FullObjectList);
      }
      catch(FormatException)
      {
        Console.WriteLine("\nSelct a object that exists\n");
        Debug.SelectObject(FullObjectList);
      }
    }
    public static void GetStatsBaseObject(BaseObject baseobject)
    {
      Console.WriteLine("\nActivated Debug.GetStatsBaseObject: \n"); 
      Console.WriteLine(baseobject.GetName());
      Console.WriteLine("LV: " + baseobject.GetLevel());
      Console.WriteLine("HP: " + baseobject.GetHP() + " / " + baseobject.GetMaxHP());
      Console.WriteLine("MP: " + baseobject.GetMP() + " / " + baseobject.GetMaxMP());
      Console.WriteLine("ATK: " + baseobject.GetATK());
      Console.WriteLine("DEF: " + baseobject.GetDEF());
      Console.WriteLine("SPD: " + baseobject.GetSPD());
      Console.WriteLine("INT: " + baseobject.GetINT());
      Console.WriteLine("RES: " + baseobject.GetRES());
      Console.WriteLine("EVD: " + baseobject.GetEVD());
      Console.WriteLine("EXP: " + baseobject.GetEXP());
      Console.WriteLine("Gold: " + baseobject.GetGold() + "\n");
    }
    public static void GetEnemyStatsBaseObject(List<EnemyObject> EnemyObj)
    {
      Console.WriteLine("Activated Debug.GetEnemyStatsBaseObject: \n"); 
       foreach(EnemyObject Obj in EnemyObj)
      {

        Console.WriteLine(Obj.GetName());
        Console.WriteLine("LV: " + Obj.GetLevel());
        Console.WriteLine("HP: " + Obj.GetHP() + " / " + Obj.GetMaxHP());
        Console.WriteLine("MP: " + Obj.GetMP() + " / " + Obj.GetMaxMP());
        Console.WriteLine("ATK: " + Obj.GetATK());
        Console.WriteLine("DEF: " + Obj.GetDEF());
        Console.WriteLine("SPD: " + Obj.GetSPD());
        Console.WriteLine("INT: " + Obj.GetINT());
        Console.WriteLine("RES: " + Obj.GetRES());
        Console.WriteLine("EVD: " + Obj.GetEVD());
        Console.WriteLine("EXP: " + Obj.GetEXP());
        Console.WriteLine("Gold: " + Obj.GetGold() + "\n\n");
      }
    }
  }
}