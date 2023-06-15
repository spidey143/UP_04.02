using System;
using System.Collections.Generic;

namespace InspectionBoard.Models;

public partial class Student
{
    public int IdStudent { get; set; }

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string? Gender { get; set; }

    public string? DateOfBirth { get; set; }

    public string? Age { get; set; }

    public string? Nationality { get; set; }

    public string? Education { get; set; }

    public string? GradePointAverage { get; set; }

    public string? Snils { get; set; }

    public string? Attestat { get; set; }

    public string? EducationalMethod { get; set; }

    public string? Admission { get; set; }

    public int? IdAdmissionImg { get; set; }

    public int? IdPlaceOfResidence { get; set; }

    public int? IdSpeciality { get; set; }

    public bool? OrphanhoodDocument { get; set; }

    public int? IdOrphanhoodDocumentImg { get; set; }
    public string? Invalid { get; set; }
    public string? Sirota { get; set;}
}
