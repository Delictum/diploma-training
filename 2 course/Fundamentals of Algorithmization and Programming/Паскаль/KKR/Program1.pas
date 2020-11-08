program Est;

var
  i, j, s: real;
  a: char;

begin
  write('Введите два числа: ');
  readln(i);
  readln(j);
  write('Введите знак операции: ');
  readln(a);
  if a = '+' then s := i + j;
  if a = '-' then s := i - j;
  if a = '*' then s := i * j;
  if a = '/' then s := i / j;
  write('Полученный результат: ', s);
end.