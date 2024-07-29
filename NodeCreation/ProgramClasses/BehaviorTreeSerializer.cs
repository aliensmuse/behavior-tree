using NodeCreation.BehaviorClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NodeCreation.ProgramClasses
{
    public static class BehaviorTreeSerializer
    {
        public static void SerializeTree(Node root, string filePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new BehaviorNodeConverter() }
            };
            var json = JsonSerializer.Serialize(root, options);
            File.WriteAllText(filePath, json);
        }

        public static Node DeserializeTree(string filePath)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new BehaviorNodeConverter() }
            };
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Node>(json, options);
        }
    }

    public class BehaviorNodeConverter : JsonConverter<Node>
    {
        public override Node Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                var root = doc.RootElement;
                string type = root.GetProperty("type").GetString();
                switch (type)
                {
                   // case "ActionNode":
                   //     return JsonSerializer.Deserialize<ActionNode>(root.GetRawText(), options);
                    //case "ConditionNode":
                    //    return JsonSerializer.Deserialize<ConditionNode>(root.GetRawText(), options);
                    case "SequenceNode":
                        return JsonSerializer.Deserialize<Sequence>(root.GetRawText(), options);
                    case "SelectorNode":
                        return JsonSerializer.Deserialize<Selector>(root.GetRawText(), options);
                    default:
                        throw new NotSupportedException($"Node type {type} is not supported");
                }
            }
        }

        public override void Write(Utf8JsonWriter writer, Node value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
