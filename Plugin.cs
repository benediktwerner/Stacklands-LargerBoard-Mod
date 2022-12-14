using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace LargerBoard
{
    [BepInPlugin("de.benediktwerner.stacklands.largerboard", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private static ConfigEntry<float> maxSizeWarehouses;
        private static ConfigEntry<float> maxSizeLighthouses;

        private void Awake()
        {
            maxSizeWarehouses = Config.Bind("General", "Max World Size", 2.5f, "This is the max size using just sheds and warehouses. The original max size in vanilla is 2.5");
            maxSizeLighthouses = Config.Bind("General", "Max Lighthouses World Size", 10f, "The original max size in vanilla is 5.55");

            Harmony.CreateAndPatchAll(typeof(Plugin));
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
