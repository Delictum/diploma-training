{������� ����� �� ���������� [A;B] ������� ���������� ���� �����.( ����� repeat )}
program Est;

var
  a, b, k: integer;

begin
  write('������� A: ');
  readln(a);
  write('������� B: ');
  readln(b);
  k := b - a + 1;
  writeln('����� �� ���������� �� ', a, ' �� ', b, ' ������� ', k, ':');
  repeat
    inc(a);
    if a mod k = 0 then write(a, ' ');
  until a = b
end.