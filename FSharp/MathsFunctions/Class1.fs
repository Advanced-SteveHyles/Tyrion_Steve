namespace MathsFunctions

type MathClass() = 
    
    let rec factorial = function            
            | 0  -> 1
            | 1  -> 1
            | n when n < 0 -> failwith "value cannot be < 0"
            | n  -> n * factorial (n - 1)

    let rec factorialMatch n = 
        match n with
            | 0  -> 1
            | 1  -> 1
            | _  -> n * factorial (n - 1)


    let rec factorialf = function            
            | 0.00  -> 1.00
            | 1.00  -> 1.00
            | n when n < 0.00 -> failwith "value cannot be < 0"
            | n  -> n * factorialf (n - 1.00)

    let AddAndMakeString x y =
        (x + y).ToString()

    member this.GetFactorial x =
        factorial x

    member this.GetFactorialF x =
        factorialf x

    member this.GetFactorialMatch x =
        factorialMatch x

    member this.AddAndReturnAsString x y =
        AddAndMakeString x y
