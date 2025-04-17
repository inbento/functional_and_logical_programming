open System

type IPrint = interface
    abstract member Print: unit -> unit
    end

[<AbstractClass>]
type GeometricFigure() =
    abstract member CalculateArea: unit -> float
    override this.ToString() = "Геометрическая фигура"

type Rectangle(width: float, height: float) =
    inherit GeometricFigure()
    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())

    member val Width = width with get, set
    member val Height = height with get, set

    override this.CalculateArea() = this.Width * this.Height
    override this.ToString() =
        String.Format("Прямоугольник [ширина={0:F2}, высота={1:F2}, площадь={2:F2}]", 
                     this.Width, this.Height, this.CalculateArea())
    new() = Rectangle(0.0, 0.0)

type Square(side: float) =
    inherit Rectangle(side, side)
    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())

    member this.Side
        with get() = this.Width
        and set(value) = 
            this.Width <- value
            this.Height <- value
    override this.ToString() =
        String.Format("Квадрат [сторона={0:F2}, площадь={1:F2}]", 
                     this.Side, this.CalculateArea())
    new() = Square(0.0)

type Circle(radius: float) =
    inherit GeometricFigure()
    interface IPrint with
        member this.Print() = Console.WriteLine(this.ToString())
        
    member val Radius = radius with get, set
    
    override this.CalculateArea() = Math.PI * this.Radius * this.Radius
    override this.ToString() =
        String.Format("Круг [радиус={0:F2}, площадь={1:F2}]", 
                     this.Radius, this.CalculateArea())
    new() = Circle(0.0)


[<EntryPoint>]
let main argv =

    let rect = Rectangle(5.0, 3.0)
    (rect :> IPrint).Print()

    let square = Square(4.0)
    (square :> IPrint).Print()

    let circle = Circle(3.0)
    (circle :> IPrint).Print()
    
    0