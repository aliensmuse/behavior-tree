using System;
using System.Collections.Generic;
using NodeCreation.Enums;


namespace NodeCreation.BehaviorClasses
{
    public class Root : Node
    {
        public Node? node { get; set; }

        

        public Root()
        {

            this.State = (int)StateEnum.Init;
            WhiteBoard = new Dictionary<string, string>();
        }
        public override void Init()
        {
            Console.WriteLine("Root Init Tick");
            this.State = (int)StateEnum.Init;


            if (node is not null) node.Init();

        }
        public  Dictionary<string,string> GetWhiteboard ()
        {
            return  WhiteBoard;
        }

        public void SetWhiteboard( Dictionary<string,string> dict)
        {
            WhiteBoard = dict;
        }

        public override int Tick()
        {


            return (int)node.Tick();
        }
    }
}
