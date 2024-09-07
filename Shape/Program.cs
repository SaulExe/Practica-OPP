using System;

public abstract class Shape
{
    public double Ancho { get; set; }
    public double Alto { get; set; }

    public Shape(double ancho, double alto)
    {
        Ancho = ancho;
        Alto = alto;
    }

    public abstract double CalculateSurface();
}

public class Rectangle : Shape
{
    public Rectangle(double ancho, double alto) : base(ancho, alto) { }

    public override double CalculateSurface()
    {
        return Ancho * Alto;
    }
}

public class Triangle : Shape
{
    public Triangle(double ancho, double alto) : base(ancho, alto) { }

    public override double CalculateSurface()
    {
        return (Ancho * Alto) / 2;
    }
}

public class Circle : Shape
{
    public Circle(double radio) : base(radio, radio) { }

    public override double CalculateSurface()
    {
        return Math.PI * Math.Pow(Ancho, 2);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Seleccione una forma geométrica:");
        Console.WriteLine("1. Rectángulo");
        Console.WriteLine("2. Triángulo");
        Console.WriteLine("3. Círculo");
        int opcion = Convert.ToInt32(Console.ReadLine());

        Shape shape = null;

        switch (opcion)
        {
            case 1:
                // Rectángulo
                Console.WriteLine("Ingrese el ancho del rectángulo:");
                double anchoRect = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Ingrese el alto del rectángulo:");
                double altoRect = Convert.ToDouble(Console.ReadLine());
                shape = new Rectangle(anchoRect, altoRect);
                break;

            case 2:
                Console.WriteLine("Ingrese el ancho del triángulo:");
                double anchoTri = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Ingrese el alto del triángulo:");
                double altoTri = Convert.ToDouble(Console.ReadLine());
                shape = new Triangle(anchoTri, altoTri);
                break;

            case 3:
                
                Console.WriteLine("Ingrese el radio del círculo:");
                double radio = Convert.ToDouble(Console.ReadLine());
                shape = new Circle(radio);
                break;

            default:
                Console.WriteLine("Opción no válida.");
                return;
        }

        Console.WriteLine($"Área de la forma seleccionada: {shape.CalculateSurface()}");
    }
}
