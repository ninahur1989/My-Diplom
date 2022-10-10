using DishBurger.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DishBurger.Data.Static
{
    public static class JwtToken
    {
        public const string _tokenFilePath = @"C:\Users\Admin\Desktop\my-full-shop\Diplom\DishBurger\token.json";
        public static string currentToken = GetToken();

        public static void SetToken(string token)
        {
            currentToken = token;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("jwt", currentToken);

            string json = System.Text.Json.JsonSerializer.Serialize(dictionary);
            File.WriteAllText(_tokenFilePath, json);
        }

        public static void EndSession()
        {
            currentToken = "";
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("jwt", currentToken);

            string json = System.Text.Json.JsonSerializer.Serialize(dictionary);
            File.WriteAllText(_tokenFilePath, json);
        }

        public static string  GetToken()
        {
            using(StreamReader reader = new StreamReader(_tokenFilePath))
            {
                string jsonString = reader.ReadToEnd();
                var response = JsonConvert.DeserializeObject<Jwtmodel>(jsonString);
                return response.jwt.ToString();
            }
        }

    }  
}
