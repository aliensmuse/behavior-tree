using NodeCreation.Enums;
using System;


namespace NodeCreation.BehaviorClasses
{
    /*
     * Repeater Node : takes one child Node and repeats TICKING by auto-initializing it whenever the tree completes as and returns Success. 
     * If it fails then the repeating ends Exiting the repeater as a Fail.  To infinitely run, just have the last executing node be a 
     * Succeeder.
     */
    public class Repeater : Node
    {
        public Node? _node { get; set; }

        public Repeater()
        {

            this.State = (int)StateEnum.Init;
        }
        public override void Init()
        {
            Console.WriteLine("Repeater Init Tick");
            this.State = (int)Enums.StateEnum.Init;
            
            
            if (_node is not null) _node.Init();

        }

        public override int Tick()
        {
            if (_node is not null)
            {
                if (this.State == (int)StateEnum.Init) { this.State = (int)StateEnum.Running; }
                var nodeState = _node.Tick();

                if (nodeState != (int)StateEnum.Running)
                {
                    if (nodeState == (int)StateEnum.Fail)
                    {
                        this.State = (int)StateEnum.Fail;
                    }
                    else
                    {
                        // Repeat the node structure by restarting it
                        _node.Init();

                    }
                }
            }
          
            return (int)this.State;
        }
    }
}
