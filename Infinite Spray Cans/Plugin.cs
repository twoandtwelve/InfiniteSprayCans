using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteSprayCans
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class InfiniteSprayCans : BaseUnityPlugin
    {
        private const string modGUID = "Jacky.InfiniteSprayCans";
        private const string modName = "Infinite Spray Cans";
        private const string modVersion = "1.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static InfiniteSprayCans Instance;

        internal ManualLogSource mls;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("The mod has awaken");

            harmony.PatchAll();
        }
    }
}
