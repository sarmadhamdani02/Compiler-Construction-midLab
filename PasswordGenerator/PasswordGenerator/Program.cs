using System;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // Use your name and registration number
        string firstName = "Sarmad";
        string lastName = "Hamdani"; // Change this to your actual last name if different
        string regNumber = "021";

        string password = GeneratePassword(firstName, lastName, regNumber);
        Console.WriteLine($"Generated Password: {password}");
    }

    static string GeneratePassword(string firstName, string lastName, string regNumber)
    {
        // Extract letters
        char firstLetterFirstName = firstName[0];
        char lastLetterFirstName = firstName[firstName.Length - 1];

        // Extract second letters
        char secondLetterFirstName = firstName.Length > 1 ? firstName[1] : 'A'; // Default to 'A'
        char secondLetterLastName = lastName.Length > 1 ? lastName[1] : 'A';   // Default to 'A'

        // Generate password components
        StringBuilder passwordBuilder = new StringBuilder();
        passwordBuilder.Append(regNumber);                         // 1. Registration number
        passwordBuilder.Append(firstLetterFirstName);             // 2. First letter of first name
        passwordBuilder.Append(lastLetterFirstName);              // 2. Last letter of first name
        passwordBuilder.Append(secondLetterFirstName);            // 3. Second letter of first name
        passwordBuilder.Append(secondLetterLastName);             // 3. Second letter of last name

        // Add random special characters
        passwordBuilder.Append(GetRandomSpecialCharacters(2));     // 5. Special characters

        // Ensure password has at least 14 characters and does not contain '#'
        string password = passwordBuilder.ToString();

        if (password.Length < 14)
        {
            password += GetRandomAlphabets(14 - password.Length); // Fill remaining characters
        }

        // Check if it meets all criteria
        return ValidatePassword(password) ? password : "Failed to generate a valid password.";
    }

    static string GetRandomSpecialCharacters(int count)
    {
        const string specialChars = "!@#$%^&*()-_=+[]{}|;:',.<>?";
        Random random = new Random();
        StringBuilder specialCharacters = new StringBuilder();

        for (int i = 0; i < count; i++)
        {
            specialCharacters.Append(specialChars[random.Next(specialChars.Length)]);
        }

        return specialCharacters.ToString();
    }

    static string GetRandomAlphabets(int count)
    {
        const string alphabets = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Random random = new Random();
        StringBuilder randomAlphabets = new StringBuilder();

        for (int i = 0; i < count; i++)
        {
            randomAlphabets.Append(alphabets[random.Next(alphabets.Length)]);
        }

        return randomAlphabets.ToString();
    }

    static bool ValidatePassword(string password)
    {
        // Regex conditions
        string pattern = @"^(?=.*[a-zA-Z])(?=.*[!@#$%^&*()\-_=+[\]{}|;:',.<>?])[^\#]{14,}$";
        return Regex.IsMatch(password, pattern);
    }
}
