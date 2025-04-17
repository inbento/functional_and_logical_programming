open System

[<AbstractClass>]
type GeometricFigure() =
    abstract member CalculateArea: unit -> float


type Rectangle(width: float, height: float) =
    inherit GeometricFigure()

    member val Width = width with get, set
    member val Height = height with get, set

    override this.CalculateArea() = this.Width * this.Height

    new() = Rectangle(0.0, 0.0)

type Square(side: float) =
    inherit Rectangle(side, side)

    member this.Side
        with get() = this.Width
        and set(value) = 
            this.Width <- value
            this.Height <- value

    new() = Square(0.0)

type Circle(radius: float) =
    inherit GeometricFigure()
    
    member val Radius = radius with get, set
    
    override this.CalculateArea() = Math.PI * this.Radius * this.Radius
    
    new() = Circle(0.0)

let printFigureInfo (figure: GeometricFigure) =
    match figure with
    | :? Square as sq -> 
        Console.WriteLine("Квадрат: сторона = {0:F2}, площадь = {1:F2}", 
                         sq.Side, sq.CalculateArea())
    | :? Rectangle as rect -> 
        Console.WriteLine("Прямоугольник: ширина = {0:F2}, высота = {1:F2}, площадь = {2:F2}", 
                          rect.Width, rect.Height, rect.CalculateArea())
    | :? Circle as circle -> 
        Console.WriteLine("Круг: радиус = {0:F2}, площадь = {1:F2}", 
                         circle.Radius, circle.CalculateArea())
    | _ -> Console.WriteLine("Неизвестная фигура")

[<EntryPoint>]
let main argv =

    let rect = Rectangle(5.0, 3.0)
    printFigureInfo rect

    let square = Square(4.0)
    printFigureInfo square
    
    let circle = Circle(3.0)
    printFigureInfo circle

    
    0