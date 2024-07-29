using System;
using System.Text.Json.Serialization;
using NodeCreation.Enums;

namespace NodeCreation.BehaviorClasses
{
    public class Selector : Node
    {
        [JsonPropertyName("_children")]
        public List<Node>? _children;

        private int nodeCount = 0;
        private int nodePosition = 0;

        public Selector()
        {
            _children = new List<Node>();
        }

        [JsonPropertyName("type")]
        public override string Type => "SelectorNode";

        public override void Init()
        {
            Console.WriteLine("Selector Init Tick");
            this.State = (int)Enums.StateEnum.Init;
            this.nodeCount = _children.Count;
            this.nodePosition = 0;

            foreach (var node in _children)
            {
                node.Init();
            }

        }
        public override int Tick()
        {
            Console.WriteLine("Selector Tick");
            // Set Sequence to RUNNING on first Tick when in the INIT state
            if ((this.nodePosition == 0) && (this.State == (int)StateEnum.Init)) State = (int)StateEnum.Running;

            // if the Sequence is RUNNING then check its children _nodes
            if (this.State == (int)StateEnum.Running)
            {
                var childNode = _children[this.nodePosition];

                var nodeState = childNode.Tick();

                // IF last node in selector returns fail then Fail the node
                if ( (nodeState == (int)StateEnum.Fail) && (this.nodePosition == this.nodeCount - 1) )
                {
                    // Continue
                    this.State = (int)StateEnum.Fail;

                }
                else if (nodeState == (int)StateEnum.Running)
                {
                    this.State = (int)StateEnum.Running;
                    // we don't increment the tree position since the child node is still running

                }
                else if ( (nodeState == (int)StateEnum.Success) )
                {
                    // Last child Node of the sequence returned a success so set the entire sequence to success

                    this.State = (int)StateEnum.Success;

                }
                else // walk to next child position
                {
                    this.nodePosition++;
                    this.State = (int)StateEnum.Running;

                }
            }

            Console.WriteLine($"Selector: position - {this.nodePosition} state: {this.State}");
            return this.State;
        }
    }

}
