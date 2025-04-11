open System

let rec readList n = 
    if n = 0 then []
    else
    let head = Console.ReadLine()
    let tail = readList (n-1)
    head::tail

let rec writeList = function
    [] ->   let z = Console.ReadKey()
            0
    | (head : string)::tail -> 
        Console.WriteLine(head)
        writeList tail

let shuffle (rnd: Random) (word: string) =
    if word.Length <= 2 then word
    else
        let firstChar = word.[0]
        let lastChar = word.[word.Length - 1]
        let middleChars = word.Substring(1, word.Length - 2).ToCharArray()
        for i in 0 .. middleChars.Length - 2 do
            let j = rnd.Next(i, middleChars.Length)
            let temp = middleChars.[i]
            middleChars.[i] <- middleChars.[j]
            middleChars.[j] <- temp
        firstChar.ToString() + String(middleChars) + lastChar.ToString()

let processString (str: string) =
    let rnd = Random()
    let words = str.Split([|' '|], StringSplitOptions.RemoveEmptyEntries)
    words |> Array.map (shuffle rnd) |> String.concat " "

[<EntryPoint>]
let main argv =

    Console.WriteLine("Введите количество строк:")
    let n = Convert.ToInt32(Console.ReadLine())

    Console.WriteLine("Введите строки:")
    let inputList = readList n

    let processedList = inputList |> List.map processString
    writeList processedList

    0