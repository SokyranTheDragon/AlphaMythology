﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using HarmonyLib;
using Verse;
using RimWorld;
using RimWorld.Planet;

namespace AchievementsExpanded
{
    public class MagicalMenagerie_QuestManager_Notify_ThingsProduced_Patch
    {

        public static void CheckItemCraftedIngredients(Pawn worker, List<Thing> things)
        {
            if (things != null && worker != null)
            {
                foreach (var card in AchievementPointManager.GetCards<ItemCraftTrackerWithIngredientsMagicalMenagerie>())
                {

                    foreach (Thing thing in things)
                    {
                        if (thing != null && card != null)
                        {
                            if ((card.tracker as ItemCraftTrackerWithIngredientsMagicalMenagerie).Trigger(thing))
                            {
                                card.UnlockCard();
                            }
                        }

                    }
                }
            }

        }
    }
}
