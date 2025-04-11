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

let findBetweenMaxes list =

    let rec findMaxes firstMax firstPos secondMax secondPos pos = function
        | [] -> (firstMax, firstPos, secondMax, secondPos)
        | head::tail when head > firstMax -> 
            findMaxes head pos firstMax firstPos (pos + 1) tail
        | head::tail when head > secondMax -> 
            findMaxes firstMax firstPos head pos (pos + 1) tail
        | _::tail -> 
            findMaxes firstMax firstPos secondMax secondPos (pos + 1) tail

    // Извлекаем элементы между позициями
    let rec Between start finish current acc = function
        | [] -> List.rev acc
        | head::tail when current > start && current < finish -> 
            Between start finish (current + 1) (head::acc) tail
        | _::tail -> 
            Between start finish (current + 1) acc tail

    match list with
    | [] | [_] -> []
    | _ ->
        let (max1, pos1, max2, pos2) = 
            findMaxes Int32.MinValue -1 Int32.MinValue -1 0 list
        
        if pos1 = -1 || pos2 = -1 then []
        else
            let startPos = min pos1 pos2
            let endPos = max pos1 pos2
            Between startPos endPos 0 [] list

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

    let elemBetween = findBetweenMaxes list

    Console.WriteLine("Элементы, расположенные между первым и вторым максимальным:")
    writeList elemBetween



    0