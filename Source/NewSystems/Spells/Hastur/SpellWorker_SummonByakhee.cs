﻿using System;
using System.Collections.Generic;
using System.Linq;
using Verse;
using Verse.AI.Group;
using RimWorld;
using RimWorld.Planet;
using System.Text;

namespace CultOfCthulhu
{
    public class SpellWorker_SummonByakhee : SpellWorker
    {
        
        public override bool CanSummonNow(Map map)
        {
            return true;
        }

        protected override bool CanFireNowSub(IncidentParms parms)
        {
            //Cthulhu.Utility.DebugReport("CanFire: " + this.def.defName);
            return true;
        }


        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = parms.target as Map;
            IntVec3 intVec;
            //Find a drop spot
            if (!CultUtility.TryFindDropCell(map.Center, map, 70, out intVec))
            {
                return false;
            }
            parms.spawnCenter = intVec;
            Cthulhu.Utility.SpawnPawnsOfCountAt(CultsDefOf.Cults_Byakhee, intVec, map, 1, Faction.OfPlayer);

            map.GetComponent<MapComponent_SacrificeTracker>().lastLocation = intVec;
            return true;
        }

    }
}
