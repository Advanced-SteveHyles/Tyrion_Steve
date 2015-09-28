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



