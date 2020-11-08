program Est;

var
  A: array[1..100] of integer;
  max, min, n1, n2, i, c, j, k: integer;

begin
  i := 0;
  writeln('Введите значения массива: ');
  repeat
    i := 1 + i;
    readln(a[i]);
  until a[i] = 0;
  max := a[1];
  min := a[1];
  k := i;
  for i := 1 to k - 1 do
    for j := i + 1 to k do
    begin
      if a[j] = a[i] then a[i] := a[i] + 1;
    end;
  for i := 1 to k do
  begin
    if A[i] > max then
    begin
      max := A[i]; 
      n1 := i; {находим максимум и его индекс}
    end;
    if A[i] < min then
    begin
      min := A[i]; 
      n2 := i; {находим минимум и его индекс}
    end;
  end;
  writeln('MAX=', max, ' и MIN=', min);
  c := A[n1];
  A[n1] := A[n2];
  A[n2] := c; {меняем местами через третью переменную}
  for i := 1 to k do 
    Write(A[i]:3); {выводим результат}
end.