open System
open System.Diagnostics

let countSingleSolutionN maxN =
    let stopwatch = Stopwatch.StartNew()
    let lastProgressTime = ref (DateTime.Now)
    
    (*let checkProgress n =
        let currentTime = DateTime.Now
        match (currentTime - !lastProgressTime).TotalSeconds >= 5.0 with
        | true ->
            lastProgressTime := currentTime
            let progress = float n / float maxN * 100.0
            let elapsedMinutes = stopwatch.Elapsed.TotalMinutes
            printfn "Progress: %.2f%% (n = %d) - Elapsed time: %.2f minutes" progress n elapsedMinutes
        | false -> ()*)
    
    let rec findSolutionsForD x n d acc =
        match d with
        | d when d > (x/2) -> acc
        | _ ->
            let y = x - d
            let z = x - 2*d
            match z > 0 && x*x - y*y - z*z = n with
            | true -> 
                match acc with
                | 1 -> 2
                | _ -> findSolutionsForD x n (d + 1) 1
            | false -> findSolutionsForD x n (d + 1) acc
            
    let rec findSolutionsForX n x acc =
        let maxX = int(sqrt(float(n + 2))) + 1000
        match x with
        | x when x > maxX -> acc
        | _ ->
            match acc with
            | 2 -> 2
            | _ ->
                let newAcc = findSolutionsForD x n 1 acc
                findSolutionsForX n (x + 1) newAcc
    
    let rec countSolutions n acc =
        //checkProgress n
        
        match n with
        | n when n > maxN ->
            //stopwatch.Stop()
            //printfn "\nTotal execution time: %.2f minutes" stopwatch.Elapsed.TotalMinutes
            acc
        | _ ->
            let solutionCount = findSolutionsForX n 3 0
            match solutionCount with
            | 1 -> countSolutions (n + 1) (acc + 1)
            | _ -> countSolutions (n + 1) acc
    countSolutions 1 0

[<EntryPoint>]
let main argv =
    let result = countSingleSolutionN 50000000
    Console.WriteLine($"Result: {result}")
    0