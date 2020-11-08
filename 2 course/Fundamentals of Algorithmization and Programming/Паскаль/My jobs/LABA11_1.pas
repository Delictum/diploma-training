program Est;

var
  A: array[1..12] of real;
  i, j, g: byte;
  buf, e:real;

begin
  writeln('Исходные элементы:');
  for i := 1 to 12 do
  begin
    a[i] := random(24) / (1 + random(9)) - random(10);
    write(a[i]:6:2);
  end;
  writeln;
  
  Begin
  for i:=2 to 12 do
    begin
      e:=A[i];
      j:=1;
      while (e>a[j]) do
        Inc(j);
      for g:=i-1 downto j do
        a[g+1]:=a[g];
      a[j]:=e;
    end;
    end;

  begin
    for j := 1 to 12 - 1 do
      for i := 1 to 12 - j do
        if a[i] > a[i + 1] then
        begin
          buf:=a[i];
          a[i]:=a[i + 1];
          a[i + 1]:=buf;
          end;
  end;
  writeln('Отсортированные элементы:');
  for i := 1 to 12 do
    write(a[i]:6:2);
end.