using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using InfiniteSprayCans.Patches;
using LethalConfig;
using LethalConfig.ConfigItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfiniteSprayCans
{
    [BepInPlugin(modGUID, modName, modVersion)]
    [BepInDependency("ainavt.lc.lethalconfig")]
    public class InfiniteSprayCans : BaseUnityPlugin
    {
        private const string modGUID = "Jacky.InfiniteSprayCans";
        private const string modName = "InfiniteSprayCans";
        private const string modVersion = "1.0.2";

        private readonly Harmony harmony = new Harmony(modGUID);

        public static InfiniteSprayCans Instance;

        internal ManualLogSource logger;

        public ConfigEntry<bool> isInfiniteTankEnabledEntry;
        public ConfigEntry<bool> isNoShakeEnabledEntry;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            logger.LogInfo("InfiniteSprayCas mod has awaken");

            isInfiniteTankEnabledEntry = Config.Bind("Infinite Spray Cans Config", "Enable Infinite Spray Can Tank", true, "This enables the spray can to be used infinitely!");
            isNoShakeEnabledEntry = Config.Bind("Infinite Spray Cans Config", "Enable No Shake Spray Can", true, "This enables the spray can to be used without needing to shake it!");

            BaseConfigItem isInfiniteTankEnabled = new BoolCheckBoxConfigItem(isInfiniteTankEnabledEntry, requiresRestart: false);
            BaseConfigItem isNoShakeEnabled = new BoolCheckBoxConfigItem(isNoShakeEnabledEntry, requiresRestart: false);

            LethalConfigManager.AddConfigItem(isInfiniteTankEnabled);
            LethalConfigManager.AddConfigItem(isNoShakeEnabled);

            harmony.PatchAll(typeof(SprayPaintItemPatch));
        }
    }
}
