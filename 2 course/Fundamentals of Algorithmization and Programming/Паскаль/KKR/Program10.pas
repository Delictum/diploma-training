program Est;

var
  s, sr: real;
  a: array[1..5]  of real;
  i: integer;

begin
  s := 0;
  write('Введите положительные числа: ');
  i := 0;
  repeat
    i := 1 + i;
    read(a[i]);
    if a[i] > 0 then s := s + a[i];
    sr := s / i;
    if a[i] <= 0 then i := i - 1;
  until i = 5;
  writeln;
  writeln('Сумма: ', s, ', среднее арифметическое: ', sr);
end.