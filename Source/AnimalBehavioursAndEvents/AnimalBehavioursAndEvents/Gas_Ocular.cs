﻿using RimWorld;
using Verse;
using System;
using System.Collections.Generic;

namespace AlphaBehavioursAndEvents
{
    public class Gas_Ocular : Gas
    {
        private int tickerInterval = 0;
        private int tickerMax = 64;
        private System.Random rand = new System.Random();




        public override void Tick()
        {
            base.Tick();
            try
            {
                if (tickerInterval >= tickerMax)
                {

                    HashSet<Thing> hashSet = new HashSet<Thing>(this.Position.GetThingList(this.Map));
                    if (hashSet != null)
                    {
                        foreach (Thing current in hashSet)
                        {
                            PlantProperties plant = current.def.plant;
                            bool flag = (plant != null);
                            if (flag)
                            {
                               if (plant.IsTree && (current.def.defName != "GU_AlienTree"))
                               {
                                    Plant thing2 = (Plant)GenSpawn.Spawn(ThingDef.Named("GU_AlienTree"), this.Position, this.Map, WipeMode.Vanish);
                                    Plant thingToDestroy = (Plant)current;
                                    thing2.Growth = thingToDestroy.Growth;
                                    current.Destroy();
                               } else if (!plant.IsTree && (current.def.defName != "GU_AlienGrass")&&(current.def.defName != "GU_RedLeaves") && (current.def.defName != "GU_RedPlantsTall"))
                                {
                                    if (rand.NextDouble() < 0.4)
                                    {
                                        Plant thing2 = (Plant)GenSpawn.Spawn(ThingDef.Named("GU_AlienGrass"), this.Position, this.Map, WipeMode.Vanish);
                                        Plant thingToDestroy = (Plant)current;
                                        thing2.Growth = thingToDestroy.Growth;
                                        current.Destroy();
                                    } else if (rand.NextDouble() > 0.4 && rand.NextDouble() < 0.7)
                                    {
                                        Plant thing2 = (Plant)GenSpawn.Spawn(ThingDef.Named("GU_RedLeaves"), this.Position, this.Map, WipeMode.Vanish);
                                        Plant thingToDestroy = (Plant)current;
                                        thing2.Growth = thingToDestroy.Growth;
                                        current.Destroy();
                                    }
                                    else if (rand.NextDouble() > 0.7)
                                    {
                                        Plant thing2 = (Plant)GenSpawn.Spawn(ThingDef.Named("GU_RedPlantsTall"), this.Position, this.Map, WipeMode.Vanish);
                                        Plant thingToDestroy = (Plant)current;
                                        thing2.Growth = thingToDestroy.Growth;
                                        current.Destroy();
                                    }
                                }


                            }
                        }

                    }
                    tickerInterval = 0;



                }
                tickerInterval++;
            }
            catch (NullReferenceException e)
            {
                //A weird error is produced sometimes when GetThingList returns a NullReferenceException. I did a try-catch which is inellegant, but it works
            }

        }


    }
}
