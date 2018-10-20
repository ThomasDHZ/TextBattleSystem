using System;
using System.Collections.Generic;

namespace Battle
{
  public class BattleSystem
  {
    const int ChoiceMin = 1;
    const int ChoiceMax = 4;

    public bool EndGameFlag = false;
    public bool PlayerTurn = true;

    List<BaseObject> BaseObjectList = new List<BaseObject>();
    List<PlayerObject> PlayerObjList = new List<PlayerObject>();
    List<EnemyObject> EnemyObjList = new List<EnemyObject>();
    int Choice = 0;

    bool DebugMenuFlag = false;

    public BattleSystem()
    {
      Player1 Player1Obj = new Player1("Player1", 1, 10, 7, 50, 4, 23, 4, 3, 2, 0, 50);
      Player2 Player2Obj = new Player2("Player2", 1, 10, 7, 50, 4, 32, 4, 3, 2, 0, 50);
      Player3 Player3Obj = new Player3("Player3", 1, 10, 7, 50, 4, 43, 4, 3, 2, 0, 50);
      Player4 Player4Obj = new Player4("Player4", 1, 10, 7, 50, 4, 12, 4, 3, 2, 0, 50);

      BaseObjectList.Add(Player1Obj);
      BaseObjectList.Add(Player2Obj);
      BaseObjectList.Add(Player3Obj);
      BaseObjectList.Add(Player4Obj);
      BaseObjectList.Add(new SlimeObject());
      BaseObjectList.Add(new SlimeObject());
      BaseObjectList.Add(new DrakeeObject());
      BaseObjectList.Add(new DrakeeObject());
      
      SortBySpeed();
      UpdateObjectLists();
      SetEnemyIDs();

      foreach(EnemyObject obj in EnemyObjList)
      {
        if(obj is EnemyObject)
        {
          Menus.EnemyAppears(obj);
        }
      }
      Console.WriteLine("\n");
    }
    public void SortBySpeed()
    {
      for(int x = 0; x <= BaseObjectList.Count - 1; x++)
      {
        if(x+1 <= BaseObjectList.Count - 1)
        {
          if(BaseObjectList[x].GetSPD() < BaseObjectList[x+1].GetSPD())
          {
            BaseObject TempBaseObject = BaseObjectList[x];
            BaseObjectList[x] = BaseObjectList[x+1];
            BaseObjectList[x+1] = TempBaseObject;
            x=0;
          }
        }
      }
     /* int count = 0;
      foreach(BaseObject Obj in BaseObjectList)
      {
        Console.WriteLine(count + ": "+ "Player: " + Obj.GetName() + " - Speed: " + Obj.GetSPD());
        count++;
      }
      Console.WriteLine("\n");*/
    }
    public void Update()
    {
      Choice = 0;
      
      CheckForDead();
      UpdateObjectLists();

      Console.WriteLine(BaseObjectList[0].GetName() + "'s Turn: \n\n\n");

      if(PlayerTurn == true)
      {
        if(DebugMenuFlag == false)
        {
          Menus.PlayerMenu();
          try
          {
            Choice = Int32.Parse(Console.ReadLine());
          }
          catch(FormatException){ }

          switch(Choice)
          {
            case 0: 
            {
              Update(); 
              break;
            }
            case 1: 
            {
              Menus.FightMenu(EnemyObjList); 
              AttackCreature(); 
              NextTurn(); 
              break;
            }
            case 2: 
            {
              int Spell = Menus.MagicMenu(PlayerObjList[0]); 
              Menus.FightMenu(EnemyObjList);
              AttackCreature(PlayerObjList[0], Spell);
              NextTurn(); 
              break;
            }
            case 3: Console.WriteLine ("Good"); break;
            case 4: Console.WriteLine ("Good"); break;
            case 5: DebugMenuFlag = true; break;
            default: Console.WriteLine("Select from the choices.\n"); break;
          }
      }
      else
      {
        Menus.DebugMenu();
        try
        {
          Choice = Int32.Parse(Console.ReadLine());
        }
        catch(FormatException){ }

        Console.WriteLine("\n");

        switch(Choice)
        {
          case 1: Debug.SelectObject(BaseObjectList); break;
          case 2: Debug.GetEnemyStatsBaseObject(EnemyObjList); break;
          case 3: Debug.CheckPlayerObjects(PlayerObjList); break;
          case 4: Debug.GetStatsBaseObject(BaseObjectList[6]); break;
          case 5: NextTurn(); break;
          case 6: DebugMenuFlag = false; break;
          default: Console.WriteLine("Select from the choices.\n"); break;
        }
       }
    
      }
      else
      {
        CalcDamage(BaseObjectList[0], PlayerObjList[0]);
        NextTurn();
      }
    }
    private void UpdateObjectLists()
    {
      PlayerObjList.Clear();
      EnemyObjList.Clear();
      
      foreach(BaseObject Obj in BaseObjectList)
      {
        if(Obj is PlayerObject)
        {
          PlayerObjList.Add((PlayerObject)Obj);
        }
        else if(Obj is EnemyObject)
        {
          EnemyObjList.Add((EnemyObject)Obj);
        }
      }
    }
    public void NextTurn()
    {
     
//      EnemyObject TempEnemyObject = new EnemyObject();
  //    PlayerObject TempPlayerObject = new PlayerObject();
      BaseObject TempObject = new BaseObject();

      int count = 1; 
     /*foreach(BaseObject obj in BaseObjectList)
      {
        Console.WriteLine(count + ": " + obj.GetName());
        count++;
      }*/

   //   if(BaseObjectList[0] is EnemyObject)
   //   {
        TempObject = BaseObjectList[0];
        BaseObjectList.Remove(BaseObjectList[0]);
        BaseObjectList.Add(TempObject);

      
     /* }
      else if(BaseObjectList[0] is PlayerObject)
      {
        TempPlayerObject = PlayerObject;
        BaseObjectList.Remove(BaseObjectList[0]);
        BaseObjectList.Add(PlayerObject);
      }*/

      //Console.WriteLine("\n\n\n\n\n\n\n\n\n");
      count = 0;
      foreach(BaseObject obj in BaseObjectList)
      {
        Console.WriteLine(count + ": " + obj.GetName());
        count++;
      }

      if(BaseObjectList[0] is PlayerObject)
      {
        PlayerTurn = true;
      }
      else if(BaseObjectList[0] is EnemyObject)
      {
        PlayerTurn = false;
      }
      else
      {
        Console.WriteLine("NextTurn() Error");
      }
    }
    public void AttackCreature()
    {
      Choice = Int32.Parse(Console.ReadLine());
      if(Choice >= 1 && Choice <= EnemyObjList.Count)
      {
        CalcDamage(PlayerObjList[0], EnemyObjList[Choice - 1]);
      }
      else
      {
        Console.WriteLine ("Not a good choice.");
        Menus.FightMenu(EnemyObjList);
        AttackCreature();//If the player makes a invaild choice, he function loops.
      }
    }
    public void AttackCreature(BaseObject Attacker, int Spell)
    {
      Choice = Int32.Parse(Console.ReadLine());
      if(Choice >= 1 && Choice <= EnemyObjList.Count)
      {
        CheckForSpell(Attacker, Spell, Choice);
      }
      else
      {
        Console.WriteLine ("Not a good choice.");
      }
    }
    public void CheckForSpell(BaseObject Attacker, int Spell, int MonsterSeleced)
    {
      try
      {
        if(Attacker.GetSpellsAndSkills(Spell) is FireBall)
        {
          FireBall temp = new FireBall();
          temp.UseFireBall(Attacker,EnemyObjList[MonsterSeleced]);
        }
        else if(Attacker.GetSpellsAndSkills(Spell) is Icebolt)
        {
          Icebolt temp = new Icebolt();
          temp.UseIcebolt(Attacker,EnemyObjList[MonsterSeleced]);
        }
        else if(Attacker.GetSpellsAndSkills(Spell) is Lightningbolt)
        {
          Lightningbolt temp = new Lightningbolt();
          temp.UseLightningbolt(Attacker,EnemyObjList[MonsterSeleced]);
        }
      }
      catch(ArgumentOutOfRangeException)
      {
        Console.WriteLine("Spell not found, add in spell.");
      }
    }
    public void SetEnemyIDs()
    {
      int SlimeCounter = 0;
      int RedSlimeCounter = 0;
      int DrakeeCounter = 0;
      int GhostCounter = 0;
      foreach(EnemyObject obj in EnemyObjList)
      {
        if(obj is SlimeObject)
        {
          obj.SetID(SlimeCounter);
          obj.SetName(obj.GetName() + RandomFunctions.ConvertNumbersToLetters(SlimeCounter));
          SlimeCounter++;
        }
        else if(obj is RedSlimeObject)
        {
          obj.SetID(RedSlimeCounter);
          obj.SetName(obj.GetName() + RandomFunctions.ConvertNumbersToLetters(RedSlimeCounter));
          RedSlimeCounter++;
        }
        else if(obj is DrakeeObject)
        {
          obj.SetID(DrakeeCounter);
          obj.SetName(obj.GetName() + RandomFunctions.ConvertNumbersToLetters(DrakeeCounter));
          DrakeeCounter++;
        }
        else if(obj is GhostObject)
        {
          obj.SetID(GhostCounter);
          obj.SetName(obj.GetName() + RandomFunctions.ConvertNumbersToLetters(GhostCounter));
          GhostCounter++;
        }
        else
        {
          Console.WriteLine("Enemy not found, add in enemy.");
        }
      }
    }
    public void CheckForDead()
    {
        foreach(BaseObject obj in BaseObjectList)
        {
            if(obj.GetHP() <= 0)
            {
               if(obj == BaseObjectList[0])
               {
                 NextTurn();
               }
               Console.WriteLine(obj.GetName() + " has died!\n");
               BaseObjectList.Remove(obj);
             // Debug.CheckBaseObjects(BaseObjectList);
               break;
            }
        }
    }
    public void CalcDamage(BaseObject Attacker, BaseObject Defender)
    {
      if(Defender is EnemyObject)
      {
        foreach(EnemyObject obj in EnemyObjList)
        {
          if(obj == Defender)
          {
            int Damage = (Attacker.GetATK() - obj.GetDEF()); 

            Console.WriteLine(Attacker.GetName() + " attacks!");
            Defender.SetHP(Defender.GetHP() - (Attacker.GetATK() - obj.GetDEF()));
            Console.WriteLine(obj.GetName() + " has taken " + Damage + " damage!\n");
          }
        }
      }
      else if(Defender is PlayerObject)
      {
        foreach(PlayerObject obj in PlayerObjList)
        {
          if(obj == Defender)
          {
            int Damage = (Attacker.GetATK() - obj.GetDEF()); 

            Console.WriteLine(Attacker.GetName() + " attacks!");
            Defender.SetHP(Defender.GetHP() - (Attacker.GetATK() - obj.GetDEF()));
            Console.WriteLine(obj.GetName() + " has taken " + Damage + " damage!\n");
          }
          
        }
      }
      Menus.NextLine();
    }
  }
}