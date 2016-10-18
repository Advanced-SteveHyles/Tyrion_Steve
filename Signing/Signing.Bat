ildasm.exe /all /typelist /out=CallMLProxy.il Unsigned\CallMLProxy.dll

ilasm.exe /dll /optimize /key=IRISLaw.snk CallMLProxy.il

pause