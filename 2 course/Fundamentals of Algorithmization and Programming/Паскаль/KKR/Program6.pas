program Est;

var
  n: integer;

begin
  repeat
    write('������� ����������� ����� n=');
    readln(n);
  until abs(n) in [10..99];
  if (n div 10 + n mod 10) mod 5 = 0 then write('����� ���� ������� �� 5')
  else write('����� ���� �� ������� �� 5');
end.