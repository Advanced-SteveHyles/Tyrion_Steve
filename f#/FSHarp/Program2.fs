
(*

*)

//

open System

let rec fib = function
            | 0 -> 0
            | 1 -> 1
            | n -> fib (n - 1) + fib (n - 2)

let main() = Console.WriteLine ("fib 5: {0}", (fib 5))

main()

