module HigherOrderFunctions //Location 836

let passFive f = (f 5)
let passThree f = (f 3)
let passTwo f = (f 2)

let square x = x * x

let cube x = (square x) * x

(* let cube x = x * x * x *)


(* Mapping -- Decorator pattern ?*)
let map x f = f x

let SquareAndConvertToString x =
    let temp = x * x
    temp.ToString()

let result = SquareAndConvertToString 5

let res2 = map 5 SquareAndConvertToString
let res3 = map 7 SquareAndConvertToString

(* Don't get why this is important?????)

( * Steve Location 871 *)

let OddEven x =
    if x % 2 =0 then "Even"
    else "Odd"

let single x = x

let cube x = single x * single x * single x
let square x = single x * single x

let result x = map (cube x) OddEven
let result1 = map 3 OddEven


(* Composition << and >> *)
let f x = x*x 
let g x = -x/2.0 + 5.0
let fog = f << g    (* Apply g then f*)
let fog2 = f >> g   (* Apply f then g*)

fog 2.0
fog2 2.0

(* Pipeline |> Location 925 *)
let square x = x * x
let add x y = x + y
let toString x = x.ToString()

let complexFunction1 x = toString (add 5 (square x))

let complexFunction3 x = x |> square |> add 5 |> toString

(* Anonymous *)
let complexFunction =
     2                            (* 2 *)     
     |> ( fun x -> x + 5)         (* 2 + 5 = 7 *)     
     |> ( fun x -> x * x)         (* 7 * 7 = 49 *)     
     |> ( fun x -> x.ToString() ) (* 49.ToString = "49" *)


let complexFunction2 =
     2                            (* 2 *)     
     |> ( fun x -> x + 5)         (* 2 + 5 = 7 *)     
     |> ( fun x -> x - 1)         (* 2 + 5 -1 = 6 *)
     |> ( fun x -> x * x)         (* 6 * 6 = 36 *)     
     |> ( fun x -> x.ToString() ) (* 36.ToString = "36" *)

(* Timer Example *)
open System   
let duration f =      
    let timer = new System.Diagnostics.Stopwatch()     
    timer.Start()     
    let returnValue = f()     
    printfn "Elapsed Time: %i" timer.ElapsedMilliseconds     
    returnValue   
    
let rec fib = function     
    | 0 -> 0     
    | 1 -> 1     
    | n -> fib (n - 1) + fib (n - 2)   
    
let rec stv x resolveDepth = function    
    | 3 -> resolveDepth
    | x when x % 3 = 0 -> stv (x % 3) (resolveDepth + 1)
    | x when x % 3 = 1 -> stv (x - 1) (resolveDepth + 1)
    | x when x % 3 = 2 -> stv (x + 1) (resolveDepth + 1)

    //

let main() =     
    printfn "fib 5: %i" (duration ( fun() -> fib 5 ))     
    printfn "fib 30: %i" (duration ( fun() -> fib 30 ))
    
    printfn "stv 300: %i" (duration ( fun() -> stv 300 0))
main()


