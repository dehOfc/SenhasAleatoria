using System;
using System.Security.Cryptography;

public class PasswordGenerator
{
    private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()";

    public static string GeneratePassword(int length)
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            var bytes = new byte[length];
            rng.GetBytes(bytes);

            var password = new char[length];
            for (int i = 0; i < length; i++)
            {
                password[i] = Characters[bytes[i] % Characters.Length];
            }

            return new string(password);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Digite o tamanho da senha desejada:");
        int length = int.Parse(Console.ReadLine());

        string password = PasswordGenerator.GeneratePassword(length);
        Console.WriteLine("Senha gerada: " + password);
    }
}
