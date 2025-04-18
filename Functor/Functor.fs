open System

type Maybe<'a> = 
    | Some of 'a
    | None

module Maybe =
    let ret x = Some x

    let map f = function
        | Some x -> Some (f x)
        | None -> None

    let apply fMaybe xMaybe =
        match fMaybe, xMaybe with
        | Some f, Some x -> Some (f x)
        | _ -> None

    let bind f = function
        | Some x -> f x
        | None -> None


let functorIdentity x =
    Maybe.map id x = x

let functorComposition f g x =
    Maybe.map (f >> g) x = (Maybe.map f >> Maybe.map g) x


let applicativeIdentity v =
    Maybe.apply (Maybe.ret id) v = v

let applicativeHomomorphism f x =
    Maybe.apply (Maybe.ret f) (Maybe.ret x) = Maybe.ret (f x)

let applicativeInterchange u y =
    Maybe.apply u (Maybe.ret y) = Maybe.apply (Maybe.ret (fun f -> f y)) u


let monadLeftIdentity x f =
    Maybe.bind f (Maybe.ret x) = f x

let monadRightIdentity m =
    Maybe.bind Maybe.ret m = m

let monadAssociativity m f g =
    Maybe.bind g (Maybe.bind f m) = Maybe.bind (fun x -> Maybe.bind g (f x)) m

[<EntryPoint>]
let main argv =
    let Value = Some 5
    let func_f x = x + 1
    let func_g x = x * 2
    
    Console.WriteLine("Законы функтора:")
    Console.WriteLine($"Закон тождества: {functorIdentity Value}")
    Console.WriteLine($"Закон композиции: {functorComposition func_f func_g Value}")
    Console.WriteLine()

    Console.WriteLine("Законы аппликативные функтора:")
    Console.WriteLine($"Закон тождества: {applicativeIdentity Value}")
    Console.WriteLine($"Закон гомоморфизма: {applicativeHomomorphism func_f 5}")
    Console.WriteLine($"Закон обмена: {applicativeInterchange (Some func_f) 5}")
    Console.WriteLine()

    Console.WriteLine("Законы монад:")
    Console.WriteLine($"Левосторонний закон тождества: {monadLeftIdentity 5 (fun x -> Some(x + 1))}")
    Console.WriteLine($"Правосторонний закон тождества: {monadRightIdentity Value}")
    Console.WriteLine($"Закон ассоциативности: {monadAssociativity Value (fun x -> Some(x + 1)) (fun y -> Some(y * 2))}")

    0