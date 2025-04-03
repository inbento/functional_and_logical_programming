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



[<EntryPoint>]
let main argv = 

    Console.WriteLine((flag false) 12)

    0
