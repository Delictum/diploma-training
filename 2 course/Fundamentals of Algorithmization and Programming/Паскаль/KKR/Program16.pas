program Est;

var
  a: string;
  i: integer;

begin
  readln(a);
  for i := length(a) downto 1 do
    if a[i] = '*' then delete(a, i, 1)
    else insert(a[i], a, i);
  writeln(a);
end.