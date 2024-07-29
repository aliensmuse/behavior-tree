using NodeCreation.Enums;
using System.Text.Json.Serialization;

namespace NodeCreation.BehaviorClasses
{
    public class Sequence : Node
    {
        [JsonPropertyName("_children")]
        public List<Node>? _children;

        private int _nodeCount = 0;
        private int _nodePosition = 0;

        public Sequence()
        {
            _children = new List<Node>();
        }

        [JsonPropertyName("type")]
        public override string Type => "SequenceNode";

        public override void Init()
        {
            Console.WriteLine("Sequence Init ");
            this.State = (int)Enums.StateEnum.Init;
            this._nodeCount = _children.Count;
            this._nodePosition = 0;

            foreach (var node in _children)
            {
                node.Init();
            }

        }
        public override int Tick()
        {
            Console.WriteLine("Sequence Tick");

            // Set Sequence to RUNNING on first Tick when in the INIT state
            if ((this._nodePosition == 0) && (this.State == (int)Enums.StateEnum.Init)) State = (int)Enums.StateEnum.Running;

            // if the Sequence is RUNNING then check its children _nodes
            if (this.State == (int)Enums.StateEnum.Running)
            {
                var childNode = _children[this._nodePosition];

                var nodeState = childNode.Tick();

                // IF child Node's Tick returns Fail set sequence to fail
                if (nodeState == (int)Enums.StateEnum.Fail)
                {
                    // Node Failed so exit Sequence with state remaining 0 
                    this.State = (int)Enums.StateEnum.Fail;

                }
                else if (nodeState == (int)Enums.StateEnum.Running)
                {
                    this.State = (int)Enums.StateEnum.Running;
                    // we don't increment the tree position since the child node is still running

                }
                else if ((this._nodePosition == this._nodeCount - 1) && (nodeState == (int)Enums.StateEnum.Success))
                {
                    // Last child Node of the sequence returned a success so set the entire sequence to success

                    this.State = (int)Enums.StateEnum.Success;

                }
                else // walk to next child position
                {
                    this._nodePosition++;
                    this.State = (int)Enums.StateEnum.Running;

                }
            }

            Console.WriteLine($"Sequence: position - {this._nodePosition} state: {this.State}");
            return this.State;
        }
    }

}
