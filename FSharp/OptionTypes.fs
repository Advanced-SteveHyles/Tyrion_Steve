(* Operators *)
NONE -> Nothing matched
SOME -> something matched

// Work like nullable types in C# but are NOT nullable types.

let safediv x y =
     match y with     
        | 0 -> None     
        | _ -> Some(x/y)

        

let isFortyTwoA = function     
    | Some(42) -> true     
    | Some(_) -> false
    | None -> false
    

isFortyTwoA (Some(41));;


Other Functions in the Option Module 
val get : 'a option -> 'a Returns the value of a Some option. 
val isNone : 'a option -> bool Returns true for a None option, false otherwise. 
val isSome : 'a option -> bool Returns true for a Some option, false otherwise. 
val map : ('a -> 'b) -> 'a option -> 'b option Given None, returns None. Given Some(x), returns Some(f x), where f is the given mapping function. 
val iter : ('a -> unit) -> 'a option -> unit Applies the given function to the value of a Some option, does nothing otherwise.


