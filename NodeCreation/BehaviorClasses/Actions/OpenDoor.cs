using NodeCreation.Enums;

namespace NodeCreation.BehaviorClasses.Actions
{
    public class OpenDoor : Node
    {
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
