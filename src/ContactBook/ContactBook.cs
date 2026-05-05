namespace ContactBook
{
    public class ContactBook
    {
        public const string NEXT_PAGE = "+";
        public const string PREV_PAGE = "-";
        private const string GOTO_PAGE = "G";
        private const string PAGE_SIZE = "S";
        private const string CREATE_CONTACT = "C";
        private const string REVIEW_CONTACT = "R";
        private const string UPDATE_CONTACT = "U";
        private const string DELETE_CONTACT = "D";
        private const string FIND_CONTACTS = "F";
        private const string ORDER_CONTACTS = "O";
        private const string DEDUPLICATE_CONTACTS = "M";
        private const string EXIT = "E";

        public readonly string[] COMANDS = new string[]
        {
            NEXT_PAGE, 
            PREV_PAGE, 
            GOTO_PAGE, 
            PAGE_SIZE, 
            CREATE_CONTACT, 
            REVIEW_CONTACT, 
            UPDATE_CONTACT, 
            DELETE_CONTACT, 
            FIND_CONTACTS, 
            ORDER_CONTACTS, 
            DEDUPLICATE_CONTACTS, 
            EXIT
        };

        public ContactBook()
        {
        }

        public void Start()
        {
            ShowWelcomeScreen();
            
            string input;
            do
            {
                ShowContacts();

                do
                {
                    ShowInputOptions();
                    input = GetInput();
                }
                while(!IsValidInput(input));

                ProcessInput(input);
            }
            while(!ConfirmExit());


            ShowExitScreen();
        }

        private void ShowWelcomeScreen()
        {
            Console.WriteLine("Welcome to the Contact Book!");
            PressEnterToContinue();
        }

        private void PressEnterToContinue()
        {
           Console.WriteLine("Press Enter to continue...");
           while(Console.ReadKey().Key != ConsoleKey.Enter);
        }

        private void ShowContacts()
        {
           
        }

        private void ShowInputOptions()
        {
            
        }

        private string GetInput()
        {
            return "";
        }

        private bool IsValidInput(string input)
        {
            return true;
        }

        private void ProcessInput(string input)
        {
           
        }

        private bool ConfirmExit()
        {
            return true;
        }

        private void ShowExitScreen()
        {
         
        }
    }
}