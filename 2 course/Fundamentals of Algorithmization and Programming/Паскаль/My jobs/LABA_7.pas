program Est;

var
  mas: array[1..1000] of integer;
  mass: array[1..1000] of real;
  s, z, n, i, k, j, y, x, g: integer;

begin
  s := 0;
  z := 0;
  write('Введите N: ');read(n);
  for j := 1 to n do 
  begin
    mass[j] := random(100) / (1 + random(10)) - random(7);
    writeln(mass[j]:10:2);
  end;
  j := 0;
  for i := 1 to n do
  begin
    inc(j);
    mas[i] := round(mass[j]);
  end;
  for i := 1 to n do
    if mas[i] mod 2 = 0 then s := s + mas[i];
  for i := 1 to n do
    if mas[i] < 0 then z := 1 + z;
  write('Сумма четных=', s, ', количество отрицательных=', z);
end.