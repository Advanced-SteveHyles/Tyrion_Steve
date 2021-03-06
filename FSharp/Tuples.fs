﻿module Tuples
    // 1056

// Comma separated list becomes a tuple
let ThreeWayTupple (y1, y2, y3) = (y1 + y2 + y3) /3

// Returning a tuple
let ReturningATupple (y1) = (y1, y1 *2, y1 *3)

// Swapping Out
let swapper (x1, x2, x3) = (x2, x3, x1)

//Pattern Matching Tuples
let resolve (name, age) =
    match (name, age) with
    | ("Steve", 22) -> false
    | ("Barry", 32) -> true
    | (_, 0) -> false
    | (_, _) when age < 0 -> false
    | _ -> false

let langresolve = function 
    | ("Tim", "English") -> "WTF Tim"    
    | ( _ , "English") -> "Hello"
    | ("Barry", _ ) -> "OK"
    | ("Joe", "French") -> "Bonjour Joe"
    | ("Andy", _) -> "Hi Andy"
    | ( _ , "Klingon") -> "K'Plath " + string (fst)
    | ( _, _ ) -> "...."

//fst and snd
fst (1, 10);; 
snd (1, 10);;

//Multi Value Assignment
let x, y, z = (1 , 2, 3)
x;;
y;;
z;;

// Framework signatures - returns tuple
System.Math.DivRem(10, 7);;

//Defining Records -> Tuple with named fields (simple class)
// + means Must occur one or more times
type recordName = 
    {  name : string; 
       url : string; 
       pages : int}

let x = {name = "Steve"; pages =0 ; url = "www"}

printfn "%i" (x.pages);;

// Records are immutable and must be cloned
type recordName = 
    {  name : string; 
       url : string; 
       pages : int}

let changerecord item newRecord =
    {item with pages = newRecord}

let x = {name = "Steve"; pages =0 ; url = "www"}
let y = changerecord x 10

printfn "%i" (x.pages)
printfn "%i" (y.pages)