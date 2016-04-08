using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MeetingMinutesSW
{
    class Program
    {
        static void Main(string[] args)
        {
            /* meeting minutes SW by Erica Sommer inclass project April 8 2016
            Things I know are broken:
            StreamReader hasn't been integrated yet (code exists below) but the file does write to the debug folder. 
            I just broke my View menu and I don't know how.
            */
            ProgramName();
            Console.WriteLine(" ");
            Console.WriteLine("MAIN MENU\n---------\n");
            Console.WriteLine("C. Create Meeting");
            Console.WriteLine("V. View Team");
            Console.WriteLine("X. EXIT");
            Console.WriteLine("Enter C V or X to make a selection.");
            //get input, uppercase it, parse to char.
            char mainSelect = char.Parse(Console.ReadLine().ToUpper());
            string fileName;
            string[] dateArray;
            //Main Menu
            do
            {
                if (mainSelect == 'C')
                {
                    fileName = CreateMeeting();
                        
                }
                else if (mainSelect == 'V')
                {
                    ViewTeam();
                }
                /* else if (mainSelect == 'R')
                {
                    ReadMinutes(fileName);
                    //I don't know how to get this from my CreateMeeting Method down to here
                } */
                Console.WriteLine(" ");
                Console.WriteLine("MAIN MENU\n---------\n");
                Console.WriteLine("C. Create Meeting");
                Console.WriteLine("V. View Team");
                //Console.WriteLine("R. Read Minutes");
                Console.WriteLine("X. EXIT");
                Console.WriteLine("Enter C V or X to make a selection.");
                mainSelect = char.Parse(Console.ReadLine().ToUpper());
            } while (mainSelect != 'X');

            if (mainSelect == 'X')
                Console.WriteLine("Goodbye!");
        }

        //Create Meeting method

        static string CreateMeeting()
        {
            ProgramName();
            //some variables to start
            char exit;
            string notesRecord;
            string meetingTypeRecord = "coffee";
            //user prompts
            Console.WriteLine("Please enter team member recording the minutes.");
            string minuteRecord = Console.ReadLine();
            Console.WriteLine("Who is leading the meeting?");
            string leadRecord = Console.ReadLine();
            Console.WriteLine("What is the date?");
            string dateRecord = Console.ReadLine();
            //please note that I do not use this for naming the text file. Instead I parse DateTime and stringbuild it.
            // I add this date to the header information.
            Console.WriteLine("Please select a meeting type from the following:");
            Console.WriteLine("");
            Console.WriteLine("   <* O * > O. Old Men Yelling at Clouds");
            Console.WriteLine("");
            Console.WriteLine("   >>^_^<<  B. Bouncy Castles");
            Console.WriteLine("");
            Console.WriteLine("   <* . * > S. Staring Off Into Space ");
            Console.WriteLine("");
            Console.WriteLine("");
            char meetingTypeSelection = char.Parse(Console.ReadLine().ToUpper());
            Console.WriteLine("Please enter the meeting topic");
            string topicRecord = Console.ReadLine();
            do
            {
                Console.WriteLine("Please enter notes on this topic");
                notesRecord = Console.ReadLine();
                Console.WriteLine("Enter more notes? Y or N");
                exit = Char.Parse(Console.ReadLine().ToUpper());
            } while (exit == 'Y');



            List<string> meetingTypes = new List<string>();
            meetingTypes.Add("Old Men Yelling at Clouds");
            meetingTypes.Add("Bouncy Castles");
            meetingTypes.Add("Staring Off Into Space");

            //this could be looped I think but I'm struggling with other stuff 
            // so I probably won't come back to this.
            if (meetingTypeSelection == 'O')
            {
                meetingTypeRecord = meetingTypes[0];
            }

            if (meetingTypeSelection == 'B')
            {
                meetingTypeRecord = meetingTypes[1];
            }

            if (meetingTypeSelection == 'S')
            {
                meetingTypeRecord = meetingTypes[2];
            }

            else
            {
                Console.WriteLine("Please re-enter your selection.");
            }

            //get date and split into text array

            DateTime thisDay = DateTime.Today;
            string todaysDate = thisDay.ToString("d");
            string[] dateArray = todaysDate.Split('/');

            string fileName = "Minutes" + ConvertStringArrayToString(dateArray) + ".txt";
            using (StreamWriter write = new StreamWriter(fileName))
            {
                write.WriteLine(Header());
                write.WriteLine("MEETING MINUTES");
                write.WriteLine("Recorded by " + minuteRecord);
                write.WriteLine("Lead by " + leadRecord);
                write.WriteLine("Meeting Date " + dateRecord);
                write.WriteLine("Team Name: " + meetingTypeRecord);
                write.WriteLine("Topic: " + topicRecord);
                write.WriteLine("Meeting notes: " + notesRecord);
            }

            //string toMain = "garbage text";
            return fileName;
        }

        //VIEW TEAM METHOD
        public static void ViewTeam()
        {
            ProgramName();
            //users should be able to view the members of each team one team at a time

            Dictionary<string, string> teamMembers = new Dictionary<string, string>();

            teamMembers.Add("Grandpa Simpson", "Old Men Yelling at Clouds");
            teamMembers.Add("Ernest Hemingway", "Old Men Yelling at Clouds");
            teamMembers.Add("Uncle Wayne", "Old Men Yelling at Clouds");
            teamMembers.Add("David Brooks", "Old Men Yelling at Clouds");
            teamMembers.Add("Kimmy Schmidt", "Bouncy Castles");
            teamMembers.Add("Snoop Dogg", "Bouncy Castles");
            teamMembers.Add("Zooey Deschanel", "Bouncy Castles");
            teamMembers.Add("Big Bird", "Bouncy Castles");
            teamMembers.Add("Erica Sommer", "Staring Off into Space");
            teamMembers.Add("Aubrey Plaza", "Staring Off into Space");
            teamMembers.Add("Jon Hamm", "Staring Off into Space");
            teamMembers.Add("The Thinker", "Staring Off into Space");

            string omyac = "Old Men Yelling at Clouds";
            string bc = "Bouncy Castles";
            string sois = "Staring Off into Space";

            //View Menu

            Console.WriteLine("Select a team to view from the following:");
            Console.WriteLine("");
            Console.WriteLine(" O. Old Men Yelling at Clouds");
            Console.WriteLine("");
            Console.WriteLine(" B. Bouncy Castles");
            Console.WriteLine("");
            Console.WriteLine(" S. Staring Off Into Space ");
            Console.WriteLine("");
            Console.WriteLine(" A. View All Team Members");

            char meetingTypeSelection = char.Parse(Console.ReadLine().ToUpper());

            //KACY, Lauren said to ask her about this section It was working and I JUST BROKE IT *WAIL*
            if (meetingTypeSelection == 'O')
            {
                Console.WriteLine("PRINT THE OLD MEN");
                foreach (var name in teamMembers)
                {
                    if (name.Value == omyac)
                    {
                        Console.WriteLine(name.Key);
                    }
                }
            }

            else if (meetingTypeSelection == 'B')
            {
                foreach (var name in teamMembers)
                {
                    if (name.Value == bc)
                    {
                        Console.WriteLine(name.Key);
                    }
                }
            }

            else if (meetingTypeSelection == 'S')
            {
                foreach (var name in teamMembers)
                {
                    if (name.Value == sois)
                    {
                        Console.WriteLine(name.Key);
                    }
                }
            }

            else if (meetingTypeSelection == 'A')
            {
                Console.WriteLine("PRINT ALL THE MEMBERS");
                foreach (KeyValuePair<string, string> member in teamMembers)
                {
                   Console.WriteLine(member.Key);
                }
            }

            else
            {
                Console.WriteLine("invalid selection");
                //meetingTypeSelection = char.Parse(Console.ReadLine().ToUpper());
            }
        }
    


        //HEADER TEXT WITH ADDRESS method
        public static string Header()
        {
            string[] head = new string[] {
                                            "+ + + + + + + + + + + + + + + + + + +",
                                            "+     WhiZBaNG WAFFLE coRP          +",
                                            "+       123 Anytown Lane            +",
                                            "+  Somewhere Else, CA, 99901  USA   +",
                                            "+ + + + + + + + + + + + + + + + + + +"
                                             };
            StringBuilder sb = new StringBuilder();
            foreach (string value in head)
            {
                sb.Append(value);
                sb.Append("\r\n");
            }
            string headDone = sb.ToString();
            return headDone;
        }

        //this method is used by stringbuilder to convert a string array 
        //to a string.
        //the incoming string array is the date from DateTime. 
        static string ConvertStringArrayToString(string[] array)
        {
            // Concatenate all the elements into a StringBuilder.
 
            StringBuilder builder = new StringBuilder();
            builder.Append("Minutes");
            foreach (string value in array)
            {
                builder.Append(value);
            }
            return builder.ToString();
        }



        //pull on this method to write the program name
        static void ProgramName()
        {
            Console.Clear();
            string name = "MEETING MINUTES MANAGEMENT SOFTWARE \r\n";
            Console.WriteLine(name);
        }

        //STREAMREADER METHOD - not yet implemented


        static void ReadMinutes(string incomingFileName)
        {
            string fileName = incomingFileName; 
            try
            {
                StreamReader reader = new StreamReader(fileName);
                Console.WriteLine("File {0} successfully opened.", fileName);
                using (reader)
                {
                    string line = reader.ReadLine();
        int counter = 0;
        string nline;

        // Read the file and display it line by line.
        System.IO.StreamReader file = new System.IO.StreamReader(fileName);
                    while ((nline = file.ReadLine()) != null)
                    {
                        System.Console.WriteLine(nline);
                        counter++;
                    }
                }
            }

            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("Did you name it correctly? {0}.", fileName);
            }
            catch (DirectoryNotFoundException)
            {
                Console.Error.WriteLine("Where did you put it?!.");
            }
            catch (IOException)
            {
                Console.Error.WriteLine("Cannot open the file for some reason {0}", fileName);
            }
        }
    }
}
