using NodeCreation.Enums;
using System.Text.Json.Serialization;

namespace NodeCreation.BehaviorClasses
{
    public abstract class Node
    {
        public int State { get; set; }

        protected static Dictionary<string, string>? WhiteBoard { get; set; }

        public abstract void Init();

        public abstract int Tick();
       
        [JsonPropertyName("type")]
        public abstract string Type { get; }
    }
}
