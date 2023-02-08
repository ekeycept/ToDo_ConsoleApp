using System;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace Program
{
    class Program
    {
        static void Main()
        {
            StreamReader sr = new StreamReader("ToDo.txt");
            string[] oldToDoList = new string[100];
            int j = 0;
            int numberOfRealPlans = 0;
            for (j = 0; j < oldToDoList.Length; j++)
            {
                oldToDoList[j] = sr.ReadLine();
            }
            if (oldToDoList[0] != null)
            {
                j = 0;
                while (oldToDoList[j] != null)
                {
                    j++;
                    numberOfRealPlans++;
                }
                j = 0;
                string[] newToDoList = new string[numberOfRealPlans];
                for (j = 0; j < numberOfRealPlans; j++)
                    newToDoList[j] = oldToDoList[j];
                sr.Close();
                ShowToDoList(newToDoList);
                WantToDelete(ref newToDoList, ref numberOfRealPlans);
                StreamWriting(newToDoList, numberOfRealPlans);
                ShowToDoList(newToDoList);

            }
            else
            {
                sr.Close();
                Console.WriteLine("******* Список дел *******");
                Console.WriteLine("Сколько дел вы планируете внести в список?");
                int NumberOfPlans = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите названия дел, разделяя их клавишей Enter");
                string[] ToDoList = new string[NumberOfPlans];
                if (NumberOfPlans == 0)
                {
                    Console.WriteLine("Нельзя создать пустой список! Попробуйте снова");
                    Console.ReadLine();
                }
                else
                {
                    for (int i = 0; i < ToDoList.Length; i++)
                        ToDoList[i] = Console.ReadLine();
                    ShowToDoList(ToDoList);
                    WantToDelete(ref ToDoList, ref NumberOfPlans);
                    StreamWriting(ToDoList, NumberOfPlans);
                }

            }
        }

        private static void ShowToDoList(string[] List)
        {
            Console.Clear();
            Console.WriteLine("Ваш список дел:");
            for (int i = 0; i < List.Length; i++)
                Console.WriteLine("{0}. {1}", i + 1, List[i]);
        }

        private static void WantToDelete(ref string[] ToDoList, ref int NumberOfPlans)
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Хотите редактировать/удалить дело?");
            string answer = Console.ReadLine();
            switch (answer)
            {
                case "Удалить":
                    Console.WriteLine("Введите номер дела:");
                    int deleteNumber = Convert.ToInt32(Console.ReadLine());
                    DeleteFromList(ref ToDoList, ref NumberOfPlans, deleteNumber);
                    ShowToDoList(ToDoList);
                    break;
                case "Редактировать":
                    Console.WriteLine("Введите номер дела:");
                    deleteNumber = Convert.ToInt32(Console.ReadLine());
                    ChangeToDoList(ref ToDoList, ref NumberOfPlans, deleteNumber);
                    ShowToDoList(ToDoList);
                    break;
                default:
                    Console.ReadLine();
                    break;
            }
        }

        private static void DeleteFromList(ref string[] List, ref int NumberOfPlans, int number)
        {
            int needNumber = number - 1;
            NumberOfPlans--;
            string[] ToDoList_Copy = new string[NumberOfPlans];
            for (int i = 0; i < needNumber; i++)
                ToDoList_Copy[i] = List[i];
            for (int i = (needNumber + 1); i < List.Length; i++)
                ToDoList_Copy[i - 1] = List[i];
            List = ToDoList_Copy;
            ShowToDoList(List);
            WantToDelete(ref List, ref NumberOfPlans);
        }

        private static void ChangeToDoList(ref string[] List, ref int NumberOfPlans, int number)
        {
            int needNumber = number - 1;
            Console.WriteLine("На что хотите заменить?");
            string changedLine = Console.ReadLine();
            List[needNumber] = changedLine;
            ShowToDoList(List);
            WantToDelete(ref List, ref NumberOfPlans);
        }

        private static void StreamWriting(string[] List, int NumberOfPlans)
        {
            StreamWriter sw = new StreamWriter("C:\\Users\\gorbo\\Desktop\\ToDo.txt", false, Encoding.UTF8);
            for (int i = 0; i < NumberOfPlans; i++)
                sw.WriteLine(List[i]);
            sw.Close();
        }

    }

}

