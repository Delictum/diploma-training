program Est;

type
  mss = ^mas;
  mas = array of integer;

var
  a: mss;
  i, n, g, k, f, sum, D: integer;
  s: real;

begin
  new(a);
  write('������� N: ');
  readln(n);
  write('������� D: ');
  readln(D);
  write('������� F: ');
  readln(F);
  setlength(a^, n);
  for i := 1 to a^.Length - 1 do
  begin
    a^[i] := random(10);
    write(a^[i]:2);
  end;
  writeln;
  for i := 1 to a^.length - 1 do
  begin
    if (a^[i] < f) then Inc(k);
    if (a^[i] > d) and (i mod 2 <> 0) then
    begin
      Inc(g);
      sum := sum + a^[i];
      s := sum / g;
    end;
  end;
  writeln('������� �������������� ����� ������ ��������� D � ������� �� �������� �����: ', s);
  writeln('���-�� �����, ��������� ��������� F: ', k);
end.