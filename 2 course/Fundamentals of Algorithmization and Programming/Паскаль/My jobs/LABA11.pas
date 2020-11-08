program Est;

var
  A: array[1..12] of real;
  i, j: byte;

begin
  writeln('Исходные элементы:');
  for i := 1 to 12 do
  begin
    a[i] := random(24) / (1 + random(9)) - random(10);
    write(a[i]:6:2);
  end;
  writeln;
  begin
    for j := 1 to 12 - 1 do
      for i := 1 to 12 - j do
        if a[i] > a[i + 1] then
          swap(a[i], a[i + 1])
  end;
  writeln('Отсортированные элементы:');
  for i := 1 to 12 do
    write(a[i]:6:2);
end.