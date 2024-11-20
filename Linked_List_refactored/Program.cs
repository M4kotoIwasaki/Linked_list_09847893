using System.ComponentModel.Design;
using LinkedList_template_IDZ;

public class Program
{
    static LinkedList LinkedList_1;
    static LinkedList LinkedList_2;

    public static void Menu() //A console-type graphics menu
    {
        while (true)
        {
            Console.WriteLine("Выберете задачу:\n");
            Console.WriteLine("1. Заполнение случайными числами");
            Console.WriteLine("2. Освобождение памяти");
            Console.WriteLine("3. Добавление элемента (в конец)");
            Console.WriteLine("4. Удаление всех вхождений заданного по значению элемента");
            Console.WriteLine("5. Удаление (перед каждым вхождением заданного)");
            Console.WriteLine("6. Поиск заданного элемента по значению");
            Console.WriteLine("7. Печать");
            Console.WriteLine("8. Операция работы с двумя списками (разность)");
            Console.WriteLine("9. Доп. операция (делители числа)");
            Console.WriteLine("\n10. Выход из программы");
            Console.Write("\nВаш выбор: ");

            int choice = 10;
            var tempChoice = Console.ReadLine();
            if (int.TryParse(tempChoice, out int number))
            {
                choice = number;
            }
            else
            {
                ShowError("Введен(ы) отличный(е) от цифры символ(ы). Введите число.");
                Console.WriteLine("----------------------------------------------------------\n");
            }

            switch (choice)
            {
                case 1:
                    RandomGeneration();
                    break;
                case 2:
                    MemoryFreeing();
                    break;
                case 3:
                    EndAddingElement();
                    break;
                case 4:
                    DeletingOccurrencesFunc();
                    break;
                case 5:
                    DeletingBeforeOccurrenceFunc();
                    break;
                case 6:
                    SearchByValueFunc();
                    break;
                case 7:
                    PrintFunc();
                    break;
                case 8:
                    DifferenceFunc();
                    break;
                case 9:
                    DividersFunc();
                    break;
                case 10:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" ██████╗  ██████╗  ██████╗ ██████╗ ██████╗ ██╗   ██╗███████╗");
                    Console.WriteLine("██╔════╝ ██╔═══██╗██╔═══██╗██╔══██╗██╔══██╗╚██╗ ██╔╝██╔════╝");
                    Console.WriteLine("██║  ███╗██║   ██║██║   ██║██║  ██║██████╔╝ ╚████╔╝ █████╗  ");
                    Console.WriteLine("██║   ██║██║   ██║██║   ██║██║  ██║██╔══██╗  ╚██╔╝  ██╔══╝  ");
                    Console.WriteLine("╚██████╔╝╚██████╔╝╚██████╔╝██████╔╝██████╔╝   ██║   ███████╗");
                    Console.WriteLine(" ╚═════╝  ╚═════╝  ╚═════╝ ╚═════╝ ╚═════╝    ╚═╝   ╚══════╝");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                    //break;
                default:
                    ShowError("Введён неверный пункт меню. Введите другой.");
                    Console.WriteLine("---------------------------------------------\n");
                    break;
            }
        }
    }

    private static void SuccessMessage() //Success message image
    {
        Console.Clear();
        Console.WriteLine("\n\t\t--------------");
        Console.WriteLine("\t\t| ВЫПОЛНЕНО! |");
        Console.WriteLine("\t\t--------------\n");
    }

    private static void ShowError(string errorMessage) //Error message image
    {
        Console.Clear();
        Console.WriteLine("\n\t\t-----------");
        Console.WriteLine("\t\t| ОШИБКА! |");
        Console.WriteLine("\t\t-----------\n");
        Console.WriteLine($"\"{errorMessage}\"");
    }

    private static void InitializeList(int listChoice) //Initialization of a list
    {
        //Before initializing a new list we should check if we already have one. If we have, then we should delete
        //it to avoid garbage collecting in memory. Then we create a new list. If the list is already exist, then
        //just clear it. There's no need to create a new one.

        if (listChoice == 1)
        {
            if (LinkedList_1 == null)
            {
                LinkedList_1 = new LinkedList();
            }
            else
            {
                LinkedList_1.Clear();
            }
        }
        else
        {
            if (LinkedList_2 == null)
            {
                LinkedList_2 = new LinkedList();
            }
            else
            {
                LinkedList_2.Clear();
            }
        }
    }

    public static void RandomGeneration() //this procedure is fill the list with random int numbers
    {
        int numberOfElements = 0;
        bool validInput = false;

        while (!validInput) //check for valid number of elements input
        {
            Console.Write("Введите длину списка: ");
            var tempNumberOfElements = Console.ReadLine();

            if (!int.TryParse(tempNumberOfElements, out numberOfElements) || numberOfElements < 0)
            {
                ShowError("Введен(ы) некорректный(е) символ(ы) или отрицательное число.");
                Console.WriteLine("--------------------------------------------------------------\n");
            }
            else
            {
                validInput = true;
            }
        }

        int listChoice = 0;
        validInput = false;

        while (!validInput) //check for valid number of a list
        {
            Console.Write(
                "Выберете список для работы (1, 2) или любой отличный символ для возврата в главное меню: ");
            var tempListChoice = Console.ReadLine();

            if (!int.TryParse(tempListChoice, out listChoice) || (listChoice != 1 && listChoice != 2))
            {
                Console.Clear();
                return;
            }
            else
            {
                validInput = true;
            }
        }
        
        InitializeList(listChoice); //Initializing user's list
        
        LinkedList selectedList = (listChoice == 1) ? LinkedList_1 : LinkedList_2;
        
        Random random = new Random(); //connecting randomizer
        for (int i = 0; i < numberOfElements; i++)
        {
            selectedList.AddEnd(random.Next(1, 10));
        }
        
        SuccessMessage();
    }

    public static void MemoryFreeing() //this procedure is clearing the memory by deleting the list
    {
        int listChoice = 0;
        bool validInput = false;

        while (!validInput) //check for valid number of a list
        {
            Console.Write("Выберете список для работы (1, 2) или 3 для выполнения операции для обоих списков. Чтобы вернуться в меню, введите любой другой символ.\nВаш выбор: ");
            var tempListChoice = Console.ReadLine();

            if (!int.TryParse(tempListChoice, out listChoice) || (listChoice != 1 && listChoice != 2 && listChoice != 3))
            {
                Console.Clear();
                return;
            }
            else
            {
                validInput = true;
            }
        }

        switch (listChoice)
        {
            case 1:
                if (LinkedList_1 != null)
                {
                    LinkedList_1.Clear();
                } 
                break;
            case 2:
                if (LinkedList_2 != null)
                {
                    LinkedList_2.Clear();
                } 
                break;
            case 3: //here is used 2 "if" statements because if we will use only one expression with "||", we can't delete all garbage
                if (LinkedList_1 != null)
                {
                    LinkedList_1.Clear();
                } 
                if (LinkedList_2 != null)
                {
                    LinkedList_2.Clear();
                } 
                break;
        }
        
        SuccessMessage();
    }

    public static void EndAddingElement() //this procedure is for adding element to the end of the list
    {
        int listChoice = 0;
        bool validInput = false;

        int Element = 0;

        while (!validInput) //check for valid element 
        {
            Console.Write("Введите элемент, который хотите добавить: ");
            var tempElement = Console.ReadLine();
            if (!int.TryParse(tempElement, out Element))
            {
                ShowError("Введен(ы) некорректный(е) символ(ы).");
                Console.WriteLine("--------------------------------------\n");
            }
            else
            {
                validInput = true;
            }
        }

        validInput = false;
        while (!validInput) //check for valid number of a list
        {
            Console.Write(
                "Выберете список для работы (1, 2) или любой отличный символ для возврата в главное меню: ");
            var tempListChoice = Console.ReadLine();

            if (!int.TryParse(tempListChoice, out listChoice) || (listChoice != 1 && listChoice != 2))
            {
                Console.Clear();
                return;
            }
            else
            {
                validInput = true;
            }
        }

        if (listChoice == 1)
        {
            if (LinkedList_1 != null)
            {
                LinkedList_1.AddEnd(Element);
            }
            else //if our list is null, then we shoul initialize it first and then add an element
            {
                InitializeList(listChoice);
                LinkedList_1.AddEnd(Element);
            }
        }
        else
        {
            if (LinkedList_2 != null)
            {
                LinkedList_2.AddEnd(Element);
            }
            else //if our list is null, then we shoul initialize it first and then add an element
            {
                InitializeList(listChoice);
                LinkedList_2.AddEnd(Element);
            }
        }
        
        SuccessMessage();
    }

    public static void DeletingOccurrencesFunc() //this procedure is for deleting occurrences of an element in the list
    {
        int valueToRemove = 0;
        bool validInput = false;

        while (!validInput) //check for valid value to delete
        {
            Console.Write("Введите значение для удаления: ");
            var tempValue = Console.ReadLine();

            if (!int.TryParse(tempValue, out valueToRemove))
            {
                ShowError("Введен(ы) некорректный(е) символ(ы).");
                Console.WriteLine("--------------------------------------\n");
            }
            else
            {
                validInput = true;
            }
        }

        int listChoice = 0;
        validInput = false;
        
        validInput = false;
        while (!validInput) //check for valid number of a list
        {
            Console.Write(
                "Выберете список для работы (1, 2) или любой отличный символ для возврата в главное меню: ");
            var tempListChoice = Console.ReadLine();

            if (!int.TryParse(tempListChoice, out listChoice) || (listChoice != 1 && listChoice != 2))
            {
                Console.Clear();
                return;
            }
            else
            {
                validInput = true;
            }
        }
        
        LinkedList selectedList = (listChoice == 1) ? LinkedList_1 : LinkedList_2;

        if (selectedList != null)
        {
            selectedList.DeletingOccurrences(valueToRemove);
            SuccessMessage();
        }
        else //if our list isn't initialized, then we can do nothing with it
        {
            ShowError("Список не инициализирован!");
            Console.WriteLine("----------------------------\n");
        }
    }

    public static void DeletingBeforeOccurrenceFunc() //this procedure is for deleting elements before occurrences of user's picked value
    {
        int value = 0;
        bool validInput = false;

        while (!validInput) //check for valid element for operation
        {
            Console.Write("Введите значение для выполнения операции: ");
            var tempValue = Console.ReadLine();

            if (!int.TryParse(tempValue, out value))
            {
                Console.WriteLine("Введено некорректное значение, попробуйте еще раз.");
            }
            else
            {
                validInput = true;
            }
        }

        int listChoice = 0;
        validInput = false;
        
        validInput = false;
        while (!validInput) //check for valid number of a list
        {
            Console.Write(
                "Выберете список для работы (1, 2) или любой отличный символ для возврата в главное меню: ");
            var tempListChoice = Console.ReadLine();

            if (!int.TryParse(tempListChoice, out listChoice) || (listChoice != 1 && listChoice != 2))
            {
                Console.Clear();
                return;
            }
            else
            {
                validInput = true;
            }
        }
        
        LinkedList selectedList = (listChoice == 1) ? LinkedList_1 : LinkedList_2;

        if (selectedList != null)
        {
            selectedList.DeletingBeforeOccurrence(value);
            SuccessMessage();
        }
        else //if our list isn't initialized, then we can do nothing with it
        {
            ShowError("Список не инициализирован!");
            Console.WriteLine("----------------------------\n");
        }
    }

    public static void SearchByValueFunc() //this procedure is for searching indexes of an element in the list
    {
        int valueToSearch = 0;
        bool validInput = false;

        while (!validInput)
        {
            Console.Write("Введите значение для поиска: ");
            var tempValue = Console.ReadLine();

            if (!int.TryParse(tempValue, out valueToSearch))
            {
                Console.WriteLine("Введено некорректное значение, попробуйте еще раз.");
            }
            else
            {
                validInput = true;
            }
        }

        int listChoice = 0;
        validInput = false;

        validInput = false;
        while (!validInput) //check for valid number of a list
        {
            Console.Write(
                "Выберете список для работы (1, 2) или любой отличный символ для возврата в главное меню: ");
            var tempListChoice = Console.ReadLine();

            if (!int.TryParse(tempListChoice, out listChoice) || (listChoice != 1 && listChoice != 2))
            {
                Console.Clear();
                return;
            }
            else
            {
                validInput = true;
            }
        }

        LinkedList selectedList = (listChoice == 1) ? LinkedList_1 : LinkedList_2;

        if (selectedList != null)
        {
            SuccessMessage();
            selectedList.SearchByValue(valueToSearch);
            Console.WriteLine();
        }
        else //if our list isn't initialized, then we can do nothing with it
        {
            ShowError("Список не инициализирован!");
            Console.WriteLine("----------------------------\n");
        }
    }

    private static void PrintFunc() //procedure for printing list(s)
    {
        int listChoice = 0;
        bool validInput = false;

        while (!validInput) //check for valid number of a list
        {
            Console.Write("Выберете список для печати (1, 2) или 3 для печати обоих списков. Чтобы вернуться в меню, введите любой другой символ.\nВаш выбор: ");
            var tempListChoice = Console.ReadLine();

            if (!int.TryParse(tempListChoice, out listChoice) || (listChoice != 1 && listChoice != 2 && listChoice != 3))
            {
                Console.Clear();
                return;
            }
            else
            {
                validInput = true;
            }
        }
        
        LinkedList selectedList;

        switch (listChoice)
        {
            case 1:
                SuccessMessage();
                Console.WriteLine("Список 1:\n");
                selectedList = LinkedList_1;
                if (selectedList == null)
                {
                    Console.WriteLine("Список не инициализирован!\n");
                    return;
                }
                else //if the list exist, then printing it
                {
                    if (selectedList.Empty)
                    {
                        Console.WriteLine("Список пуст.");
                    }
                    else
                    {
                        LinkedList_1.Print();
                    }
                }
                break;
            case 2:
                SuccessMessage();
                Console.WriteLine("Список 2:\n");
                selectedList = LinkedList_2;
                if (selectedList == null)
                {
                    Console.WriteLine("Список не инициализирован!\n");
                    return;
                }
                else //if the list exist, then printing it
                {
                    if (selectedList.Empty)
                    {
                        Console.WriteLine("Список пуст.");
                    }
                    else
                    {
                        LinkedList_2.Print();
                    }
                }
                break;
            case 3:
                SuccessMessage();
                Console.WriteLine("Список 1:\n");
                selectedList = LinkedList_1;
                if (selectedList == null)
                {
                    Console.WriteLine("Список не инициализирован!");
                }
                else //if the list exist, then printing it
                {
                    if (selectedList.Empty)
                    {
                        Console.WriteLine("Список пуст.");
                    }
                    else
                    {
                        LinkedList_1.Print();
                    }
                }

                Console.WriteLine("\nСписок 2:\n");
                selectedList = LinkedList_2;
                if (selectedList == null)
                {
                    Console.WriteLine("Список не инициализирован!\n");
                    return;
                }
                else //if the list exist, then printing it
                {
                    if (selectedList.Empty)
                    {
                        Console.WriteLine("Список пуст.");
                    }
                    else
                    {
                        LinkedList_2.Print();
                    }
                }
                break;
        }
        
        Console.WriteLine();
    }

    public static void DifferenceFunc() //difference operation with two sets
    {
        if ((LinkedList_1 == null) || (LinkedList_2 == null)) //check for initialization
        {
            ShowError("Какой-то из списков не инициализирован!");
            Console.WriteLine("-----------------------------------------\n");
        }
        else
        {
            LinkedList finalLinkedList = LinkedList_1.Difference(LinkedList_2); //result list (set) initialization

            if (finalLinkedList.Empty)
            {
                SuccessMessage();
                Console.WriteLine("Результат: пустое множество.\n");
            }
            else
            {
                SuccessMessage();
                Console.WriteLine("\nРезультат:\n");
                finalLinkedList.Print();
                Console.WriteLine();
            }
            
            finalLinkedList.Clear(); //deleting garbage
        }
    }

    public static void DividersFunc()
    {
        int listChoice = 0;
        bool validInput = false;
        
        validInput = false;
        while (!validInput) //check for valid number of a list
        {
            Console.Write(
                "Выберете список для работы (1, 2) или любой отличный символ для возврата в главное меню: ");
            var tempListChoice = Console.ReadLine();

            if (!int.TryParse(tempListChoice, out listChoice) || (listChoice != 1 && listChoice != 2))
            {
                Console.Clear();
                return;
            }
            else
            {
                validInput = true;
            }
        }
        
        LinkedList selectedList = (listChoice == 1) ? LinkedList_1 : LinkedList_2;

        if (selectedList != null)
        {
            LinkedList finalLinkedList = selectedList.Dividers(selectedList);
            Console.WriteLine("\nРезультат:\n");
            finalLinkedList.Print();
            Console.WriteLine();
            finalLinkedList.Clear(); //deleting garbage
        }
        else //if our list isn't initialized, then we can do nothing with it
        {
            ShowError("Список не инициализирован!");
            Console.WriteLine("----------------------------\n");
        }
    }
    public static void Main(string[] args)
        {
            Menu();
            Console.WriteLine("\nНажмите Enter, чтобы закрыть окно программы...");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {
            }
        }
}