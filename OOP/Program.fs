open System

type GeometricFigure =
    | Rectangle of width: float * height: float
    | Square of side: float
    | Circle of radius: float

let calculateArea figure =
    match figure with
    | Rectangle (w, h) -> w * h
    | Square s -> s * s
    | Circle r -> Math.PI * r * r

let figureToString figure =
    match figure with
    | Rectangle (w, h) -> 
        String.Format("Прямоугольник [ширина={0:F2}, высота={1:F2}, площадь={2:F2}]", w, h, calculateArea figure)
    | Square s -> 
        String.Format("Квадрат [сторона={0:F2}, площадь={1:F2}]", s, calculateArea figure)
    | Circle r -> 
        String.Format("Круг [радиус={0:F2}, площадь={1:F2}]", r, calculateArea figure)

let printFigure figure =
    Console.WriteLine(figureToString figure)

[<EntryPoint>]
let main argv =
    let rect = Rectangle(9.0, 2.0)
    let square = Square(12.0)
    let circle = Circle(8.0)

    Console.WriteLine("Площадь прямоугольника: {0:F2}", calculateArea rect)
    Console.WriteLine("Площадь квадрата: {0:F2}", calculateArea square)
    Console.WriteLine("Площадь круга: {0:F2}", calculateArea circle)

    printFigure rect
    printFigure square
    printFigure circle

    let figures = [rect; square; circle]
    Console.WriteLine("\nПечать всех фигур:")
    figures |> List.iter printFigure

    0