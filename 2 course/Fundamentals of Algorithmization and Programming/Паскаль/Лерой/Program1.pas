const
  n = 3;

var
  i, j: integer;
  mas, a: array[1..n, 1..n] of integer;

begin
  write('������� �������� �������: ');
  for i := 1 to n do
    for j := 1 to n do
      read(mas[i, j]);
  a := mas;
  for i := 1 to n do
    for j := 1 to n do
      if mas[i, j] > 0 then
        mas[i, j] := 0
      else if mas[i, j] < 0 then
        mas[i, j] := 1;
  writeln('����� ������:');
  for i := 1 to n do
  begin
    for j := 1 to n do
      write(mas[i, j], ' ');
    writeln;
  end;
  writeln('�������� ������:');
  for i := 1 to n do
  begin
    for j := 1 to n do
      write(a[i, j], ' ');
    writeln;
  end;
end.