program Est;

var
  i: integer;

begin
  write('Введите год: ');
  readln(i);
  if (i mod 4 = 0) and (i mod 100 = 0) and (i mod 400 <> 0) then write('В году 366 дней') else write('В году 365 дней');
end.