program Est;

var
  a: array[1..10] of integer;
  i, j, buf: integer;

begin
  for i := 1 to 10 do
    a[i] := random(20);
  for i := 1 to 10 do
    write(a[i]:3);
  writeln;
  for j := 1 to 10 - 1 do
    for i := 1 to 10 - j do
      if a[i] < a[i + 1] then
      begin
        buf := a[i];
        a[i] := a[i + 1];
        a[i + 1] := buf;
      end;
  for i := 1 to 10 do
    write(a[i]:3);
end.