using System;
using System.Data;
using System.Net.Security;
using System.Security.Cryptography;
using System.Collections.Generic;

public class Person
{
    protected int age;
    
    public string Name{get; set;}

    public int Age
    {
        get
        {
            return age; 
        }

        set
        {
            if(value < 0) value = 0;

            age = value;
        }
    }

    public Person(string name, int age)
    {
        Name = string.IsNullOrWhiteSpace(name) ? "Unknown" : name;
        Age = age;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"[Person] Name: {Name}, Age: {Age}");
    }

    public virtual void Work()
    {
        Console.WriteLine($"{Name} is doing generic tasks at the university.");
    }
}

public class Student : Person
{
    public string StudentID{get;}
    public double GPA{get; set;}

    public Student(string name, int age, string studentId,double GPA) : base(name, age)
    {
        StudentID = string.IsNullOrWhiteSpace(studentId) ? "S-000" : studentId;

        this.GPA = GPA < 0 ? 0 : (GPA > 4 ? 4 : GPA);
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[Student] Name: {Name}, Age: {Age}, ID: {StudentID}, GPA: {GPA}");
    }

    public override void Work()
    {
        Console.WriteLine($"{Name} studies, attends lectures, and completes assignments.");
    }
}

public class Teacher : Person
{
    public string EmployeeID{get;}
    public string Department{get; set;}

    public Teacher(string name, int age, string employeeId, string department) : base(name, age)
    {
        EmployeeID = string.IsNullOrWhiteSpace(employeeId) ? "T-000" : employeeId;

        Department = string.IsNullOrEmpty(department) ? "N/A" : department;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[Teacher] Name: {Name}, Age: {Age}, ID: {EmployeeID}, Dept: {Department}");
    }

    public override void Work()
    {
        Console.WriteLine($"{Name} prepares lectures, teaches students and grades exams.");
    }
}

public class GradStudent : Student
{

    public string ThesisTitle{get; set;}

    public GradStudent(string name, int age, string studentId, double gpa, string thesisTitle) 
        : base(name, age, studentId, gpa)
    {
        ThesisTitle = string.IsNullOrEmpty(thesisTitle) ? "TBD" : thesisTitle;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"[GradStudent] Name: {Name}, Age: {Age}, ID: {StudentID}, GPA: {GPA}, Thesis: {ThesisTitle}");
    }

    public override void Work()
    {
        Console.WriteLine($"{Name} conducts research, writes thesis, and assists in labs.");
    }
}

class Program
{
    static void Main()
    {
        Person p1 = new Person("Ali Yilmaz", 40);
        Student s1 = new Student("Ayşe Demir", 22, "S123", 3.6);
        Teacher t1 = new Teacher("Dr. Ali", 45, "T001", "Comp. Eng.");
        GradStudent g1 = new GradStudent("Elif Kaya", 25, "S555", 3.9, "AI in Education");

        List<Person> people = new List<Person>
        {
            p1,
            s1,
            t1,
            g1
        };

        Console.WriteLine("ShowInfo (virtual / override)");

        foreach(var person in people)
        {
            person.ShowInfo();
        }

        Console.WriteLine("Work (virtual / override)");

        foreach(var person in people)
        {
            person.Work();
        }
    }
}

/*
Person
- protected int age
- Name (auto-property)
- Age property: set'te negatifse 0
- Ctor(name, age): name boş/whitespace ise "Unknown"
- virtual ShowInfo():  [Person] Name: …, Age: …
- virtual Work():      <Name> is doing generic tasks at the university.

Student : Person
- StudentID (get-only): boş/whitespace ise "S-000"
- GPA: 0'dan küçükse 0, 4'ten büyükse 4
- Ctor(name, age, studentId, gpa) : base(name, age)
- ShowInfo: [Student] Name: …, Age: …, ID: …, GPA: …
- Work:     <Name> studies, attends lectures, and completes assignments.

Teacher : Person
- EmployeeID (get-only): boşsa "T-000"
- Department: boşsa "N/A"
- Ctor(name, age, employeeId, department) : base(name, age)
- ShowInfo: [Teacher] Name: …, Age: …, ID: …, Dept: …
- Work:     <Name> prepares lectures, teaches students and grades exams.

GraduateStudent : Student
- ThesisTitle: boşsa "TBD"
- Ctor(name, age, studentId, gpa, thesisTitle) : base(name, age, studentId, gpa)
- ShowInfo: [GradStudent] Name: …, Age: …, ID: …, GPA: …, Thesis: …
- Work:     <Name> conducts research, writes thesis, and assists in labs.

Main
- Person("Ali Yılmaz", 40)
- Student("Ayşe Demir", 22, "S123", 3.6)
- Teacher("Dr. Ali", 45, "T001", "Comp. Eng.")
- GraduateStudent("Elif Kaya", 25, "S555", 3.9, "AI in Education")
- Hepsini List<Person>'a koy (using System.Collections.Generic;)
- Yaz: "ShowInfo (virtual / override)", sonra foreach ile hepsinin ShowInfo()'su
- Yaz: "\nWork (virtual / override)", sonra foreach ile hepsinin Work()'ü
*/