using System.Collections.Generic;
using LyokoAPI.API;
using LyokoAPI.API.Compatibility;
using LyokoAPI.Plugin;


namespace EventLoggerPlugin
{
    public class EventLoggerPlugin : LyokoAPIPlugin
    {
        public override string Name => PluginName;

        public static string PluginName => "EventLoggerPlugin";

        public override string Author => "App24";
        public override LVersion Version => "1.0.0";
        public override List<LVersion> CompatibleLAPIVersions => new List<LVersion>() { "2.0.0" };

        LoggerListener loggerListener = new LoggerListener();

        public override void OnGameEnd(bool failed)
        {

        }

        public override void OnGameStart(bool storyMode)
        {

        }

        public override void OnInterfaceEnter()
        {

        }

        public override void OnInterfaceExit()
        {

        }

        protected override bool OnDisable()
        {
            ConfigManager.SaveAllConfigs();
            loggerListener.StopListening();
            return true;
        }

        protected override bool OnEnable()
        {
            if (!ConfigManager.GetMainConfig().Values.ContainsKey("logCommands"))
            {
                ConfigManager.GetMainConfig().Values.Add("logCommands","false");
            }
            loggerListener.PluginConfig = ConfigManager.GetMainConfig();
            loggerListener.StartListening();
            return true;
        }
    }
}
