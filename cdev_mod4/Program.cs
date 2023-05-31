using System;

namespace cdev_mod4
{
    class Program
    {
        static void Main(string[] args)
        {
           
            static bool IntValidation(in int value)
            {
                if (value <= 0)
                {
                    Console.WriteLine("Ошибка ввода. Введи ответ еще раз");
                    return false;
                } else
                {
                    return true;
                }
            }
            
            static string[] GetPetNames(in int Amount)
            {
                string[] PetNames = new string[Amount];
                for (int i = 0; i < Amount; i++)
                {
                    Console.Write($"Введи имя питомца #{i+1}: ");
                    PetNames[i] = Console.ReadLine();
                }
                return PetNames;
            }

            static string[] GetFavouriteColors(in int Amount)
            {
                string[] FavouriteColors = new string[Amount];
                for (int i = 0; i < Amount; i++)
                {
                    Console.Write($"Введи любимый цвет #{i + 1}: ");
                    FavouriteColors[i] = Console.ReadLine();
                }
                return FavouriteColors;
            }

            static (string, string, int, bool, int, string[], int, string[]) Questions()
            {
                (string FirstName, string SecondName, int Age, bool HavePet, int PetAmount, string[] PetNames, int FavouriteColorsAmount, string[] FavouriteColors) UserData = ("", "", 0, false, 0, null, 0, null);

                Console.Write("Привет, давай знакомиться!\nВведи свое имя: ");
                UserData.FirstName = Console.ReadLine();
                Console.Write("И фамилию: ");
                UserData.SecondName = Console.ReadLine();
                Console.WriteLine("Возраст: ");
                do
                {
                    UserData.Age = Int32.Parse(Console.ReadLine());
                } while (!IntValidation(UserData.Age));
                

                Console.Write($"Отлично, {UserData.FirstName}! А теперь расскажи побольше о себе.\nЕсть ли у тебя питомец? (да/нет): ");
                string PetAnswer = Console.ReadLine();
                if (PetAnswer == "да")
                {
                    UserData.HavePet = true;
                    Console.WriteLine("Отлично! Сколько у тебя питомцев?");
                    do
                    {
                        UserData.PetAmount = Int32.Parse(Console.ReadLine());
                    } while (!IntValidation(UserData.PetAmount));
                    UserData.PetNames = GetPetNames(UserData.PetAmount);
                }
                else
                {
                    UserData.HavePet = false;
                    Console.WriteLine("Что ж, тогда идем дальше.");
                }
                Console.WriteLine("Сколько у тебя любимых цветов: ");
                do
                {
                    UserData.FavouriteColorsAmount = Int32.Parse(Console.ReadLine());
                } while (!IntValidation(UserData.FavouriteColorsAmount));
                
                    UserData.FavouriteColors = GetFavouriteColors(UserData.FavouriteColorsAmount);

                return UserData;
            }


            static void DisplayAnswer(in (string FirstName, string SecondName, int Age, bool HavePet, int PetAmount, string[] PetNames, int FavouriteColorsAmount, string[] FavouriteColors) UserData)
            {
                Console.Clear();
                Console.WriteLine($"Анкета пользователя: {UserData.FirstName} {UserData.SecondName}\n" +
                    $"Возраст: {UserData.Age}\n");
                if (UserData.HavePet)
                {
                    Console.Write("Наличие питомца: да" +
                        $"\nКоличество питомцев: {UserData.PetAmount} (");
                    for (int i = 0; i < UserData.PetAmount; i++)
                    {
                        Console.Write(UserData.PetNames[i]);
                        if (i < UserData.PetAmount - 1)
                        {
                            Console.Write(", ");
                        }
                    }
                    Console.Write(")");
                   
                }
                Console.Write($"\nКоличество любимых цветов: {UserData.FavouriteColorsAmount} (");
                for (int i = 0; i < UserData.FavouriteColorsAmount; i++)
                {
                    Console.Write(UserData.FavouriteColors[i]);
                    if (i < UserData.FavouriteColorsAmount - 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.Write(")");
            }

           var Answer = Questions();
            DisplayAnswer(Answer);
            
            
        }
    }
}
