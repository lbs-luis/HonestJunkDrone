using BepInEx;
using BepInEx.Logging;
using HonestJunkDrone.Hooks;

namespace HonestJunkDrone
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public sealed class Plugin : BaseUnityPlugin
    {
        public const string PluginGUID = "com.lbsluis.honestjunkdrone";
        public const string PluginName = "HonestJunkDrone";
        public const string PluginVersion = "1.0.0";

        internal static ManualLogSource Log { get; private set; }

        private void Awake()
        {
            Log = Logger;
            JunkDroneHooks.Init();
            Log.LogInfo($"{PluginName} v{PluginVersion} loaded.");
        }
    }
}
