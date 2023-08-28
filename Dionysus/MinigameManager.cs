using System;
using System.Collections.Generic;
using RemoteAdmin;

namespace Dionysus
{
    public class MinigameManager
    {
        private MinigameManager() {}
        
        private static readonly Lazy<MinigameManager> lazy = new Lazy<MinigameManager>(() => new MinigameManager());
        private static Dictionary<String, Minigame> Minigames;

        public static MinigameManager Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public static bool Handle(string eventType, Tuple<String, String>[] args)
        {
            foreach (Minigame minigame in Minigames.Values)
            {
                if (minigame.Events.ContainsKey(eventType))
                {
                    foreach (var command in minigame.Events[eventType].Commands)
                    {
                        string processedCommand = PreProcessCommand(command, args);
                        var assm = typeof(CommandProcessor).Assembly;
                        assm.GetType("CommandProcessor").GetMethod("ProcessQuery").Invoke(null, new [] { processedCommand, null});
                    }   
                    return true;
                }
            }

            return false;
        }

        private static string PreProcessCommand(string command, Tuple<String, String>[] args)
        {
            string processedCommand = command.Clone().ToString();
            foreach (var argument in args)
            {
                processedCommand.Replace("{{" + argument.Item1 + "}}", argument.Item2);
            }

            return processedCommand;
        }
    }
}