open System

type AgentMessage =
    | Hello of string
    | Plus of int * int
    | Date
    | Quit

let agent = 
    MailboxProcessor.Start(fun inbox ->
        let rec messageLoop () = async {
            let! message = inbox.Receive()
            
            match message with
            | Hello name ->
                Console.WriteLine($"Привет, {name}")
                return! messageLoop ()
            
            | Plus (a, b) ->
                Console.WriteLine($"Сумма чисел {a} и {b} = {a + b}")
                return! messageLoop ()
            
            | Date ->
                Console.WriteLine($"Текущая дата и время: {DateTime.Now.ToString()}")
                return! messageLoop ()
            
            | Quit ->
                return ()
        }
        messageLoop ()
    )

let testAgent () =
    Console.WriteLine("Протестируй моего агента, вот команды, которые он может обрабатывать: ")
    Console.WriteLine("hello <имя> - приветствие")
    Console.WriteLine("plus <число1> <число2> - сложение двух чисел")
    Console.WriteLine("date - вывод текущего времени и даты")
    Console.WriteLine("q или quit - для выхода")
    
    let rec testLoop () =
        let input = Console.ReadLine().Trim()
            
        if String.IsNullOrEmpty(input) then
            testLoop ()
        else
            let parts = input.Split([|' '|], StringSplitOptions.RemoveEmptyEntries)
            match parts.[0].ToLower() with
            | "hello" when parts.Length > 1 ->
                agent.Post(Hello parts.[1])
                testLoop ()
                
            | "plus" when parts.Length > 2 ->
                match Int32.TryParse(parts.[1]), Int32.TryParse(parts.[2]) with
                | (true, a), (true, b) -> agent.Post(Plus(a, b))
                | _ -> Console.WriteLine("Неправильные числа")
                testLoop ()
                
            | "date" ->
                agent.Post(Date)
                testLoop ()
                
            | "q" | "quit" ->
                agent.Post(Quit)
                Console.WriteLine("До свидания!")
                
            | _ ->
                Console.WriteLine("Неправильная команда. Список команд: hello, plus, date, q/quit")
                testLoop ()
    
    testLoop ()

[<EntryPoint>]
let main argv =

    testAgent ()

    0