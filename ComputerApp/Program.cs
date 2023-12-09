// Новый проект (ComputerApp)

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ComputerLibrary;

namespace ComputerApp
{
    class Serializator
    {
        public static void SerializeComputerList(List<Computer> computers, string filePath)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    formatter.Serialize(stream, computers);
                    Console.WriteLine("Serialization successful.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during serialization: {ex.Message}");
            }
        }
    }

    class Deserializator
    {
        public static List<Computer> DeserializeComputerList(string filePath)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    List<Computer> computers = (List<Computer>)formatter.Deserialize(stream);
                    Console.WriteLine("Deserialization successful.");
                    return computers;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
                return null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Пример использования
            List<Computer> computers = new List<Computer>
            {
                new Computer("HP", "123456", "2021"),
                new Computer("Dell", "789012", "2021")
            };

            string filePath = "ComputerList.dat";

            // Сериализация
            Serializator.SerializeComputerList(computers, filePath);

            // Десериализация
            List<Computer> deserializedComputers = Deserializator.DeserializeComputerList(filePath);

            // Пример использования десериализованного списка
            if (deserializedComputers != null)
            {
                foreach (var computer in deserializedComputers)
                {
                    Console.WriteLine($"Brand: {computer.Brand}, Serial Number: {computer.SerialNumber}, Date of Production: {computer.Year}");
                }
            }
        }
    }
}
