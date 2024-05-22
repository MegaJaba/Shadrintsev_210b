namespace event_ {
    internal class Program {
    // Событие
    public static event EventHandler<UserEnteredNumberEventArgs> UserEnteredNumber;
    // Функция вывода числа введенного пользователем
    private static void PrintUserEnteredNumber(object sender, UserEnteredNumberEventArgs e) {
        Console.WriteLine($"\nПользователь ввел число {e.Input} в {e.EnteredAt}\n");
    }
    static void Main(string[] args) {
        string input;
        int number;

        // Подписка на событие
        UserEnteredNumber += PrintUserEnteredNumber;

        while (true) {
            Console.Write("Введите число > ");

            input = Console.ReadLine();

            if (int.TryParse(input, out number)) {
                // Вызов события
                UserEnteredNumber?.Invoke(null, new UserEnteredNumberEventArgs { Input = number, EnteredAt = DateTime.Now });
            }
        }
    }
    // Объект аргументов события
    public class UserEnteredNumberEventArgs {
        public int Input { get; set; }
        public DateTime EnteredAt { get; set; }
    }
}
}