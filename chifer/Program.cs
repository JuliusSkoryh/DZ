namespace chifer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new VigenereCipher();
            string message, key, result;
            
            Console.Write("Message: ");
            message = Console.ReadLine();

            Console.Write("Key: ");
            key = Console.ReadLine();

            result = a.Encryption(message, key);

            Console.WriteLine(result);

            Console.WriteLine(a.Decoder(result, key));

            Console.ReadKey();
        }
    }
}