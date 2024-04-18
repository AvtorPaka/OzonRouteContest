namespace MainApp;
public static partial class SolutionsClass
{
    static partial void Task2();
    static partial void Task3();
    static partial void Task4();
    static partial void Task5();
    static partial void Task6();
    static partial void Task7();

    public static void CallSolution(int taskNumber, bool isTestTask = false)
    {
        Action currentTask = taskNumber switch
        {
            1 => isTestTask ? TestTask1 : () => Console.WriteLine("Lost in procces"),
            2 => isTestTask ? TestTask2 : Task2,
            3 => isTestTask ? TestTask3 : Task3,
            4 => isTestTask ? TestTask4 : Task4,
            5 => isTestTask ? TestTask5 : Task5,
            6 => isTestTask ? TestTask6 : Task6,
            7 => isTestTask ? TestTask7 : Task7,
            _ => () => Console.WriteLine("There is no such a task.")
        };

        try {currentTask?.Invoke();}
        catch (Exception ex) {
            Console.WriteLine($"{ex.Message}\nInvalid input data was given to the task.Read the description before testing.");
        }
    }
}