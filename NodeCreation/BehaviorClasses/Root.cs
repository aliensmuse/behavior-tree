using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using NodeCreation.Enums;


namespace NodeCreation.BehaviorClasses
{
    public class Root : Node
    {
        [JsonPropertyName("_child")]
        public Node? _child { get; set; }

        public Root()
        {

            this.State = (int)StateEnum.Init;
            WhiteBoard = new Dictionary<string, string>();
        }

        [JsonPropertyName("type")]
        public override string Type => "RootNode";

        public override void Init()
        {
            Console.WriteLine("Root Init Tick");
            this.State = (int)StateEnum.Init;


            if (_child is not null) _child.Init();

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


            return (int)_child.Tick();
        }
    }
}
