program Est;

var
  i, s, k: integer;

begin
  writeln('Введите числа: ');
  k := 0;
  repeat
    readln(i);
    s := s + i;
    k := k + 1;
  until s > 300;
  write('Кол-во чисел: ', k);
end.