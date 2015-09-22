namespace RomanNumerals

type Roman() =

    let rec ResolveNumeral = function
        | n when n >= 1000 ->  "M"  + ResolveNumeral (n - 1000) 
        | n when n >= 900 ->  "CM"  + ResolveNumeral (n - 900) 
        | n when n >= 500 ->  "D" + ResolveNumeral (n - 500)
        | n when n >= 400 ->  "CD" + ResolveNumeral (n - 400) 
        | n when n >= 100 ->  "C" + ResolveNumeral (n - 100)
        | n when n >= 90 ->  "XC" + ResolveNumeral (n - 90)
        | n when n >= 50 ->  "L" + ResolveNumeral (n - 50)
        | n when n >= 40 ->  "XL" + ResolveNumeral (n - 40) 
        | n when n >= 10 ->  "X" + ResolveNumeral (n - 10)
        | 9 -> "IX"                 
        | n when n >= 5 ->  "V" + ResolveNumeral (n - 5) 
        | 4 -> "IV"
        | n when n >= 1 ->  "I" + ResolveNumeral (n - 1)
        | 0 -> ""
        | n when n < 0 -> "?"        
    
    member this.toRoman x =
           ResolveNumeral x
           