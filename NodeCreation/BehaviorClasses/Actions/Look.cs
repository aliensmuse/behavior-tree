using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using NodeCreation.Enums;
using NodeCreation.ProgramClasses;

namespace NodeCreation.BehaviorClasses.Actions
{
    public class Look : Node
    {

        [JsonPropertyName("type")]
        public override string Type => "ActionLook";

        public override void Init()
        {
            Console.WriteLine("Look Init");
            this.State = (int)StateEnum.Init;

        }
        public override int Tick()
        {
            Console.WriteLine("Looking around room ...");
            var currentRoom = Int32.Parse(WhiteBoard["ROOM"]);
            if (World.Look(currentRoom))
            {
                Console.WriteLine("There is a door in this room");
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
