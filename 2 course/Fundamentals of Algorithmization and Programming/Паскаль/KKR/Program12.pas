program Est;

var
  a: array[1..15] of integer;
  i: integer;

begin
  for i := 1 to 15 do
  begin
    a[i] := random(11) - 5;
    write(a[i]:3);
  end;
  writeln;
  for i := 1 to 15 do
  begin
    a[i] := a[i] * 2;
    write(a[i]:3);
  end;
end.