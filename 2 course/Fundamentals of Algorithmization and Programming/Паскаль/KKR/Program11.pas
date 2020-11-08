program Est;

var
  i, n, s, p: real;

begin
  Write('Кол-во желаемой прибыли: ');
  read(N);
  Write('Потрачено на акции: ');
  read(S);
  Write('Подоражание акции с каждым годом в : ');
  read(P);
  i := 0;
  repeat
    i := i + 1;
    s := s * p;
  until s > n;
  write('Через ', i, ' лет превысит ', n, ' условных единиц прибыли');
end.