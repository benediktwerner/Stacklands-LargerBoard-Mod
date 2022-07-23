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

        [HarmonyPatch(typeof(WorldManager), nameof(WorldManager.DetermineTargetWorldSize))]
        [HarmonyPrefix]
        private static void DetermineTargetWorldSize(ref bool __runOriginal, WorldManager __instance, GameBoard board, out float __result)
        {
            __runOriginal = false;
            __result = Mathf.Clamp(__instance.CardCapIncrease(board) * 0.03f, 0.15f, maxSize.Value);
        }

        private static GameBoard currentBoard = null;
        private static Material currentBoardMaterial = null;

        [HarmonyPatch(typeof(GameBoard), nameof(GameBoard.Update))]
        [HarmonyPrefix]
        private static void FixShader(GameBoard __instance)
        {
            if (__instance.IsCurrent)
            {
                if (currentBoard != __instance)
                {
                    currentBoard = __instance;
                    currentBoardMaterial = __instance.GetComponent<MeshRenderer>().material;
                }
                if (currentBoard.WorldSizeIncrease < 2.5f)
                {
                    currentBoardMaterial.SetVector("_Rect", new Vector4(4.3f, 0, 2.47f, -0.43f));
                }
                else
                {
                    currentBoardMaterial.SetVector("_Rect", new Vector4(1.8f + currentBoard.WorldSizeIncrease, 0, currentBoard.WorldSizeIncrease, -0.43f));
                }
            }
        }
    }
}
