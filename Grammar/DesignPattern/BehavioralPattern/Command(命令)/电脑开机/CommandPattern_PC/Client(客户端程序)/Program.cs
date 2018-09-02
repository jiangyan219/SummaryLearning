using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern_PC
{
    class Program
    {
        static void Main(string[] args)
        {

            //MainBoardApi mainBoard =new GigaMainBoard();
            MainBoardApi mainBoard = new DellMainBoard();

            OpenCommand openCommand = new OpenCommand(mainBoard);

            Box box = new Box();
            box.SetOpenCommand(openCommand);
            box.OpenButtonPressed();
        }
    }
}
