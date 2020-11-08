type
  mas = array[1..10] of integer;

var
  a: mas;
  i, c, k, j, x, min, max, tmp: integer;

begin
  min := 10000;
  max := -10000;
  writeln('Исходная массив:');
  for i := 1 to 10 do
    readln(a[i]);
  writeln;
  
  for k := 1 to 9 do {зачем здесь n-1?}
  begin
    max := a[k];
    c := k;
    for i := k + 1 to 10 do
      if a[i] > max
      then 
      begin
        max := a[i];
        c := I
      end;
    a[c] := a[k];
    a[k] := max
  end;
  
  writeln('Отсортированный массив: ');
  for i := 1 to 10 do
    write(a[i]:4);
end.