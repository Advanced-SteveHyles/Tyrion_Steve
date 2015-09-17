namespace MathsFunctions

type Class1() = 
   let rec factorial = function
            | 0 -> 1
            | 1 -> 1
            | n -> n * factorial (n - 1)
