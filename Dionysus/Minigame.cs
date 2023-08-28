using System;
using System.Collections.Generic;

namespace Dionysus
{
    public class Minigame
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public Dictionary<String, MinigameEvent> Events { get; set; }
    }
}