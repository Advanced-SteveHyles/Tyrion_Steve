module Recursion

(* Tail Recursion *)
// The last statement in a recursion is the recursion.
// This prevents memory usage whilst remembering each class

let rec BreakingFunction x = 
    if x <= 1000000 then
        BreakingFunction (x + 1)
        printf "Hello %i" x

let rec PassingFunction x = 
    if x <= 1000000 then
        printf "Hello %i" x
        PassingFunction (x + 1)

BreakingFunction 10
PassingFunction 10  (**)



// Not tail recursion
let rec slowMultiply a b = 
    if b > 1 then      
        a + slowMultiply a (b - 1)
     else         
        a
        
//Tail Recursion achived by passing the accumlation as a argument.
let slowMultiply a b =  
    let rec loop acc counter =       
        if counter > 1 then 
            loop (acc + a) (counter - 1) (* tail recursive *)


