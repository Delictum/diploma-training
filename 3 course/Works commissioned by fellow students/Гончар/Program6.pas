//С помощью процедуры высчитайте факториал заданного числа и примените его в выражении 5!/10!+2!+(7!+11!)/8! 
function fac(n: integer): integer;
var
  p, i: integer;
begin
  p := 1;
  for i := 2 to n do
    p := p * i;
  fac := p;
end;

begin
  Writeln(fac(5) / fac(10) + fac(2) + (fac(7) + fac(11)) / fac(8));
end.