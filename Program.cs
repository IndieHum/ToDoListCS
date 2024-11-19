namespace csharpPractice
{
  class ToDoList
  {
    public class Task
    {
      public string Description { get; set; }
      public bool IsCompleted { get; set; }

      public Task(string description)
      {
        Description = description;
        IsCompleted = false;
      }

      public override string ToString()
      {
        return $"{Description} {(IsCompleted ? "[Completed]" : "[Not Completed]")}";
      }
    }

    static void Main(string[] args)
    {
      Console.Clear();
      Console.WriteLine("*** Welcome to ToDoList ***");

      List<Task> ToDoList = new List<Task>();
      Menu(ToDoList);
    }

    static void Menu(List<Task> ToDoList)
    {
      Console.WriteLine("\nEnter your option: ");
      Console.WriteLine("\n1) Show ToDo List\n2) Add ToDo\n3) Delete Todo\n4) Edit ToDo\n5) Change Task Status\n6) Exit");

      bool isDone = false;
      while (!isDone)
      {
        Arrow();
        int userOption = Convert.ToInt32(Console.ReadLine());

        switch (userOption)
        {
          case 1:
            ShowToDoList(ToDoList);
            break;
          case 2:
            AddToDoList(ToDoList);
            break;
          case 3:
            DeleteToDoList(ToDoList);
            break;
          case 4:
            EditToDoList(ToDoList);
            break;
          case 5:
            MarkTask(ToDoList);
            break;
          case 6:
            Exit();
            break;
          default:
            isDone = true;
            break;
        }
      }
    }

    static void Arrow()
    {
      Console.Write("=> ");
    }

    static void Transfering()
    {
      Thread.Sleep(1000);
      Console.WriteLine("Please Wait...");
      Thread.Sleep(2000);
    }

    static void ViewToDoList(List<Task> ToDoList)
    {
      Console.WriteLine("vvvvvvvvvvvvvvvvvvvv");
      for (int i = 0; i < ToDoList.Count; i++)
      {
        Console.WriteLine($"{i}) {ToDoList[i]}");
      }
      Console.WriteLine("۸۸۸۸۸۸۸۸۸۸۸۸۸۸۸۸۸۸۸۸");
    }

    static void ShowToDoList(List<Task> ToDoList)
    {
      if (ToDoList.Count == 0)
      {
        Console.WriteLine("\nThere is no todo YET!\n");
        Transfering();
        Menu(ToDoList);
      }
      else
      {
        ViewToDoList(ToDoList);
        Transfering();
        Menu(ToDoList);
      }
    }


    static void AddToDoList(List<Task> ToDoList)
    {
      Console.WriteLine("\nWhat is your task?: ");
      Arrow();
      string userNewToDo = Console.ReadLine();
      Task newTask = new Task(userNewToDo);
      ToDoList.Add(newTask);
      Console.WriteLine("Added successfully!");
      Transfering();
      Menu(ToDoList);
    }

    static void DeleteToDoList(List<Task> ToDoList)
    {
      if (ToDoList.Count == 0)
      {
        Console.WriteLine("\nThere is no todo to delete!\n");
        Transfering();
        Menu(ToDoList);
      }

      ViewToDoList(ToDoList);
      Console.WriteLine("Write number id of todo you want to delete.");
      Arrow();
      int toDoId = Convert.ToInt32(Console.ReadLine());

      try
      {
        ToDoList.RemoveAt(toDoId);
      }
      catch (System.Exception)
      {
        Console.WriteLine("Wrong input!");
        throw;
      }

      Console.WriteLine("Delted succussfuly");
      Transfering();
      Menu(ToDoList);
    }

    static void EditToDoList(List<Task> ToDoList)
    {
      if (ToDoList.Count == 0)
      {
        Console.WriteLine("\nThere is no todo to edit!\n");
        Transfering();
        Menu(ToDoList);
      }

      ViewToDoList(ToDoList);
      Console.WriteLine("Write number \"id\" of todo you want to edit.");
      Arrow();
      int toDoId = Convert.ToInt32(Console.ReadLine());

      Console.WriteLine("Write your new task: ");
      Arrow();
      string newUserTask = Console.ReadLine();
      Task newTask = new Task(newUserTask);
      ToDoList[toDoId] = newTask;

      Console.WriteLine("Edited succussfuly");
      Transfering();
      Menu(ToDoList);
    }

    static void MarkTask(List<Task> ToDoList)
    {
      if (ToDoList.Count == 0)
      {
        Console.WriteLine("\nThere is no todo to change!\n");
        Transfering();
        Menu(ToDoList);
      }

      ViewToDoList(ToDoList);
      Console.WriteLine("Write number \"id\" of todo you want to change.");
      Arrow();

      if (int.TryParse(Console.ReadLine(), out int toDoId) && toDoId >= 0 && toDoId <= ToDoList.Count)
      {
        Task taskCompeleted = ToDoList[toDoId];
        taskCompeleted.IsCompleted = true;
        Console.WriteLine("Status Changed!");
      }
      else { Console.WriteLine("Wrong todo id."); }

      Transfering();
      Menu(ToDoList);
    }

    static void Exit()
    {
      Console.WriteLine("See you later!");
      Environment.Exit(0);
    }
  }
}
