program Est;

var
  s, m, f: real;
  i: integer;

begin
  write('������� ���-�� �������������: ');
  readln(s);
  write('�����: ');
  readln(m);
  f := m;
  repeat
    m := m * 1.2;
    i := i + 1;
  until m > s;
  write('����� ', i, ' ��� ������������� �������� �����');
end.