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
                4.5f,
                "This is the max size using just sheds and warehouses. The original max size in vanilla is 4.5"
            );
            maxSizeLighthouses = CreateConfig(
                "Max Lighthouses World Size",
                15f,
                "The original max size in vanilla is 7.5"
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
            var min = Mathf.Max(0.15f, board.PackLineWidth - 8.86f);
            __result = __instance.CardCapIncrease(board) * 0.05f;
            __result = Mathf.Clamp(__result, min, maxSizeWarehouses.Value);
            __result += __instance.BoardSizeIncrease(board) * 0.05f;
            __result = Mathf.Clamp(__result, min, maxSizeLighthouses.Value);
        }
    }
}
