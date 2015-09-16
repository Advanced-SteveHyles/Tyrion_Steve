module Immuntable

(* Location 304*)

let a = 1

let a = a + 1  //This is an error - a is defined within this scope as 1


let a = 1 in (printfn "%i" a; (let a = a + 1 in printfn "%i" a); printfn "%i" a)


