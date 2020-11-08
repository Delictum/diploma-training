program Est;

var
  i, k: integer;

begin
  write('Введите 1, если год високосный, в противном случае введите 0: ');
  repeat
    readln(k);
  until (k = 0) or (k = 1);
  readln(i);
  if (i = 2) and (k = 1) then write('29 дней');
  if (i = 2) and (k = 0) then write('28 дней');
  case i of
    1: write('31 день');
    3: write('31 день');
    4: write('30 дней');
    5: write('31 день');
    6: write('30 дней');
    7: write('31 день');
    8: write('31 день');
    9: write('30 дней');
    10: write('31 день');
    11: write('30 дней');
    12: write('31 дней');
  end;
  
end.