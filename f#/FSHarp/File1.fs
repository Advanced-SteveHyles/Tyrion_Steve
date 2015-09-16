module File1

[<EntryPoint>]

type Proposition = 
                | True 
                | False of Proposition
                | Not of Proposition 
                | And of Proposition * Proposition 
                | Or of Proposition * Proposition
                | Xor of Proposition * Proposition
                | And3 of Proposition * Proposition * Proposition 

let rec eval x = match x with 
               | True -> true    
               | False ->  (eval not True)               
               | Not (prop) -> not (eval prop)     
               | And (prop1, prop2) -> (eval prop1) && (eval prop2)     
               | Or (prop1, prop2) -> (eval prop1) || (eval prop2)
               | Xor (prop1, prop2) -> ((eval prop1) && (eval (Not prop2))) || ((eval (Not prop1)) && (eval prop2))
               | And3 (prop1, prop2, prop3) -> (eval prop1) && (eval prop2) && (eval prop3)     


let shouldBeFalse = And (Not True, Not True)
let shouldBeTrue = Or(True, Not True)
let complexLogic = And (And(True, Or (Not(True), True)), Or (And (True, Not(True)), Not(True)))

let XorTrue = Xor (True, Not True);
let XorFalse = Xor (True, True);

let And3True = And3 (True, True, True);
let And3False = And3 (True, False, True);

printfn "shouldBeFalse : %b" (eval shouldBeFalse)
printfn "shouldBeTrue : %b" (eval shouldBeTrue)
printfn "complexLogic : %b" (eval complexLogic)

printfn "XOR shouldBeFalse : %b" (eval XorFalse)
printfn "XOR shouldBeTrue : %b" (eval XorTrue)

printfn "AND3 shouldBeFalse : %b" (eval And3False)
printfn "AND3 shouldBeTrue : %b" (eval And3True)


let main argv = 
    printfn "%A" argv

    let _ = printf "Hellow World"

    0