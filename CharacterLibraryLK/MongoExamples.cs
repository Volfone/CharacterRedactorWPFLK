using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterRedactorLK
{
    public class MongoExamples
    {
        public static void AddToDB(Character character)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("CharacterDB");
            var collection = database.GetCollection<Character>("Characters");
            collection.InsertOne(character);

        }

        public static List<Character> FindAll()
        {
            var client = new MongoClient();
            var database = client.GetDatabase("CharacterDB");
            var collection = database.GetCollection<Character>("Characters");
            var list = collection.Find(x => true).ToList();
            foreach (var item in list)
            {
                Console.WriteLine($" {item?.Name}");
            }
            return list;
        }

        public static Character Find(string name)
        {
            var client = new MongoClient();
            var database = client.GetDatabase("CharacterDB");
            var collection = database.GetCollection<Character>("Characters");
            var one = collection.Find(x => x.Name == name).FirstOrDefault();
            return one;
/*
                Console.WriteLine($" {one?.Name} {one?.Email} {one?.Age} {one?.DriverCard}");*/


        }
    }
}
