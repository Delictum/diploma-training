type
mas = array[1..5, 1..6] of integer;

var
  a: mas;
  b:mas;
  jj, n, m, i, j, k, p, v, tmp: integer;

begin
  writeln('Исходная матрица:');
  for i := 1 to 5 do
  begin
    for j := 1 to 6 do
    begin
      a[i, j] := random(-20, 20);
      write(a[i, j]:4);
    end;
    writeln;
  end;
  writeln;
  
    for jj := 1 to 5 - 1 do
    for i := 1 to 5 - jj do
        for j := 1 to 6 do
      if a[i,j] < a[i + 1,j] then
      begin
        b[i,j] := a[i,j];
        a[i,j] := a[i + 1,j];
        a[i + 1,j] := b[i,j];
        end;
  
  writeln('Отсортированная матрица:');
  for i := 1 to 5 do
  begin
    for j := 1 to 6 do
      write(a[i, j]:4);
    writeln;
  end;
end.