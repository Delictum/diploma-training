program Est;

type
  mss = ^mas;
  mas = array of integer;

var
  b: array[1..10] of integer;
  a: mss;
  i, j, n: longint;

begin
  for j:=1 to 10 do
  begin
  new(a);  
  n:=random(9)+2;
  setlength(a^, n);
    for i := 1 to a^.length - 1 do
    begin
    b[j] := a^[1];
    a^[i] := random(100);
    write(a^[i], ' ');
    end;
  for i := 1 to a^.length - 1 do
    if a^[i] > b[j] then b[j] := a^[i];
  writeln;
  end;
  writeln('Максимальные: ');
  for j:=1 to 10 do
  write( b[j],' ')
end.