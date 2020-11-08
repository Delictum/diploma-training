uses Module;
var
  a: mas;
  j, n, m, i: byte;

begin
  vvod(a);
  for i := 1 to 4 do
  begin
    for j := 1 to 4 do
      write(a[i, j]:3);
    writeln;
  end;
end.