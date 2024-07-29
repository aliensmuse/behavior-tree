using NodeCreation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NodeCreation.BehaviorClasses
{
    /*
     * Repeater - is a type of Node that supports Init, Running, and Success .. Regardles of the child notes return
     * the repeater will only return Running or Success
     */
    public class Succeeder : Node
    {
        public Node? _node { get; set; }

        public Succeeder()
        {

            this.State = (int)StateEnum.Init;
        }

        [JsonPropertyName("type")]
        public override string Type => "SucceederNode";

        public override void Init()
        {
            Console.WriteLine("Succeeder Init Tick");
            this.State = (int)StateEnum.Init;


            if (_node is not null) _node.Init();

        }

        public override int Tick()
        {
            if (_node is not null)
            {
                if (this.State == (int)StateEnum.Init) 
                { 
                    this.State = (int)StateEnum.Running; 
                }
                
                var nodeState = _node.Tick();

                if (nodeState != (int)StateEnum.Running)
                {
                    this.State = (int)StateEnum.Success;
                }
                else
                { 
                    this.State = (int)StateEnum.Running;
                }

            }

            return this.State;
        }
    }
}
