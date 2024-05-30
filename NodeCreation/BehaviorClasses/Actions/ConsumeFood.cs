using NodeCreation.Enums;
using NodeCreation.ProgramClasses;

namespace NodeCreation.BehaviorClasses.Actions
{
    public class ConsumeFood : Node
    {
        public override void Init()
        {
            Console.WriteLine("Consume Food Action Init");
            this.State = (int)Enums.StateEnum.Init;

        }
        public override int Tick()
        {
            Console.WriteLine("Consume (Eat) Food");
            var healthPoints = Int32.Parse(WhiteBoard["HP"]);

            var foodQuantity = Int32.Parse(WhiteBoard["FOOD"]);

            if (foodQuantity > 0)
            {
                foodQuantity--;
                WhiteBoard["FOOD"] = (foodQuantity).ToString();
                this.State = (int)StateEnum.Success;
            }
            else
            {
                // your are starving reduce health points
                healthPoints--;
                WhiteBoard["HP"] = (healthPoints).ToString();

                if (healthPoints < 1)
                {
                    this.State = (int)StateEnum.Fail;
                }
            }



            return State;
        }
    }
}
