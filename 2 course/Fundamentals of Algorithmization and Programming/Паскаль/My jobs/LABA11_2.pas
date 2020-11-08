Program Est;

const
  nmax = 10;

type
mas = array[1..nmax, 1..nmax] of integer;

var
  a: mas;
  b:mas;
  jj, n, m, i, j, k, p, v, tmp: integer;

begin
  writeln('Введите размеры матрицы:');
  write(' Количество строк до ', nmax, ' n=');
  repeat
    readln(n);
  until n in [1..nmax];
  write(' Количество столбцов до ', nmax, '  m=');
  repeat
    readln(m);
  until m in [1..nmax];
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