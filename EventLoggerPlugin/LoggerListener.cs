using System;
using LyokoAPI.API;
using LyokoAPI.Plugin;
using LyokoAPI.Events;
using LyokoAPI.Events.LWEvents;
using LyokoAPI.VirtualEntities.LyokoWarrior;
using LyokoAPI.VirtualEntities.Overvehicle;
using LyokoAPI.VirtualStructures;
using LyokoAPI.VirtualStructures.Interfaces;

namespace EventLoggerPlugin
{
    public class LoggerListener : LAPIListener
    {

        public PluginConfig PluginConfig;

        //Temporary, until LAPI gets updated
        public override void StartListening()
        {
            base.StartListening();
            LW_DeTranslationEvent.LwE += onLW_Detrans;
            LW_CodeEarthResolvedEvent.LwE += onLW_CodeEarthResolved;
            LW_DNACorruptionEvent.LwE += onLW_DNACorruption;
            LW_FixedDNAEvent.LwE += onLW_FixedDNA;
        }

        //Temporary, until LAPI gets updated
        public override void StopListening()
        {
            base.StopListening();
            LW_DeTranslationEvent.LwE -= onLW_Detrans;
            LW_CodeEarthResolvedEvent.LwE -= onLW_CodeEarthResolved;
            LW_DNACorruptionEvent.LwE -= onLW_DNACorruption;
            LW_FixedDNAEvent.LwE -= onLW_FixedDNA;
        }

        #region LW Events
        public override void onLW_Virt(LyokoWarrior warrior)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"LyokoWarrior: {warrior.WarriorName} was virtualized!");
        }

        public override void onLW_Devirt(LyokoWarrior warrior)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"LyokoWarrior: {warrior.WarriorName} was devirtualized!");
        }

        public override void onLW_Death(LyokoWarrior warrior)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"LyokoWarrior: {warrior.WarriorName} was killed!");
        }

        public override void onLW_Arrive(LyokoWarrior warrior)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"LyokoWarrior: {warrior.WarriorName} arrived at its destination!");
        }

        public override void onLW_Dexanafication(LyokoWarrior warrior)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"LyokoWarrior: {warrior.WarriorName} was dexanafied!");
        }

        public override void onLW_Frontier(LyokoWarrior warrior)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"LyokoWarrior: {warrior.WarriorName} was put in frontier!");
        }

        public override void onLW_Heal(LyokoWarrior warrior)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"LyokoWarrior: {warrior.WarriorName} was healed!");
        }

        public override void onLW_Hurt(LyokoWarrior warrior)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"LyokoWarrior: {warrior.WarriorName} was hurt!");
        }

        public override void onLW_PermXanafy(LyokoWarrior warrior)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"LyokoWarrior: {warrior.WarriorName} was permanently xanafied!");
        }

        public override void onLW_Trans(LyokoWarrior warrior)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"LyokoWarrior: {warrior.WarriorName} was translated!");
        }

        public void onLW_Detrans(LyokoWarrior warrior)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"LyokoWarrior: {warrior.WarriorName} was detranslated!");
        }

        public override void onLW_Xanafication(LyokoWarrior warrior)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"LyokoWarrior: {warrior.WarriorName} was xanafied!");
        }

        public void onLW_CodeEarthResolved(LyokoWarrior warrior)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"LyokoWarrior: {warrior.WarriorName} code earth resolved!");
        }

        public void onLW_DNACorruption(LyokoWarrior warrior)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"LyokoWarrior: {warrior.WarriorName} DNA corrupted!");
        }

        public void onLW_FixedDNA(LyokoWarrior warrior)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"LyokoWarrior: {warrior.WarriorName} DNA fixed!");
        }
        #endregion

        #region Misc
        public override void onRTTP()
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"Misc: RTTP!");
        }

        public override void onWorldDestruction(IVirtualWorld world)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"World: {world.Name} was destroyed!");
        }

        public override void onCommandInput(string input)
        {
            if (PluginConfig.Values.TryGetValue("logCommands", out var value))
            {
                if (bool.TryParse(value, out var result))
                {
                    if (result)
                    {
                        LyokoLogger.Log(EventLoggerPlugin.PluginName, $"Command: Input {input}");
                    }
                }
            }
        }

        public override void onCommandOutput(string message)
        {
            if(PluginConfig.Values.TryGetValue("logCommands", out var value))
            {
                if(bool.TryParse(value, out var result))
                {
                    if (result)
                    {
                        LyokoLogger.Log(EventLoggerPlugin.PluginName, $"Command: output {message}");
                    }
                }
            }
        }
        #endregion

        #region OV Events
        public override void onOV_Virt(Overvehicle overvehicle)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"Overvehicle: {overvehicle.OvervehicleName} was virtualized!");
        }

        public override void onOV_Devirt(Overvehicle overvehicle)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"Overvehicle: {overvehicle.OvervehicleName} was devirtualized!");
        }

        public override void onOV_Hurt(Overvehicle overvehicle)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"Overvehicle: {overvehicle.OvervehicleName} was hurt!");
        }

        public override void onOV_GetOff(Overvehicle overvehicle, LyokoWarrior warrior)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"Overvehicle: {warrior.WarriorName} got off {overvehicle.OvervehicleName}!");
        }

        public override void onOV_Ride(Overvehicle overvehicle, LyokoWarrior warrior)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"Overvehicle: {warrior.WarriorName} is ridding {overvehicle.OvervehicleName}!");
        }
        #endregion

        #region Sector Events
        public override void onSectorCreation(ISector sector)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"Sector: {sector.Name} was created in {sector.World.Name} with {sector.Towers}!");
        }

        public override void onSectorDestruction(ISector sector)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"Sector: {sector.Name} was destroyed in {sector.World.Name} with {sector.Towers}!");
        }
        #endregion

        #region Xana Events
        public override void onXanaAwaken()
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"Xana: Awaken!");
        }

        public override void onXanaDefeat()
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"Xana: Defeat!");
        }
        #endregion

        #region Tower Events
        public override void onTowerActivation(ITower tower)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"Tower: Number {tower.Number} in {tower.Sector.Name} was activated by {tower.Activator}!");
        }

        public override void onTowerDeactivation(ITower tower)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"Tower: Number {tower.Number} in {tower.Sector.Name} was deactivated!");
        }

        public override void onTowerHijack(ITower tower, APIActivator old, APIActivator newac)
        {
            LyokoLogger.Log(EventLoggerPlugin.PluginName, $"Tower: Number {tower.Number} in {tower.Sector.Name} was hijaced by {newac} from {old}!");
        }
        #endregion
    }
}
