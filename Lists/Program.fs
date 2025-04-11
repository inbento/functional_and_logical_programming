open System

let rec readList n = 
    if n = 0 then []
    else
    let head = Convert.ToInt32(Console.ReadLine())
    let tail = readList (n-1)
    head::tail

let rec writeList = function
    [] ->   let z = Console.ReadKey()
            0
    | (head : int)::tail -> 
        Console.WriteLine(head)
        writeList tail

let rotateLeftChurch list =
    let rec length acc = function
        | [] -> acc
        | _::tail -> length (acc + 1) tail

    let rec reverse acc = function
        | [] -> acc
        | head::tail -> reverse (head::acc) tail

    let rec splitAt front count back =
        match back, count with
        | _, 0 -> (reverse [] front, back)
        | head::tail, _ -> splitAt (head::front) (count - 1) tail
        | [], _ -> (reverse [] front, [])

    let rec concat first second =
        match first with
        | [] -> second
        | head::tail -> head :: (concat tail second)

    let len = length 0 list
    let shift = 3 % len

    let (front, back) = splitAt [] shift list
    concat back front

let rotateLeft n list =
    let length = List.length list
    let shift = n % length
    
    let rec splitAt acc count origlist =
        match origlist, count with
        | _, 0 -> (List.rev acc, origlist)
        | head::tail, _ -> splitAt (head::acc) (count-1) tail
        | [], _ -> (List.rev acc, [])
    
    let (front, back) = splitAt [] shift list
    back @ front

[<EntryPoint>]
let main argv =

    Console.WriteLine("Введите количество элементов в списке:")
    let n = Convert.ToInt32(Console.ReadLine())
    Console.WriteLine("Введите элементы списка:")
    let list = readList n
    Console.WriteLine("Исходный список:")
    writeList list

    let rotatedChurch = rotateLeftChurch list
    
    Console.WriteLine("Список После сдвига на 3 влево(Чёрч):")
    writeList rotatedChurch 

    let rotated = rotateLeft 3 list
    
    Console.WriteLine("Список после сдвига на 3 позиции влево:")
    writeList rotated

    0