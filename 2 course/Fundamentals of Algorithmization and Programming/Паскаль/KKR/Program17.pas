program Est;

var
  a: string;
  i: integer;
  s:char;

begin
  readln(a);
  for i := length(a) downto 1 do
    s:=a[length(a)];
    a[length(a)]:=a[1];
    a[1]:=s;
  writeln(a);
end.