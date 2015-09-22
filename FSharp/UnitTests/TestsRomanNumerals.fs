[<AutoOpen>] 
module TestRomanNumerals

    open Xunit
    open RomanNumerals

    [<Fact>]
    let Roman1IsI () =
        let c = new Roman()
            
        Assert.Equal ("I", c.toRoman(1))

    [<Fact>]
    let Roman3IsIII () =
        let c = new Roman()
            
        Assert.Equal ("III", c.toRoman(3))
    
    [<Fact>]
    let Roman4IsIV () =
        let c = new Roman()
            
        Assert.Equal ("IV", c.toRoman(4))

    [<Fact>]
    let Roman5IsV () =
        let c = new Roman()
            
        Assert.Equal ("V", c.toRoman(5))    

    [<Fact>]
    let Roman6IsVI () =
        let c = new Roman()
            
        Assert.Equal ("VI", c.toRoman(6))    

    [<Fact>]
    let Roman8IsVIII () =
        let c = new Roman()
            
        Assert.Equal ("VIII", c.toRoman(8))    

    [<Fact>]
    let Roman9IsIX () =
        let c = new Roman()
            
        Assert.Equal ("IX", c.toRoman(9))  

    [<Fact>]
    let Roman10IsX () =
        let c = new Roman()
            
        Assert.Equal ("X", c.toRoman(10))  

    [<Fact>]
    let Roman11IsXI () =
        let c = new Roman()
            
        Assert.Equal ("XI", c.toRoman(11))

    [<Fact>]
    let Roman15IsVX () =
        let c = new Roman()
            
        Assert.Equal ("XV", c.toRoman(15))

    [<Fact>]
    let Roman20IsXX () =
        let c = new Roman()
            
        Assert.Equal ("XX", c.toRoman(20))  

    [<Fact>]
    let Roman49IsXLIX () =
        let c = new Roman()
            
        Assert.Equal ("XLIX", c.toRoman(49))  

    [<Fact>]
    let Roman61IsLXI () =
        let c = new Roman()
            
        Assert.Equal ("LXI", c.toRoman(61))  

    [<Fact>]
    let Roman90IsXC () =
        let c = new Roman()
            
        Assert.Equal ("XC", c.toRoman(90))  

    [<Fact>]
    let Roman99IsXCIX () =
        let c = new Roman()
            
        Assert.Equal ("XCIX", c.toRoman(99))  

    [<Fact>]
    let Roman100IsC () =
        let c = new Roman()
            
        Assert.Equal ("C", c.toRoman(100))  

    [<Fact>]
    let Roman500IsD () =
        let c = new Roman()
            
        Assert.Equal ("D", c.toRoman(500))  

    [<Fact>]
    let Roman1000IsM () =
        let c = new Roman()
            
        Assert.Equal ("M", c.toRoman(1000))  

    [<Fact>]
    let Roman1900IsMCM () =
        let c = new Roman()
            
        Assert.Equal ("MCM", c.toRoman(1900))  

    [<Fact>]
    let Roman1999IsIM () =
        let c = new Roman()
            
        Assert.Equal ("MCMXCIX", c.toRoman(1999))  
