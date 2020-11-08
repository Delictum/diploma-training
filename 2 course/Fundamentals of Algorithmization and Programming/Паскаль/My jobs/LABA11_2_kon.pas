Program Est;

type
mas = array[1..100, 1..100] of real;

var
  a: mas;
  b:mas;
  jj, n, m, i, j, k, p, v, tmp: integer;

begin
  write(' Введите количество строк  n=');
    readln(n);
  write(' Введите количество столбцов  m=');
    readln(m);
  writeln;
  writeln('Исходная матрица:');
  for i := 1 to n do
  begin
    for j := 1 to m do
    begin
      a[i, j] := random(20);
      write(a[i, j]:4);
    end;
    writeln;
  end;
  writeln;
  
    for jj := 1 to n - 1 do
    for i := 1 to n - jj do
        for j := 1 to m do
      if a[i,j] < a[i + 1,j] then
      begin
        b[i,j] := a[i,j];
        a[i,j] := a[i + 1,j];
        a[i + 1,j] := b[i,j];
        end;
  
  writeln('Отсортированная матрица:');
  for i := 1 to n do
  begin
    for j := 1 to m do
      write(a[i, j]:4);
    writeln;
  end;
end.