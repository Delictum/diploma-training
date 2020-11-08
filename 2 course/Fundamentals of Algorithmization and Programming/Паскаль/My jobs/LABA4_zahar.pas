{Вывести числа из промежутка [A;B] кратные количеству этих чисел.( через repeat )}
program Est;

var
  a, b, k: integer;

begin
  write('Введите A: ');
  readln(a);
  write('Введите B: ');
  readln(b);
  k := b - a + 1;
  writeln('Числа из промежутка от ', a, ' до ', b, ' кратные ', k, ':');
  repeat
    inc(a);
    if a mod k = 0 then write(a, ' ');
  until a = b
end.