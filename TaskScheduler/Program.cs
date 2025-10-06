using System;
using TaskScheduler;

namespace TaskSchedule
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //make a menu
            Menu menu = new Menu();
            
            //load previous save
            menu.LoadList();

            //display options and start program loop.
            menu.DisplayOptions();
        }
    }
}
