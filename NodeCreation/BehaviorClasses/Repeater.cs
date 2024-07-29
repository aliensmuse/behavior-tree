using NodeCreation.Enums;
using System;
using System.Text.Json.Serialization;

namespace NodeCreation.BehaviorClasses
{
    /*
     * Repeater Node : takes one child Node and repeats TICKING by auto-initializing it whenever the tree completes as and returns Success. 
     * If it fails then the repeating ends Exiting the repeater as a Fail.  To infinitely run, just have the last executing node be a 
     * Succeeder.
     */
    public class Repeater : Node
    {
        [JsonPropertyName("_child")]
        public Node? _child { get; set; }

        public Repeater()
        {

            this.State = (int)StateEnum.Init;
        }
        public override void Init()
        {
            Console.WriteLine("Repeater Init Tick");
            this.State = (int)Enums.StateEnum.Init;
            
            
            if (_child is not null) _child.Init();

        }
       
        [JsonPropertyName("type")]
        public override string Type => "RepeaterNode";

        public override int Tick()
        {
            if (_child is not null)
            {
                if (this.State == (int)StateEnum.Init) { this.State = (int)StateEnum.Running; }
                var nodeState = _child.Tick();

                if (nodeState != (int)StateEnum.Running)
                {
                    if (nodeState == (int)StateEnum.Fail)
                    {
                        this.State = (int)StateEnum.Fail;
                    }
                    else
                    {
                        // Repeat the node structure by restarting it
                        _child.Init();

                    }
                }
            }
          
            return (int)this.State;
        }
    }
}
