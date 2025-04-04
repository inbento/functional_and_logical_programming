open System


let summ_digits num = 
    let rec summ_digits_rec num summ =
        if num = 0 then summ
        else 
            let num1 = num / 10
            let cifra = num % 10
            let new_sum = summ + cifra
            summ_digits_rec num1 new_sum
    summ_digits_rec num 0


let factorial n = 
    let rec factorial_rec n fact =
        if n = 0 then fact
        else
            let new_fact = fact * n
            let n1 = n - 1
            factorial_rec n1 new_fact
    factorial_rec n 1

let flag selector = 
    match selector with
    | true -> summ_digits
    | false -> factorial

let rec digits num (func: int->int->int) acc = 
      match num with
         | 0 -> acc
         | n -> digits (n / 10) func (func acc (n % 10))


let rec digits_with_condition num (func: int->int->int) acc (condition: int->bool) = 
      match num with
         | 0 -> acc
         | n -> 
             let digit = n % 10
             let next_number = n / 10
             let flag = condition digit
             match flag with
                 | false -> digits_with_condition next_number func acc condition
                 | true -> digits_with_condition next_number func (func acc digit) condition

let language otvet =
    match otvet with
    | "F#" | "Prolog" -> "Ну ты и подлиза"
    | "Python" -> "Чел хорош"
    | "Java" -> "Ява"
    | "C++" | "C#" -> "Классика"
    | _ -> "Мой создатель не задал действий для этого языка, прости"
    

let superpos_language () =
    Console.WriteLine("Какой твой любимый язык программирования?")
    (Console.ReadLine >> language >> Console.WriteLine)()

let curry_language () =
    Console.WriteLine("Какой твой любимый язык программирования?")
    let cur_fun inputReader processor outputWriter = 
         let userInput = inputReader()
         let processedResult = processor userInput
         outputWriter processedResult
    cur_fun Console.ReadLine language Console.WriteLine


let rec gcd a b =
    match b with
    |0 -> a
    | _ -> gcd b (a % b)


let process_coprimes n (func: int -> int -> int) value  = 
    let rec loop n f acc current =
        if current <= 0 then acc
        else
            let new_acc =
                if gcd n current = 1 then
                    f acc current
                else acc
            loop n f new_acc (current - 1)
    loop n func value n

let process_coprimes_with_condition n (func: int -> int -> int) value (condition: int->bool) =
    let rec loop n f acc current =
        if current <= 0 then acc
        else
            let flag = condition current
            let new_acc =
                if gcd n current = 1 && flag then
                    f acc current
                else acc
            loop n f new_acc (current - 1)
    loop n func value n

let Euler_fun n =
    process_coprimes n (fun x y -> x + 1) 0

[<EntryPoint>]
let main argv = 

    (*
    Console.WriteLine((flag false) 12)

    Console.WriteLine($"Сумма цифр числа: {digits 123 (fun x y -> (x + y)) 0}")
    Console.WriteLine($"Произведение цифр числа: {digits 456 (fun x y -> (x * y)) 1}")
    Console.WriteLine($"Минимальная цифра числа: {digits 789268 (fun x y -> if x < y then x else y) 10}")
    Console.WriteLine($"Максимальная цифра числа: {digits 7891366 (fun x y -> if x < y then y else x) -10}")

    Console.WriteLine("Функция с условием.")
    Console.WriteLine($"Сумма цифр числа, которые больше 5: {digits_with_condition 4567 (fun x y -> (x + y)) 0 (fun z -> z > 5)}")
    Console.WriteLine($"Произведение цифр числа, которые меньше 3: {digits_with_condition 8921 (fun x y -> (x * y)) 1 (fun z -> z < 3)}")
    Console.WriteLine($"Максимальная нечетная цифра числа: {digits_with_condition 2345 (fun x y -> if x > y then x else y) 0 (fun z -> z % 2 <> 0)}")
    Console.WriteLine("-----------------------------")

    superpos_language ()
    Console.WriteLine()
    curry_language ()
    *)

    Console.WriteLine($"Сумма взаимно простых с 10 :  {process_coprimes 10 (fun x y -> (x + y)) 0}")
    Console.WriteLine($"Произведение взаимно простых с 10 :  {process_coprimes 10 (fun x y -> (x * y)) 1}")
    Console.WriteLine($"Функция Эйлера для числа 10 :  {Euler_fun 10}")

    Console.WriteLine($"Сумма взаимно простых с 10 и делящихся на 3  :  {process_coprimes_with_condition 10 (fun x y -> (x + y)) 0 (fun z -> z % 3 = 0)}")
    0
