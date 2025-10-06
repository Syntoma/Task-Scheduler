using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TaskScheduler
{
    internal class Menu
    {
        //make a list of all tasks
        private List<Task> tasks = new List<Task>();

        public List<Task> Tasks
        {
            get { return tasks; }
            set { tasks = value; }
        }


        
        //check time (for alert)

        //display the users options
        public void DisplayOptions()
        {
            string chosenOption;
            //Do this unless the user types exit.
            do
            {
                //start with displaying alerts so if a user opens the program they see it immediately.
                DisplayAlerts();

                Console.WriteLine("Options:");
                Console.WriteLine("Create Task");
                Console.WriteLine("Edit Task");
                Console.WriteLine("Delete Task");
                Console.WriteLine("View Tasks");
                Console.WriteLine("View Today's Tasks");
                Console.WriteLine("View A Month's Tasks");
                Console.WriteLine("View Next Task");
                Console.WriteLine("Save");
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                chosenOption = Console.ReadLine();
                Console.WriteLine();

                if (chosenOption == "Create Task" || chosenOption == "create task" || chosenOption == "Create task" || chosenOption == "create a task" || chosenOption == "create" || chosenOption == "Create")
                {
                    CreateTask();
                }
                else if (chosenOption == "Edit Task" || chosenOption == "edit task" || chosenOption == "Edit task" || chosenOption == "Edit" || chosenOption == "edit")
                {
                    EditTask();
                }
                else if (chosenOption == "Delete Task" || chosenOption == "delete task" || chosenOption == "Delete task")
                {
                    DeleteTask();
                }
                else if (chosenOption == "View Tasks" || chosenOption == "view tasks" || chosenOption == "View tasks")
                {
                    DisplayTasks();
                }
                else if (chosenOption == "View Today's Tasks" || chosenOption == "view today's tasks" || chosenOption == "View todays tasks" || chosenOption == "View today's tasks" || chosenOption == "view todays tasks" || chosenOption == "View Today's Tasks")
                {
                    DisplayTodaysTasks();
                }
                else if (chosenOption == "View A Month's Tasks" || chosenOption == "View A Months Tasks" || chosenOption == "View a months tasks" || chosenOption == "View a month's tasks" || chosenOption == "view a month's tasks" || chosenOption == "view a months tasks")
                {
                    DisplaySelectMonthsTasks();
                }
                else if (chosenOption == "View Next Task" || chosenOption == "view next task" || chosenOption == "View next task")
                {
                    DisplayNextTask();
                }
                else if (chosenOption == "Save" || chosenOption == "save")
                {
                    SaveList();
                }
                
            } while (chosenOption != "exit" && chosenOption != "Exit");
            

        }

        //Creates a task and places it in the list
        public void CreateTask()
        {
            //Create the task
            Task newTask = new Task(); 
            newTask.Create();

            //Add the task to the list
            tasks.Add(newTask);


            Console.WriteLine("Task created.");
            Console.ReadLine();


        }

        //Change an existing task
        public void EditTask()
        {
            string getTitle;
            Console.WriteLine("What is the title of the task you want to edit?");
            getTitle = Console.ReadLine();
            Console.WriteLine();
            foreach(Task task in tasks)
            {
                if (getTitle == task.Title)
                {
                    //display the task to make sure this is the correct one.
                    task.Display();
                    string check;
                    Console.WriteLine("Is this the task you would like to edit?");
                    check = Console.ReadLine();
                    Console.WriteLine();
                    if (check == "Yes" || check == "yes" || check == "yeah" || check == "Yeah" || check == "y" || check == "Y")
                    {
                        task.Edit();
                    }

                }
            }
        }

        //remove a task from the list
        public void DeleteTask()
        {
            string getTitle;
            Console.WriteLine("What is the title of the task you want to delete?");
            getTitle = Console.ReadLine();
            Console.WriteLine();
            bool hasRemoved = false;
            //Originally I planned to use foreach (like in edit) but learned from a LLM
            //why that causes an error and got the idea to use index from it instead.
            //for loop to go through each task.
            for (int i = 0; i < tasks.Count; i++)
            {
                //check to see if the user already found what they want removed
                if(hasRemoved == false)
                {
                    //if the titles match check to see if it is the one the user wants deleted.
                    if (tasks[i].Title == getTitle)
                    {
                        tasks[i].Display();
                        string check;
                        Console.WriteLine("Is this the task you would like to delete?");
                        check = Console.ReadLine();
                        Console.WriteLine();
                        if (check == "Yes" || check == "yes" || check == "yeah" || check == "Yeah" || check == "y" || check == "Y")
                        {
                            tasks.Remove(tasks[i]);
                            Console.WriteLine("Task Deleted");
                            Console.ReadLine();
                            //change to true so the user wont have to go through more tasks.
                            hasRemoved = true;
                        }
                    }
                }
                
            }
        }

        //display all the tasks
        public void DisplayTasks()
        {
            foreach(Task task in tasks)
            {
                task.Display();
            }
            Console.ReadLine();
        }

        //display all of the tasks scheduled for today
        public void DisplayTodaysTasks()
        {
            foreach (Task task in tasks)
            {
                //check the year, month, and day
                if (task.Time.Year == DateTime.Today.Year && task.Time.Month == DateTime.Today.Month && task.Time.Day == DateTime.Today.Day)
                {
                    task.Display();
                }
            }
            Console.ReadLine();
        }

        //display all of the tasks within a chosen month
        public void DisplaySelectMonthsTasks()
        {
            //prompt the user for the month and year
            Console.WriteLine("Which month's tasks would you like to see?");
            string monthResponse;
            monthResponse = Console.ReadLine();
            int month = 1;
            Console.WriteLine();
            //Check which month they said
            //Janruary
            if (monthResponse == "January" || monthResponse == "january" || monthResponse == "Jan" || monthResponse == "jan" || monthResponse == "1")
            {
                month = 1;
            }
            //February
            else if (monthResponse == "February" || monthResponse == "february" || monthResponse == "Feb" || monthResponse == "feb" || monthResponse == "2")
            {
                month = 2;
            }
            //March
            else if (monthResponse == "March" || monthResponse == "march" || monthResponse == "Mar" || monthResponse == "mar" || monthResponse == "3")
            {
                month = 3;
            }
            //April
            else if (monthResponse == "April" || monthResponse == "april" || monthResponse == "Apr" || monthResponse == "apr" || monthResponse == "4")
            {
                month = 4;
            }
            //May
            else if (monthResponse == "May" || monthResponse == "may" || monthResponse == "5")
            {
                month = 5;
            }
            //June
            else if (monthResponse == "June" || monthResponse == "june" || monthResponse == "Jun" || monthResponse == "jun" || monthResponse == "6")
            {
                month = 6;
            }
            //July
            else if (monthResponse == "July" || monthResponse == "july" || monthResponse == "Jul" || monthResponse == "jul" || monthResponse == "7")
            {
                month = 7;
            }
            //August
            else if (monthResponse == "August" || monthResponse == "august" || monthResponse == "Aug" || monthResponse == "aug" || monthResponse == "8")
            {
                month = 8;
            }
            //September
            else if (monthResponse == "September" || monthResponse == "september" || monthResponse == "Sep" || monthResponse == "sep" || monthResponse == "9")
            {
                month = 9;
            }
            //October
            else if (monthResponse == "October" || monthResponse == "october" || monthResponse == "Oct" || monthResponse == "oct" || monthResponse == "10")
            {
                month = 10;
            }
            //November
            else if (monthResponse == "November" || monthResponse == "november" || monthResponse == "Nov" || monthResponse == "nov" || monthResponse == "11")
            {
                month = 11;
            }
            //December
            else if (monthResponse == "December" || monthResponse == "december" || monthResponse == "Dec" || monthResponse == "dec" || monthResponse == "12")
            {
                month = 12;
            }

            //Prompt the user for the year
            Console.WriteLine("What year?");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine();

            //Go through all the tasks and see which ones match the month and year
            foreach (Task task in tasks)
            {
                if (task.Time.Year == year && task.Time.Month == month)
                {
                    task.Display();
                }
            }
            
            //read line for visibility.
            Console.ReadLine();
        }

        //display the upcoming task (Soonest time)
        public void DisplayNextTask()
        {
            //sort the list by time
            List<Task> sortedList = new List<Task>();
            sortedList = SortList();

            //Loop through to find the first list that has a time.
            for (int i = 0; i < sortedList.Count; i++)
            {
                if (sortedList[i].HaveTime == true)
                {
                    sortedList[i].Display();
                    Console.ReadLine();
                    //break so only one task is displayed.
                    break;
                }
            }
        }

        //save the list
        public void SaveList()
        {
            //save each task line by line to 
            using (StreamWriter writer = new StreamWriter("tasks.txt"))
            {
                foreach (Task task in tasks)
                {
                    writer.WriteLine(task);
                }
            }

            Console.WriteLine("Tasks Saved.");
            Console.ReadLine();

        }

        //Reads in tasks from tasks.txt and adds it to tasks.
        public void LoadList()
        {
            //check to see if the file exists
            if (File.Exists("tasks.txt"))
            {
                //read in line by line
                string[] lines = System.IO.File.ReadAllLines("tasks.txt");

                //seperate each line by every ` and then set the attributes.
                foreach (string line in lines)
                {
                    string[] parts = line.Split('`');
                    string title = parts[0];
                    string description = parts[1];
                    DateTime time = DateTime.Parse(parts[2]);
                    bool alert = bool.Parse(parts[3]);
                    bool haveTime = bool.Parse(parts[4]);
                    bool haveDetails = bool.Parse(parts[5]);

                    Task task = new Task();
                    task.Title = title;
                    task.Details = description;
                    task.Time = time;
                    task.Alert = alert;
                    task.HaveTime = haveTime;
                    task.HaveDetails = haveDetails;

                    tasks.Add(task);
                }
            }
            
        }

        //Method that sorts the tasks and then returns that sorted list.
        public List<Task> SortList()
        {
            List<Task> sortedList = new List<Task>();
            sortedList = tasks;
            sortedList.Sort((x, y) => x.Time.CompareTo(y.Time));
            return sortedList;
        }

        //Displays all tasks with alerts if it is scheduled within the hour.
        public void DisplayAlerts()
        {
            foreach(Task task in tasks)
            {
                //check to see if it is within one hour.
                if (DateTime.Now < task.Time && DateTime.Now > task.Time.AddHours(-1) && task.Alert == true)
                {
                    Console.WriteLine("Upcoming Task!");
                    task.Display();
                    Console.ReadLine();

                }
                

            }
        }

    }
}
