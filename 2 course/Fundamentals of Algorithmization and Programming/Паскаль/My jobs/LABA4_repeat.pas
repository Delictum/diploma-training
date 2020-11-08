program Est;

var
  k, x, f, g, h, s: integer;

begin
  writeln(' целое число X=');
  readln(x);
  k := 9;
  repeat
    k += 1;
    f := k mod 10;
    g := k div 10;
    s := f + g;
    if s = x then writeln('k= ', k);
  until k > 99;
end.