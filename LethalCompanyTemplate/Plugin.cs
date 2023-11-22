using BepInEx;
using HarmonyLib;
using LC_API.BundleAPI;
using UnityEngine;

namespace LCFartLizards
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private Harmony harmony;

        public static AudioClip audioClip;

        public void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");

            harmony = new Harmony("LCFartLizards");
            harmony.PatchAll();
        }

        public static bool audioClipPlayed = false;

        [HarmonyPatch(typeof(PufferAI), "Start")]
        public class PufferAIPatch
        {
            public static void Postfix(PufferAI __instance)
            {
                AudioClip audioClip = BundleLoader.GetLoadedAsset<AudioClip>("assets/LizardSound.mp3");
                __instance.puff = audioClip;
            }
        }
    }
}