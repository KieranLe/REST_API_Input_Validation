using PhoneBook.Exceptions;
using PhoneBook.Model;

namespace PhoneBook.Services
{
    public class DictionaryPhoneBookService : IPhoneBookService
    {
        private readonly Dictionary<string, string> _phoneBookEntries;
        
        // Filenames and Its directory 
        // Please change this to the directory of your desire 
        //string fileName = @"C:\UTA\phonebook.txt";      // Store data for Windows
        //string logName  = @"C:\UTA\log.txt";            // Timestamp log for Windows
        string fileName = @"/home/phonebook.txt";       // Store data for Docker Desktop container
        string logName =  @"/home/log.txt";            // Timestaps log Docker Desktop container
        // This count variable is used in the WriteLog() to make sure that
        // it checks if file empty or not one time only.
        int count = 0;


        public DictionaryPhoneBookService()
        {
            _phoneBookEntries = new Dictionary<string, string>();
        }

        // Write data into text file
        public void WriteFile()
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (KeyValuePair<string, string> kvp in _phoneBookEntries)
                {
                    writer.WriteLine(kvp.Key + " " + kvp.Value);
                }
            }
        }

        // Write timestamp for each action (add, list, remove)
        public void WriteLog(string type, string message)
        {
            // Check to see if file already exists or not (only check 1 time)
            // If exists and file is not empty, earse all data in there.
            // Purpose: to have a new empty file every time the software runs.
            if (File.Exists(logName))
            {
                if (new FileInfo(logName).Length > 0 && count == 0)
                {
                    File.WriteAllText(logName, String.Empty);
                }
            }
 
            // Timestamp information for each entry, depending on the type of action
            using (StreamWriter writer = new StreamWriter(logName, true))
            {
                // Add a user
                if( String.Equals(type, "add") ) 
                {
                    writer.WriteLine($"{DateTime.Now} : Username \"{message}\" has been ADDED to the Phonebook.");
                }
                // Remove a user
                else if( String.Equals(type, "remove") )
                {
                    writer.WriteLine($"{DateTime.Now} : Username \"{message}\" has been REMOVE from the Phonebook.");
                }
                // List all names
                else
                {
                    writer.WriteLine($"{DateTime.Now} : A user requested to list all name in the Phonebook.");
                }
                count++;
                writer.Close();
            }
        }


        public void Add(PhoneBookEntry phoneBookEntry)
        {
            if (phoneBookEntry.Name == null || phoneBookEntry.PhoneNumber == null)
            {
                throw new ArgumentException("Name and phone number must both be specified.");
            }

            WriteLog("add", phoneBookEntry.Name);
            _phoneBookEntries.Add(phoneBookEntry.Name, phoneBookEntry.PhoneNumber);
            WriteFile();
        }

        public void Add(string name, string phoneNumber)
        {
            if (name == null || phoneNumber == null)
            {
                throw new ArgumentException("Name and phone number must both be specified.");
            }

            _phoneBookEntries.Add(name, phoneNumber);
            WriteFile();
            
        }

        public IEnumerable<PhoneBookEntry> List()
        {
            List<PhoneBookEntry> entriesList = new List<PhoneBookEntry>();

            foreach (var name in _phoneBookEntries.Keys)
            {
                entriesList.Add(new PhoneBookEntry { Name = name, PhoneNumber = _phoneBookEntries[name] });
            }

            // Since this is list action, the second argument is just an "okay" string
            WriteLog("list", "ok");
            return entriesList;
        }

        public void DeleteByName(string name)
        {
            if (!_phoneBookEntries.ContainsKey(name))
            {
                throw new NotFoundException($"No phonebook entry found containing name {name}.");
            }

            WriteLog("remove", name);
            _phoneBookEntries.Remove(name);
            WriteFile();
        }

        public void DeleteByNumber(string number)
        {
            var name = _phoneBookEntries.Where(kvp => kvp.Value == number).FirstOrDefault().Key;
            if (name == null)
            {
                throw new NotFoundException($"No phonebook entry found containing phone number {number}.");
            }

            WriteLog("remove", name);
            _phoneBookEntries.Remove(name);
            WriteFile();
        }
    }
}
