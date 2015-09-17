open System

let rec fib = function
            | 0 -> 0
            | 1 -> 1
            | n -> fib (n - 1) + fib (n - 2)

let rec factorial = function
            | 0 -> 1
            | 1 -> 1
            | n -> n * factorial (n - 1)


//let main() = Console.WriteLine ("fib 5: {0}", (fib 10))
let main() = Console.WriteLine ("reci 5: {0}", (factorial 5))

main()
