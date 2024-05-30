using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeCreation.ProgramClasses
{
    public static class World
    {
        public static int position = 0;

        public static List<int> rooms = new List<int> { 0, 0, 1, 0, 0, 0, 1, 1, 1 };
        public static bool CheckMove(int pos) { return rooms.Count > pos ? true : false; }

        public static bool Look(int pos) { return rooms[pos] == 1 ? true : false;  }
    }

}
