using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskScheduler
{
    internal class Task
    {
        //attributes
        private string title;
        private string details;
        private DateTime time;
        private bool haveTime;
        private bool haveDetails;
        private bool alert;
        
        //getters and setters
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Details
        {
            get { return details; }
            set { details = value; }
        }
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        public bool Alert
        {
            get { return alert; }
            set { alert = value; }
        }

        public bool HaveTime
        {
            get { return haveTime; }
            set { haveTime = value; }
        }

        public bool HaveDetails
        {
            get { return haveDetails; }
            set { haveDetails = value; }
        }

        //override task tostring for reading and writing files.
        public override string ToString()
        {
            return $"{Title}`{Details}`{Time}`{Alert}`{HaveTime}`{HaveDetails}";
        }


        //methods

        //prompt the user for details on the task
        public void Create()
        {
            //Prompt the user for the title of the task.
            Console.WriteLine("What is your new task?");
            Title = Console.ReadLine();
            Console.WriteLine();


            //Prompt the user for if they want to schedule a time. 
            string response;
            Console.WriteLine("Would you like to schedule this task?");
            response = Console.ReadLine();
            Console.WriteLine();
            //Check if they say yes.
            if (response == "Yes" || response == "yes" || response == "yeah" || response == "Yeah" || response == "y" || response == "Y")
            {
                //Show that there is a time
                haveTime = true;

                //Prompt the user for the year
                Console.WriteLine("Please input the year: "); 
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //Prompt the user for the month
                string monthResponse;
                int month = 1;
                Console.WriteLine("Please input the month: ");
                monthResponse = Console.ReadLine();
                Console.WriteLine();
                //Check which month they said
                //Janruary
                if (monthResponse == "Janruary" || monthResponse == "janruary" || monthResponse == "Jan" || monthResponse == "jan" || monthResponse == "1")
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

                //Prompt the user for the day
                Console.WriteLine("Please input the day: ");
                int day = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //Prompt the user for the hour
                Console.WriteLine("Please input the hour (military): ");
                int hour = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //Prompt the user for the minute
                Console.WriteLine("Please input the minute: ");
                int minute = int.Parse(Console.ReadLine());
                Console.WriteLine();

                DateTime taskTime = new DateTime(year, month, day, hour, minute, 0);

                time = taskTime;
            }
            else 
            {
                //if they dont set that there is no time.
                haveTime = false;
            }

            //Prompt the user if they would like to attach any details to the task
            Console.WriteLine("Would you like to attach any details to this task? ");
            response = Console.ReadLine();
            Console.WriteLine();
            //Check if they say yes.
            if (response == "Yes" || response == "yes" || response == "yeah" || response == "Yeah" || response == "y" || response == "Y")
            {
                //if they do set that there are details
                haveDetails = true;

                Console.WriteLine("Please list the details you would like attached: ");
                details = Console.ReadLine();
                Console.WriteLine();
            }
            else
            {
                //if they dont set that there are no details.
                haveDetails = false;
            }

            //Prompt the user if they would like to turn on an alert
            Console.WriteLine("Would you like to turn on an alert for this task?");
            response = Console.ReadLine();
            Console.WriteLine();
            //Check if they say yes.
            if (response == "Yes" || response == "yes" || response == "yeah" || response == "Yeah" || response == "y" || response == "Y")
            {
                alert = true;
            }
            else
            {
                alert = false;
            }
        }


        public void Edit()
        {
            //See if they want to change the title
            string response;
            Console.WriteLine("Would you like to edit the title?");
            response = Console.ReadLine();
            Console.WriteLine();
            //Check if they say yes.
            if (response == "Yes" || response == "yes" || response == "yeah" || response == "Yeah" || response == "y" || response == "Y")
            {
                Console.WriteLine("Please enter the new title:");
                Title = Console.ReadLine();
                Console.WriteLine();
            }
           
            //See if they want to change the time
            Console.WriteLine("Would you like to edit the time?");
            response = Console.ReadLine();
            Console.WriteLine();
            //Check if they say yes.
            if (response == "Yes" || response == "yes" || response == "yeah" || response == "Yeah" || response == "y" || response == "Y")
            {
                //Show that there is a time
                haveTime = true;

                //Prompt the user for the year
                Console.WriteLine("Please input the year: ");
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //Prompt the user for the month
                string monthResponse;
                int month = 1;
                Console.WriteLine("Please input the month: ");
                monthResponse = Console.ReadLine();
                Console.WriteLine();
                //Check which month they said
                //Janruary
                if (monthResponse == "Janruary" || monthResponse == "janruary" || monthResponse == "Jan" || monthResponse == "jan" || monthResponse == "1")
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

                //Prompt the user for the day
                Console.WriteLine("Please input the day: ");
                int day = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //Prompt the user for the hour
                Console.WriteLine("Please input the hour (military): ");
                int hour = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //Prompt the user for the minute
                Console.WriteLine("Please input the minute: ");
                int minute = int.Parse(Console.ReadLine());
                Console.WriteLine();

                DateTime taskTime = new DateTime(year, month, day, hour, minute, 0);

                time = taskTime;
            }

            //See if the user wants to edit the details
            Console.WriteLine("Would you like to change the details to this task? ");
            response = Console.ReadLine();
            Console.WriteLine();
            //Check if they say yes.
            if (response == "Yes" || response == "yes" || response == "yeah" || response == "Yeah" || response == "y" || response == "Y")
            {
                //if they do set that there are details
                haveDetails = true;

                Console.WriteLine("Please list the details you would like to add: ");
                details = Console.ReadLine();
                Console.WriteLine();
            }

            //Prompt the user if they want it to have an alert
            Console.WriteLine("Would you like the task to have an alert?");
            response = Console.ReadLine();
            Console.WriteLine();
            //Check if they say yes.
            if (response == "Yes" || response == "yes" || response == "yeah" || response == "Yeah" || response == "y" || response == "Y")
            {
                alert = true;
            }
            else
            {
                alert = false;
            }

        }
        public void Display()
        {
            //display the task.
            Console.WriteLine($"Task: {Title}");

            //display the time
            if (haveTime == true)
            {
                Console.WriteLine($"Time: {Time}");
            }


            //display the details
            if (haveDetails == true)
            {
                Console.WriteLine($"Details: {Details}");
            }

            Console.WriteLine();
        }
       
        public void DisplayAlert()
        {
            if (alert == true)
            {
                Console.WriteLine($"Task {Title} is coming up!");
            }
        }

    }
}
