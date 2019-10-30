using System;
using DebateApp.Models;
using DebateApp.DataAccess.Repository;
using DebateApp.DataAccess;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DebateApp.MigrationTool
{

	class Program
	{
		public class Parce_and_validation
		{
			public List<Person> ReadFile(string filename)
			{

				List<Person> persons = new List<Person>();
				using (StreamReader sr = new StreamReader(filename))
				{
					string line;
					while ((line = sr.ReadLine()) != null)
					{
						Person person = new Person();
						string[] parts = line.Split(' ');
						person.FirstName = parts[0];
						person.LastName = parts[1];
						person.Email = parts[2];
						persons.Add(person);
					}
				}
				return persons;
			}
			public List<Person> EmailDualValidation(List<Person> row_list)
			{
				List<Person> normal_person = new List<Person>();
				foreach(var p in row_list)
				{
					if (!normal_person.Any(n => n.Email == p.Email)) normal_person.Add(p);
					else Console.WriteLine($"Пользователь с данным Email: {p.Email} уже существует");
				}
				return normal_person;
			}
			public List<Person> NameDualValidation(List<Person> row_list)
			{
				List<Person> normal_person = new List<Person>();
				foreach (var p in row_list)
				{
					if (!normal_person.Any(n => n.FirstName+n.LastName == p.FirstName+p.LastName)) normal_person.Add(p);
					else Console.WriteLine($"Пользователь с данным именем: {p.FirstName} {p.LastName} уже существует");
				}
				return normal_person;
			}
			public List<Person> EmailValidation(List<Person> row_list)
			{
				List<Person> normal_person = new List<Person>();
				foreach(var p in row_list)
				{
					string email = p.Email;
					string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
					@"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
					@".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
					Regex re = new Regex(strRegex);
					if (re.IsMatch(email)) normal_person.Add(p);
					else Console.WriteLine($"Данный Email: {p.Email} не действителен");
				}
				return normal_person;
			}
			public List<Person> SymbolValidation(List<Person> row_list)
			{
				List<Person> normal_person = new List<Person>();
				foreach (var p in row_list)
				{
					string FirstName = p.FirstName;
					string LastName = p.LastName;
					//Чтобы было проще переводим в нижний регистр:
					FirstName = FirstName.ToLower();
					LastName = LastName.ToLower();
					//Переводим в код (с кодировкой Default):
					byte[] FirstNameByte = System.Text.Encoding.Default.GetBytes(FirstName);
					byte[] LastNameByte = System.Text.Encoding.Default.GetBytes(LastName);
					byte[] AllName = FirstNameByte.Concat(LastNameByte).ToArray();
					//Проверяем так:
					int angl_count = 0;
					int russ_count = 0;
					foreach (byte b in AllName)
					{
						if ((b >= 97) && (b <= 122)) angl_count++;
						if ((b >= 192) && (b <= 239)) russ_count++;
					}
					if (angl_count > 0)
					{
						Console.WriteLine($"Данное имя {p.FirstName} {p.LastName} недопустимо");
					}
					else normal_person.Add(p);
				}
				return normal_person;
			}
			public List<Person> GetValidData(List<Person> row_list)
			{
				List<Person> persons = EmailDualValidation(row_list);
				persons = NameDualValidation(persons);
				persons = SymbolValidation(persons);
				persons = EmailValidation(persons);
				return persons;
			}
		}
		static void Main(string[] args)
		{
			Parce_and_validation parce_And_Validation = new Parce_and_validation();
			DebateContext db = new DebateContext();
			string filename = @"C:/fff/test.txt"; //Задайте относительный путь и киньте csv файл в папку с проектом плез
			PersonRepository personRepository = new PersonRepository(db);
			List <Person> row_data = parce_And_Validation.ReadFile(filename);
			List<Person> valid_person = parce_And_Validation.GetValidData(row_data);
			foreach(var p in valid_person)
			{
				personRepository.Add(p);
			}
		}
	}
}

