using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace InfiniteSprayCans.Patches
{
    [HarmonyPatch(typeof(SprayPaintItem))]

    internal class SprayPaintItemPatch
    {
        [HarmonyPatch("LateUpdate")]
        [HarmonyPostfix]
        static void infiniteSprayCansPatch(ref float ___sprayCanTank, ref float ___sprayCanShakeMeter)
        {
            if (InfiniteSprayCans.Instance.isInfiniteTankEnabledEntry.Value) { 
                ___sprayCanTank = 1f;
            }
            if (InfiniteSprayCans.Instance.isNoShakeEnabledEntry.Value) { 
                ___sprayCanShakeMeter = 1f;
            }
        }
    }
}
