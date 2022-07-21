using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;

namespace LargerBoard
{

    [BepInPlugin("de.benediktwerner.stacklands.largerboard", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private static ConfigEntry<float> maxSize;

        private void Awake()
        {
            maxSize = Config.Bind("General", "Max World Size", 5f, "The original max size in vanilla is 2.5");

            Harmony.CreateAndPatchAll(typeof(Plugin));
        }

        [HarmonyPatch(typeof(WorldManager), "DetermineTargetWorldSize")]
        [HarmonyPrefix]
        private static void WorldManager__DetermineTargetWorldSize__Prefix(ref bool __runOriginal, WorldManager __instance, GameBoard board, out float __result)
        {
            __runOriginal = false;
            __result = Mathf.Clamp((float)__instance.CardCapIncrease(board) * 0.03f, 0.15f, maxSize.Value);
        }
    }
}
