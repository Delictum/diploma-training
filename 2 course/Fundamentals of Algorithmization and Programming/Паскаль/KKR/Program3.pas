program Est;

var
  i, s, k: integer;

begin
  writeln('������� �����: ');
  k := 0;
  repeat
    readln(i);
    s := s + i;
    k := k + 1;
  until s > 300;
  write('���-�� �����: ', k);
end.