using System;
using System.Collections.Generic;
using NodeCreation.Enums;

namespace NodeCreation.BehaviorClasses
{
    public class ParallelNode : Node
    {
        public List<Node>? _nodes;
        private int successThreshold = 1;
        private int failRegister = 0;
        private int successRegister = 0;

        public ParallelNode()
        {
            _nodes = new List<Node>();

        }

        public ParallelNode(int successThreshold)
        {
            _nodes = new List<Node>();
           
            this.successThreshold = successThreshold;

            failRegister = 0;
            successRegister = 0;
        }

        public override void Init()
        {
            Console.WriteLine("Parallel Init Tick");
            this.State = (int)StateEnum.Init;

            failRegister = 0;
            successRegister = 0;

            for(int index =0; index < _nodes.Count; index++)
            {
                _nodes[index].Init();
            }

        }

        public override int Tick()
        {
            // a single Tick will Tick Each Node if in INIT or RUNNING state

            for (int index = 0; index < _nodes.Count; index++)
            {
                
                // Check if node is still running to tick again
                if ( (_nodes[index].State == (int)StateEnum.Running) || (_nodes[index].State == (int)StateEnum.Init) )
                {
                    var state = _nodes[index].Tick();
                    if (state == (int)StateEnum.Success) successRegister++;
                    if (state == (int)StateEnum.Fail) failRegister++;
                }
               
                
                
            }

            if ( (successRegister+failRegister) < (_nodes.Count+1) )
            {
                this.State = (int)StateEnum.Running;
            }
            else
            {
                // Return Success
                if (successThreshold >= successRegister)
                {
                    this.State = (int)StateEnum.Success;
                }
                else
                {
                    // Return Fail
                    this.State = (int)StateEnum.Fail;
                }

               

            }
            return (int)this.State;
        }
    }
}
