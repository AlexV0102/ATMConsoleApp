namespace ATMConsole
{
    public class cardHolder
    {
        String cardNum;
        int pin;
        String firstName;
        String lastName;
        double balance;
        public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
        {
            this.cardNum = cardNum;
            this.pin = pin;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
        }
        public String getNum()
        {
            return cardNum;
        }
        public int getPin()
        {
            return pin;
        }
        public String getFirstName()
        {
            return firstName;
        }
        public String getLastName()
        {
            return lastName;
        }
        public double getBalance()
        {
            return balance;
        }
        public void setCardNum(string newCardNum)
        {
            cardNum = newCardNum;
        }
        public void setFirstName(string newFirstName)
        {
            firstName = newFirstName;
        }
        public void setLastName(string newLastName)
        {
            lastName = newLastName; 
        }
        public void setPin(int newPin)
        {
            pin = newPin;
        }
        public void setBalance( double newBalance)
        {
            balance = newBalance;
        }
        public static void Main(string[] args)
        {
            void printOptions()
            {
                Console.WriteLine("Choose option:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show balance");
                Console.WriteLine("4. exit");

            }
            void deposit(cardHolder currentUser)
            {
                Console.WriteLine("How much $$ you would like to deposit?");
                double deposit = Double.Parse(Console.ReadLine());
                currentUser.setBalance(deposit + currentUser.getBalance());
                Console.WriteLine("Thank you, operation complete, your curent balance: " + currentUser.getBalance());
            }
            void withdraw(cardHolder currentUser)
            {
                Console.WriteLine("How much $$ you would like to withdraw?");
                double withdraw = Double.Parse(Console.ReadLine());
                if( currentUser.getBalance() < withdraw)
                {
                    Console.WriteLine("Insufficient balance :(");
                }
                else
                {
                    double newBalance = currentUser.getBalance() - withdraw;
                    currentUser.setBalance(newBalance);
                }
                
            }
            void balance(cardHolder currentUser)
            {
                Console.WriteLine("Current balance" + currentUser.getBalance());
            }
            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("4485845474357112", 1234, "Yuriy", "Kobol", 123.08));
            cardHolders.Add(new cardHolder("5536213486370316", 0123, "Dima", "Koval", 12345.12));
            cardHolders.Add(new cardHolder("4532935672244916", 0987, "Alex", "Melnik", 58));
            cardHolders.Add(new cardHolder("5485815330510938", 4321, "Vova", "Goga", 1000.5));
            cardHolders.Add(new cardHolder("5136701322138248", 4312, "Ivan", "Smith", 5897.12));

            Console.WriteLine("Welcome to ConsoleATM :)");
            Console.WriteLine("Enter your card number: ");
            string debitCardNum = "";
            cardHolder currentUser;
            while (true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if (currentUser != null) break;
                    else Console.WriteLine("Card not recognized. Please try again:");
                }
                catch (Exception)
                {
                    Console.WriteLine("Card not recognized. Please try again:");
                    
                }

            }
            Console.WriteLine("Enter your pin: ");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    
                    if (currentUser.getPin() == userPin) break;
                    else Console.WriteLine("Incorrect pin. Please try again:");
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect pin. Please try again:");

                }

            }
            Console.WriteLine("Welcome" + currentUser.getFirstName() + " :)");
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {

                    
                } if (option == 1) deposit(currentUser);
                else if (option == 2) withdraw(currentUser);
                else if (option == 3) balance(currentUser);
                else if (option == 4) break;
                else option = 0;
                   
            } while (option != 4);
            Console.WriteLine("Thank you, have a nice day :)");
        }
    }
   
    
}