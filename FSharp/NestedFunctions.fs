module NestedFunctions

let sumOfDivisors n = 
    let rec functionCall current max acc =
        if current > max then
            acc
        else
            if n % current = 0 then 
                functionCall (current + 1) max (acc + current)
            else
                functionCall (current + 1) max acc

    let start = 2
    let max = n / 2 (* largest factor, apart from n, cannot be > n / 2 *)
                
    let minSum = 1 + n (* 1 and n are already factors of n *)
    functionCall start max minSum 

printfn "%d" (sumOfDivisors 10) (* prints 18, because the sum of 10's divisors is 1 + 2 + 5 + 10 = 18 *)



    