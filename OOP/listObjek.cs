using System;
using System.Collections.Generic;
					
public class Program
{
	public static void Main()
	{
		Team team1 = new Team("Greatest");
		Person person1 = new Person("Agung", "Zuhdi");
		Console.WriteLine(person1.f_name);
		Person person2 = new Person("Chandra", "Zuhdi");
		Console.WriteLine(person1.f_name);
		Person person3 = new Person("Hasan", "Zuhdi");
		Console.WriteLine(person1.f_name);
		team1.addPlayer(person1);
		team1.addPlayer(person2);
		team1.addPlayer(person3);
		team1.printTeamPlayers();
	}
}

public class Person
{
	public string f_name;
	public string l_name;
	
	public Person(string name1, string name2){
		f_name = name1;
		l_name = name2;
	}
}

public class Team 
{
	public string name;
	public List<Person> teamPlayer;
	
	public Team(string nameVal){
		name = nameVal;
		teamPlayer = new List<Person>();
	}
	
	public void addPlayer(Person player){
		teamPlayer.Add(player);
	}
	
	public void printTeamPlayers(){
		Console.WriteLine("Team "+name);
		Console.WriteLine("Team player :");
		foreach (var player in teamPlayer){
			Console.WriteLine(player.f_name+" "+player.l_name);
		}
	}
}
	