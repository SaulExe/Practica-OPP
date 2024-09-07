using System;
using System.Collections.Generic;


public abstract class Persona
{
    public string Nombre { get; set; }

    public Persona(string nombre)
    {
        Nombre = nombre;
    }
}


public class Estudiante : Persona
{
    public int NumeroUnico { get; set; }

    public Estudiante(string nombre, int numeroUnico) : base(nombre)
    {
        NumeroUnico = numeroUnico;
    }
}

public class Profesor : Persona
{
    public List<Curso> Cursos { get; set; }

    public Profesor(string nombre) : base(nombre)
    {
        Cursos = new List<Curso>();
    }

    public void AgregarCurso(Curso curso)
    {
        Cursos.Add(curso);
    }
}

public class Curso
{
    public string Nombre { get; set; }
    public int RecuentoClases { get; set; }
    public int RecuentoEjercicios { get; set; }

    public Curso(string nombre, int recuentoClases, int recuentoEjercicios)
    {
        Nombre = nombre;
        RecuentoClases = recuentoClases;
        RecuentoEjercicios = recuentoEjercicios;
    }
}

public class Clase
{
    public string Identificador { get; set; }
    public List<Estudiante> Estudiantes { get; set; }
    public List<Profesor> Profesores { get; set; }

    public Clase(string identificador)
    {
        Identificador = identificador;
        Estudiantes = new List<Estudiante>();
        Profesores = new List<Profesor>();
    }

    public void AgregarEstudiante(Estudiante estudiante)
    {
        Estudiantes.Add(estudiante);
    }

    public void AgregarProfesor(Profesor profesor)
    {
        Profesores.Add(profesor);
    }
}

public class Escuela
{
    public string Nombre { get; set; }
    public List<Clase> Clases { get; set; }

    public Escuela(string nombre)
    {
        Nombre = nombre;
        Clases = new List<Clase>();
    }

    public void AgregarClase(Clase clase)
    {
        Clases.Add(clase);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Escuela escuela = new Escuela("Escuela Primaria");

        Clase clase1 = new Clase("1A");

        Console.WriteLine("¿Cuántos estudiantes desea agregar?");
        int cantidadEstudiantes = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < cantidadEstudiantes; i++)
        {
            Console.WriteLine($"Ingrese el nombre del estudiante {i + 1}: ");
            string nombreEstudiante = Console.ReadLine();

            Console.WriteLine($"Ingrese el número único del estudiante {i + 1}: ");
            int numeroUnico = Convert.ToInt32(Console.ReadLine());

            Estudiante estudiante = new Estudiante(nombreEstudiante, numeroUnico);
            clase1.AgregarEstudiante(estudiante);
        }

        Profesor profesor1 = new Profesor("Profesor García");
        Curso cursoMatematicas = new Curso("Matemáticas", 30, 10);
        profesor1.AgregarCurso(cursoMatematicas);

        clase1.AgregarProfesor(profesor1);

        escuela.AgregarClase(clase1);

        Console.WriteLine($"Escuela: {escuela.Nombre}");
        foreach (var clase in escuela.Clases)
        {
            Console.WriteLine($"Clase: {clase.Identificador}");
            Console.WriteLine("Estudiantes:");
            foreach (var estudiante in clase.Estudiantes)
            {
                Console.WriteLine($"- {estudiante.Nombre} (ID: {estudiante.NumeroUnico})");
            }

            Console.WriteLine("Profesores:");
            foreach (var profesor in clase.Profesores)
            {
                Console.WriteLine($"- {profesor.Nombre}");
                Console.WriteLine("Cursos impartidos:");
                foreach (var curso in profesor.Cursos)
                {
                    Console.WriteLine($"  - {curso.Nombre} (Clases: {curso.RecuentoClases}, Ejercicios: {curso.RecuentoEjercicios})");
                }
            }
        }
    }
}
