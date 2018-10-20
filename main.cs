dotusing System;
using System.Collections.Generic;

namespace Battle
{
  class MainClass
  { 
    public static void Main (string[] args) 
    {   
      BattleSystem BS = new BattleSystem();
      while(BS.EndGameFlag == false)
      {
        BS.Update();
      }
    }
  }
}