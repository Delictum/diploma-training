var
  mas: array[1..20] of integer;
  i, s, c, a, b: integer;

begin
  write('������� A: ');
  readln(a);
  write('������� B: ');
  readln(b);
  s := 0;
  c := b - a + 1;
  writeln('�������� �� 1 �� 20: ');
  for i := 1 to 20 do
  begin
    mas[i] := random(30) - 15;
    write(mas[i]:4);
  end;
  writeln;
  writeln('�������� �� A �� B: ');
  for i := a to b do
  begin
    write(mas[i]:4);
    if i mod 3 = 0 then s := s + mas[i];
  end;
  writeln;
  writeln('�����: ', s);
  writeln('���������� ����� � ���������� �� A �� B: ', c);
end.