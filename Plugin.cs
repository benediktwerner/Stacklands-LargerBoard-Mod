using HarmonyLib;
using UnityEngine;

namespace LargerBoard
{
    public class Plugin : Mod
    {
        private static ConfigEntry<float> maxSizeWarehouses;
        private static ConfigEntry<float> maxSizeLighthouses;

        private ConfigEntry<T> CreateConfig<T>(string name, T defaultValue, string description)
        {
            return Config.GetEntry<T>(name, defaultValue, new ConfigUI { Tooltip = description });
        }

        private void Awake()
        {
            maxSizeWarehouses = CreateConfig(
                "Max World Size",
                2.5f,
                "This is the max size using just sheds and warehouses. The original max size in vanilla is 2.5"
            );
            maxSizeLighthouses = CreateConfig(
                "Max Lighthouses World Size",
                10f,
                "The original max size in vanilla is 5.55"
            );

            Harmony.PatchAll(typeof(Plugin));
        }

        [HarmonyPatch(typeof(WorldManager), nameof(WorldManager.DetermineTargetWorldSize))]
        [HarmonyPrefix]
        private static void DetermineTargetWorldSize(
            ref bool __runOriginal,
            WorldManager __instance,
            GameBoard board,
            out float __result
        )
        {
            __runOriginal = false;
            __result = __instance.CardCapIncrease(board) * 0.03f;
            __result = Mathf.Clamp(__result, 0.15f, maxSizeWarehouses.Value);
            __result += __instance.BoardSizeIncrease(board) * 0.03f;
            __result = Mathf.Clamp(__result, 0.15f, maxSizeLighthouses.Value);
        }
    }
}
