using NodeCreation.Enums;
using System.Text.Json.Serialization;

namespace NodeCreation.BehaviorClasses.Actions
{
    public class OpenDoor : Node
    {
        [JsonPropertyName("type")]
        public override string Type => "ActionOpenDoor";

        public override void Init()
        {
            Console.WriteLine("Action Init");
            this.State = (int)Enums.StateEnum.Init;

        }
        public override int Tick()
        {
            Console.WriteLine("opening door");

            // if (_state == 0) _state = 1;
            this.State = (int)Enums.StateEnum.Success;

            return State;
        }
    }
}
