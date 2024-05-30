using NodeCreation.Enums;
using NodeCreation.ProgramClasses;

namespace NodeCreation.BehaviorClasses.Actions
{
    public class Walk : Node
    {
    
        
        public override void Init()
        {
            Console.WriteLine("Action Init");
            this.State = (int)Enums.StateEnum.Init;

        }
        public override int Tick()
        {
            Console.WriteLine("walk");
            var currentRoom = Int32.Parse(WhiteBoard["ROOM"]);
            if (World.CheckMove(currentRoom + 1)) 
            { 
                WhiteBoard["ROOM"] = (currentRoom + 1).ToString();
                Console.WriteLine($"Moving rooms {currentRoom + 1}");
                this.State = (int)StateEnum.Success;
            }
            else
            {
                this.State = (int)StateEnum.Fail;
            }

            return State;
        }
    }
}
