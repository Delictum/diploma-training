type
  mas = array [1..7] of real;

var
  a: mas;
  s, i, z, j: integer;

function ff(mass: mas; zf, sf: real; k: integer): integer;
begin
  for k := 1 to 7 do
    if mass[k] < 0 then zf := 1 + zf
    else sf := sf + mass[k];
  writeln('Количество отрицательных: ', zf, ' Сумма положительных элементов: ', sf:10:2); 
end;

begin
  for j := 1 to 7 do 
  begin
    a[j] := random(100) / (1 + random(10)) - random(7);
    writeln(a[j]:10:2);
  end;                                                     
  ff(a, z, s, i);
end.