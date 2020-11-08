program Est;

var
  n: integer;

begin
  repeat
    write('Введите двухзначное число n=');
    readln(n);
  until abs(n) in [10..99];
  if (n div 10 + n mod 10) mod 5 = 0 then write('Сумма цифр делится на 5')
  else write('Сумма цифр не делится на 5');
end.