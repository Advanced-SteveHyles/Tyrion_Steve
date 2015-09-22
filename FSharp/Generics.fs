module Generics

(*Location 599*)

let throwAwayFirstInput x y = y 

let p x y z = z

p 1 2 "3";; (*Returns a string *)

p 1 2 3;; (*Returns a int *)

p 1 2 3.5;; (*Returns a float *)


// When resolving, all items are bound at that point
