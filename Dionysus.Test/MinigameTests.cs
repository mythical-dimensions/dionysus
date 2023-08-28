using System.IO;
using NUnit.Framework;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Dionysus.Test
{
    [TestFixture]
    public class MinigameTests
    {
        private Minigame _minigame;
        
        [SetUp]
        public void SetUp()
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
                .Build();
            
            string yml = File.ReadAllText("C:\\Users\\zombie\\RiderProjects\\Dionysus\\Dionysus.Test\\test.yaml");
            
            _minigame = deserializer.Deserialize<Minigame>(yml);
        }

        [Test]
        public void ReadMinigameNameFromYaml()
        {
            Assert.True(_minigame.Name == "Zombie Survival");
        }
        
        [Test]
        public void ReadMinigameEventsFromYaml()
        {
            Assert.True(_minigame.Events.ContainsKey("player_joined"));
        }

        [Test]
        public void ReadMinigameEventCommandsFromYaml()
        {
            Assert.True(_minigame.Events["player_joined"].Commands[0] == "bc 5 Testing Testing is this thing on?");
        }
    }
}