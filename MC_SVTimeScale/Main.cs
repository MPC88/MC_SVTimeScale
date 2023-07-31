using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

namespace MC_SVTimeScale
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    public class Main : BaseUnityPlugin
    {
        public const string pluginGuid = "mc.starvalor.timescale";
        public const string pluginName = "SV Time Scale";
        public const string pluginVersion = "1.0.2";

        private static ConfigEntry<KeyCodeSubset> cfgIncrement;
        private static ConfigEntry<KeyCodeSubset> cfgReset;
        private static ConfigEntry<float> cfgStepSize;
        private static ConfigEntry<KeyCodeSubset> cfgHoldKeyBind;
        private static ConfigEntry<bool> cfgHoldKeyMode;
        private static ConfigEntry<float> cfgHoldModeScale;

        private static float timeScale = 1.0f;
        private static float fixedDT;
        public void Awake()
        {
            cfgIncrement = Config.Bind("Increment/Reset Mode",
                "1. Increment Key",
                KeyCodeSubset.Equals,
                "Increases time scale by step size.");
            cfgReset = Config.Bind("Increment/Reset Mode",
                "2. Reset Key",
                KeyCodeSubset.Minus,
                "Resets time scale to default.");
            cfgStepSize = Config.Bind("Increment/Reset Mode",
                "3. Step size",
                0.5f,
                "How much time scale is increased on each increment.");
            cfgHoldKeyMode = Config.Bind("Hold Key Mode",
                "1. Enable hold key mode?",
                false,
                "Enables time scale increase while holding a key.  Overrides increment/reset mode.");
            cfgHoldKeyBind = Config.Bind("Hold Key Mode",
                "2. Hold key",
                KeyCodeSubset.Backslash,
                "Key to hold to increase time scale when in hold key mode.");
            cfgHoldModeScale = Config.Bind("Hold Key Mode",
                "3. Time scale",
                3.0f,
                "The time scale to set when the hold key is held.");

            fixedDT = Time.fixedDeltaTime;
        }

        public void Update()
        {
            if (GameManager.instance != null && GameManager.instance.inGame)
            {
                if (!cfgHoldKeyMode.Value)
                {
                    if (Input.GetKeyDown((KeyCode)cfgIncrement.Value))
                    {
                        timeScale += cfgStepSize.Value;
                        SideInfo.AddMsg("<color=Yellow>Time scale: " + timeScale.ToString() + "</color>");
                    }
                    if (Input.GetKeyDown((KeyCode)cfgReset.Value))
                    {
                        timeScale = 1.0f;
                        SideInfo.AddMsg("<color=Yellow>Time scale: " + timeScale.ToString() + "</color>");
                    }
                }
                else
                {
                    if (Input.GetKey((KeyCode)cfgHoldKeyBind.Value))
                        timeScale = cfgHoldModeScale.Value;
                    else
                        timeScale = 1.0f;
                }
            }

            if (Time.timeScale > 0)
            {
                Time.timeScale = timeScale;
                Time.fixedDeltaTime = fixedDT * timeScale;
            }
        }
    }
}
