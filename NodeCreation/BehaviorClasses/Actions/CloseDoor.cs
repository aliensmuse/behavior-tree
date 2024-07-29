using NodeCreation.Enums;
using System.Text.Json.Serialization;

namespace NodeCreation.BehaviorClasses.Actions
{
    public class CloseDoor : Node
    {
        public override void Init()
        {
            Console.WriteLine("Action Init");
            this.State = (int)Enums.StateEnum.Init;

        }

        [JsonPropertyName("type")]
        public override string Type => "ActionCloseDoor";

        public override int Tick()
        {
            Console.WriteLine("close door");

            // if (_state == 0) _state = 1;
            this.State = (int)Enums.StateEnum.Success;

            return State;
        }
    }
}
