module File1

[<EntryPoint>]

type Proposition = 
                | True 
                | Not of Proposition 
                | And of Proposition * Proposition 
                | Or of Proposition * Proposition
                | Xor of Proposition * Proposition

let rec eval x = match x with 
               | True -> true    
               | Not (prop) -> not (eval prop)     
               | And (prop1, prop2) -> (eval prop1) && (eval prop2)     
               | Or (prop1, prop2) -> (eval prop1) || (eval prop2)
               | Xor (prop1, prop2) -> ((eval prop1) && (eval (Not prop2))) || ((eval (Not prop1)) && (eval prop2))


let shouldBeFalse = And (Not True, Not True)
let shouldBeTrue = Or(True, Not True)
let complexLogic = And (And(True, Or (Not(True), True)), Or (And (True, Not(True)), Not(True)))

let XorTrue = Xor (True, Not True);
let XorFalse = Xor (True, True);

printfn "shouldBeFalse : %b" (eval shouldBeFalse)
printfn "shouldBeTrue : %b" (eval shouldBeTrue)
printfn "complexLogic : %b" (eval complexLogic)

printfn "shouldBeFalse : %b" (eval XorFalse)
printfn "shouldBeTrue : %b" (eval XorTrue)


let main argv = 
    printfn "%A" argv

    let _ = printf "Hellow World"

    0