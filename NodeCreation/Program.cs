using NodeCreation.Enums;
using NodeCreation.BehaviorClasses;
using NodeCreation.BehaviorClasses.Actions;
using NodeCreation.ProgramClasses;
using System.Text.Json;

Dictionary<string, string> ourDict = new();

ourDict.Add("HP", "25");
ourDict.Add("ROOM", "0");
ourDict.Add("FOOD", "25");


Root root = new();
ParallelNode para = new();
Repeater rep = new();
Repeater rep2 = new();
Sequence moveSeq = new();
Sequence lookSeq = new();
Succeeder suc = new();


//Selector sel = new();

/*** BEGIN Complex Behavior from defining leaf _nodes first and ending in the top node ROOT ***/
// Create a behavior of entering into an area - looking around, opening a door IF it exists, and closing a door
lookSeq._children.Add(new Look());
lookSeq._children.Add(new OpenDoor());
lookSeq._children.Add(new CloseDoor());

// Associate the look/open/close behavior with a Succeeder (regardles of the outcome this branch succeeds)
suc._node = lookSeq;


moveSeq._children.Add(suc);
moveSeq._children.Add(new Walk());

rep._child = moveSeq;
para._children.Add(rep);
rep2._child = new ConsumeFood();
para._children.Add(rep2);

root._child = para;

string filePath = "behaviorTree.json";
BehaviorTreeSerializer.SerializeTree(root, filePath);

/***** END Complex Behavior ******/


// associate our data whiteboard so all _nodes
// can access the data and manipulate it
 root.SetWhiteboard(ourDict);

root.Init();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
root.Tick();
var data = root.GetWhiteboard();
Console.WriteLine(data.ToString());






