program Est;

var
  i, n, s, p: real;

begin
  Write('���-�� �������� �������: ');
  read(N);
  Write('��������� �� �����: ');
  read(S);
  Write('����������� ����� � ������ ����� � : ');
  read(P);
  i := 0;
  repeat
    i := i + 1;
    s := s * p;
  until s > n;
  write('����� ', i, ' ��� �������� ', n, ' �������� ������ �������');
end.