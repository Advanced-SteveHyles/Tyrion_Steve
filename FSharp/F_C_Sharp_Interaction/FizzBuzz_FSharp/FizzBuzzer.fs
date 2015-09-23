namespace FizzBuzz_FSharp

type FixBuzzController() = 
    
    let Resolver1 x = 
        if (x % 3) = 0 && (x % 5) = 0 then "FizzBuzz"
        else
            if (x % 3) = 0 then "Fizz"
            else
                if (x % 5) =0 then "Buzz"
                else 
                    let value = x.ToString()
                    if value.Contains "3" then "Fizz"
                    else
                        if value.Contains "5" then "Buzz"
                        else value                            
               
    let Resolver2 x = 
        "Not implemented"
                
    member this.PlayFizBuzz x = 
        Resolver2 x

