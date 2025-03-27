open System

type SolveResult =
    None
    | Linear of float
    | Quadratic of float * float

let solve a b c = 
        let D = b * b - 4.0 * a * c
        if a = 0.0 then
            if b = 0.0 then None
            else Linear(-c / b)
        else
            if D < 0.0 then None
            else Quadratic(((-b + sqrt(D)) / (2.0 * a), (-b - sqrt(D)) / (2.0 * a)))

let circle_area rad=
    Math.PI * rad * rad
  

let cylinder_area rad h=
    (circle_area rad) * h



[<EntryPoint>]
let main argv = 

    Console.WriteLine("Hello World!") //напишет в консоль Hello World
    let a = 2.0
    let b = -6.0
    let c = 1.0
    Console.WriteLine(solve a b c)

    Console.WriteLine("Введите радиус: ")
    let rad = Console.ReadLine() |> float
    Console.WriteLine("Введите высоту цилиндра: ")
    let h = Console.ReadLine() |> float
    Console.WriteLine($"Площадь цилиндра: {cylinder_area rad h}")

    0